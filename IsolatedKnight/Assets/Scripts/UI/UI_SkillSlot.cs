using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillSlot : MonoBehaviour
{
    public Button _button;
    public Image _backGroundImage;

    SkillType _skillType;

    float _skillColTime;
    int _skillDamage;

    float _currentSkillColTime = 0.0f;

    float _onePointSkillSpeed = 100.0f;

    float _sightRange = 15.0f;
    float _sightAngle = 90.0f;

    float _currentTouchBuffTimer = 0.0f;
    float _TouchBuffTimer = 10.0f;

    bool _touchBuffTier1Check = false;
    bool _touchBuffTier2Check = false;
    bool _touchBuffTier3Check = false;

    GameObject _onOffFx;

    public AudioClip[] _audioClips;

    public AudioSource _audioSource;

    public float SkillColTime
    {
        get { return _skillColTime; }
        private set { _skillColTime = value; }
    }

    float CurrentTouchBuffTimer
    {
        get { return _currentTouchBuffTimer; }
        set
        {
            _currentTouchBuffTimer = Mathf.Clamp(value, 0.0f, _TouchBuffTimer);

            if (_currentTouchBuffTimer == _TouchBuffTimer)
            {
                Managers.Object.MyPlayer.TouchBuffReadyFx.Stop();

                if (_touchBuffTier1Check)
                {
                    Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 2.0f);
                    _touchBuffTier1Check=false;
                }

                if (Managers.GameManager.SkillTouchBuffTier2SpeedUp && _touchBuffTier2Check)
                {
                    Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 3.0f);
                    Managers.GameManager.ExtraTouchSpeed -= Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                    Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                    _touchBuffTier2Check =false;
                }

                if (Managers.GameManager.SkillTouchBuffTier3StaminaRecovery && _touchBuffTier3Check)
                {
                    Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 4.0f);
                    Managers.GameManager.ExtraTouchSpeed -= Managers.Object.MyPlayer.TouchSpeed * 0.3f;
                    Managers.Object.MyPlayer.StaminaRecoverySpeed -=10.0f;
                    Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                    _touchBuffTier3Check = false;
                }

                //Debug.Log(Managers.GameManager.ExtraTouchDamage);

            }


        }
    }

    public float CurrentSkillColTime
    {
        get { return _currentSkillColTime; }
        set { _currentSkillColTime = Mathf.Clamp(value, 0.0f, SkillColTime);
            _button.image.fillAmount = _currentSkillColTime / SkillColTime;

            if(_currentSkillColTime== SkillColTime)
            {
                if (!gameObject.activeSelf)
                    return;

                _onOffFx.SetActive(true);
                switch (SkillType)
                {
                    case SkillType.None:
                        break;
                    case SkillType.OnePoint:
                        Managers.Object.MyPlayer.OnePointSkillFx.Play();
                        break;
                    case SkillType.MultiPoint:
                        Managers.Object.MyPlayer.MultiPointReadyFx.Play();
                        break;
                    case SkillType.TouchBuff:
                        break;
                    case SkillType.Buff:
                        break;
                }
              
            }


        }
    }

    public SkillType SkillType
    {
        get { return _skillType; }
        set { _skillType = value;

            switch (_skillType)
            {
                case SkillType.None:
                    break;
                case SkillType.OnePoint:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillOnePoint];
                    _backGroundImage.sprite= Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillOnePoint];
                    Skill onePointskill = null;
                    Managers.Data.SkillDict.TryGetValue((int)SkillType.OnePoint, out onePointskill);
                    _audioSource.clip = _audioClips[(int)SkillType.OnePoint];

                    SkillColTime = onePointskill.skillColTime;
                    _skillDamage= onePointskill.skillDamage;


                    break;
                case SkillType.MultiPoint:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillMultiPoint];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillMultiPoint];

                    Skill multiPointskill = null;
                    Managers.Data.SkillDict.TryGetValue((int)SkillType.MultiPoint, out multiPointskill);
                    _audioSource.clip = _audioClips[(int)SkillType.MultiPoint];

                    SkillColTime = multiPointskill.skillColTime;
                    _skillDamage = multiPointskill.skillDamage;
                    break;
                case SkillType.TouchBuff:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillTouchBuff];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillTouchBuff];

                    Skill touchBuffskill = null;
                    Managers.Data.SkillDict.TryGetValue((int)SkillType.TouchBuff, out touchBuffskill);
                    _audioSource.clip = _audioClips[(int)SkillType.TouchBuff];

                    SkillColTime = touchBuffskill.skillColTime;
                    _skillDamage = touchBuffskill.skillDamage;
                    break;
                case SkillType.Buff:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillBuff];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillBuff];

                    Skill buffskill = null;
                    Managers.Data.SkillDict.TryGetValue((int)SkillType.Buff, out buffskill);
                    _audioSource.clip = _audioClips[(int)SkillType.Buff];

                    SkillColTime = buffskill.skillColTime;
                    _skillDamage = buffskill.skillDamage;
                    break;
            }


        }
    }


    private void Awake()
    {
        _audioSource=GetComponent<AudioSource>();

        _button = transform.Find("Button").GetComponent<Button>();
        _backGroundImage = transform.Find("Background").GetComponent<Image>();

        _button.onClick.AddListener(OnSkill);

        _onOffFx = transform.Find("OnOff").gameObject;
        _onOffFx.SetActive(false);
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {

            if(CurrentSkillColTime< SkillColTime)
            {
                CurrentSkillColTime += Time.deltaTime*Managers.Object.MyPlayer.SkillRecoverySpeed;
            }

            if(SkillType== SkillType.TouchBuff) {
                if(CurrentTouchBuffTimer<_TouchBuffTimer)
                {
                    CurrentTouchBuffTimer += Time.deltaTime;
                }

            }

        }
    }

    void OnSkill()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentSkillColTime == SkillColTime)
            {
                _audioSource.Play();
                switch (SkillType)
                {
                    case SkillType.None:
                        break;
                    case SkillType.OnePoint:
                        OnePointSkill();
                        //Debug.Log("스킬1");
                        break;
                    case SkillType.MultiPoint:
                        MultiPointSkill();
                        //Debug.Log("스킬2");
                        break;
                    case SkillType.TouchBuff:
                        TouchBuffSkill();
                        //Debug.Log("스킬3");
                        break;
                    case SkillType.Buff:
                        SkillBuffSkill();
                        //Debug.Log("스킬4");
                        break;
                }
                if(Managers.GameManager.StickRandomSkillTier1RandomOn)
                {
                    float r = Random.Range(0.0f, 1.0f);
                    if(r<0.51f)
                    {
                        CurrentSkillColTime = 0.0f;
                        _onOffFx.SetActive(false);
                    }

                }else
                {
                    CurrentSkillColTime = 0.0f;
                    _onOffFx.SetActive(false);
                }
                
            }
            else
            {
                Debug.Log("쿨타임중");
            }
        }
    }

    void OnePointSkill()
    {
        Managers.Object.MyPlayer.OnePointSkillFx.Stop();

        Poolable bullet = Managers.Pool.Pop(Managers.Object.OnePointSkillFx);

        Transform playerTransfrom= Managers.Object.MyPlayer.AttackPoint.transform;

        bullet.transform.position = playerTransfrom.position;
        bullet.Spawn(playerTransfrom);

        Vector3 dir = playerTransfrom.forward;
        OnePointSkill component = bullet.GetComponent<OnePointSkill>();


        dir.y += 0.2f;
        component.Rigid.velocity = dir * _onePointSkillSpeed;

        component.Damage = _skillDamage ;
        component.Dir = dir;
        component.Speed = _onePointSkillSpeed;
    }

    void MultiPointSkill()
    {
        Managers.Object.MyPlayer.MultiPointFx.Play();
        Managers.Object.MyPlayer.MultiPointReadyFx.Stop();

        Transform playerTransfrom = Managers.Object.MyPlayer.AttackPoint.transform;

        Collider[] colliders = Physics.OverlapSphere(playerTransfrom.position, _sightRange, LayerMask.GetMask("Enemy"));


        if(colliders.Length>0)
        {
            for(int i=0; i<colliders.Length; i++)
            {
                if (InSightAngle(playerTransfrom, colliders[i].transform.position))
                {
                    EnemyBase e = colliders[i].GetComponent<EnemyBase>();
                    e.OnSkillDamge(_skillDamage,DamageType.SkillMultiPoint);
                    if(Managers.GameManager.SkillMutiPointTier2Slow)
                    {
                        e.EnemySlow(stack: 2);
                    }

                    if(Managers.GameManager.SkillMutiPointTier3Slow)
                    {
                        e.EnemySlow(stack: 2);
                    }
                }
            }


        }

    }

    void TouchBuffSkill()
    {
        Managers.Object.MyPlayer.TouchBuffReadyFx.Play();

        //Debug.Log("버프시작");
        CurrentTouchBuffTimer = 0.0f;

        if (!_touchBuffTier1Check)
        {
            Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 2.0f);
            _touchBuffTier1Check = true;
        }


        if (Managers.GameManager.SkillTouchBuffTier2SpeedUp && !_touchBuffTier2Check)
        {
            Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 3.0f);
            Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
            Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
            _touchBuffTier2Check = true;
        }

        if (Managers.GameManager.SkillTouchBuffTier3StaminaRecovery && !_touchBuffTier3Check)
        {
            Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 4.0f);
            Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.3f;
            Managers.Object.MyPlayer.StaminaRecoverySpeed += 10.0f;
            Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
            _touchBuffTier3Check = true;
        }

        //Debug.Log(Managers.GameManager.ExtraTouchDamage);


    }

    void SkillBuffSkill()
    {
        Managers.Object.MyPlayer.SkillResetFx.Play();

        Managers.UIManager.SkillSlotGroup.AllCoolTimeReset();
        Managers.Object.MyPlayer.CurrentStamina = 0.0f;
    }

    bool InSightAngle(Transform player, Vector3 targetPotision)
    {
        float angle = Vector3.Angle(player.forward, targetPotision - player.position);

        return (_sightAngle * 0.5f) > angle;
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}
