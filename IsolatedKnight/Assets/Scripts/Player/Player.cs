using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //무기스탯
    int _type;
    int _touchDamage;
    float _touchSpeed;
    float _staminaconsum;
    int _partnerDamage;
    int _skillDamage;

    //기본 스탯
    int _maxStamina;
    float _staminaRecoverySpeed;
    float _skillRecoverySpeed;
    int _fixedDamage;
    float _expAmount;
    float _goldAmount;

    //고정데미지 스탯
    int _arrow;
    int _defence;
    int _fire;
    int _thunder;

    // 추가공격데미지 스탯
    int _ice;
    int _greenBall;
    int _meteor;


    float _currentTouchSpeed = 0.0f;
    float _currentStamina = 0.0f;

    // 레벨 x (레벨+1) x 25 - 100
    int _level = 1;
    float _currentExp = 0.0f;
    float _maxExp = 100.0f;

    Animator _animator;

    float _currentAutoAttackTimer = 0.0f;
    float _AutoAttackTimer = 1.0f;
    float _AutoAttackRange = 60.0f;

    float _expAttackRange = 60.0f;
    float _allowSpeed = 40.0f;

    float _iceAttackRange = 60.0f;
    float _iceSpeed = 20.0f;

    float _greenBallRange = 60.0f;
    float _greenBallSpeed = 5.0f;

    float _currentLightningTimer = 0.0f;
    float _lightningTimer = 2.0f;
    float _lightningRange = 60.0f;

    GameObject Sword;
    GameObject Axe;
    GameObject Hammer;
    GameObject Staff;

    bool _isDead = false;

    bool _staminaTier3Overload = false;

    AudioSource _playerDieAudio;
    AudioSource _levelUpAudio;

    int _currentGold = 0;

    int _iceCount = 0;
    int _maxIceCount = 50;

    int _greenBallCount = 0;
    int _maxGreenBallCount = 10;

    int _touchCount = 0;
    int _maxTouchCount = 25;

    float _currentTouchCountTimer = 0.0f;
    float _touchCountTimer = 0.1f;

    int _touchHitCount = 0;

    int _meteorCount = 0;
    int _maxMeteorCount = 30;

    int _randomCount = 0;
    int _maxRandomCount = 10;

    PlayerController _playerController;

    float _touchRecovery = 1.0f;

    public int RandomCount
    {
        get { return _randomCount; }
        set { _randomCount = Mathf.Clamp( value,0,_maxRandomCount);
        if(_randomCount==_maxRandomCount)
            {
                int r=Random.Range(0, 4);

                switch (r)
                {
                    case 0:
                        _playerController.SwordWind();
                        break;
                    case 1:
                        ExpAttack();
                        break;
                    case 2:
                        IceAttack();
                        break;
                    case 3:
                        GreenBallAttack();
                        break;


                }

               
                _randomCount = 0;
            }
        
        }
    }

    public int MeteorCount
    {
        get { return _meteorCount; }
        set
        {
            _meteorCount = Mathf.Clamp(value, 0, _maxMeteorCount);
            if (_meteorCount == _maxMeteorCount)
            {
                Managers.Object.PartnerMeteor.Attack();
                _meteorCount = 0;
            }


        }
    }

    public int Meteor
    {
        get { return _meteor; }
        private set { _meteor = value; }
    }

    float CurrentTouchCountTimer
    {
        get { return _currentTouchCountTimer; }
        set { _currentTouchCountTimer = Mathf.Clamp( value,0.0f,_touchCountTimer);
        if(_currentTouchCountTimer==_touchCountTimer)
            {
                TouchCountAutoAttack();
                _currentTouchCountTimer=0;
            }
        
        }
    }

    public int TouchCount
    {
        get { return _touchCount; }
        set { _touchCount = Mathf.Clamp(value,0,_maxTouchCount); 
        if(_touchCount==_maxTouchCount)
            {
                _animator.SetTrigger("Attack3");
                _touchHitCount += 10;

                if(Managers.GameManager.TouchAndAutoTouchTier2TouchCountUp)
                {
                    _touchHitCount += 10;
                }

                if (Managers.GameManager.TouchAndAutoTouchTier3TouchCountUp)
                {
                    _touchHitCount += 15;
                }

                _touchCount = 0;
            }
        
        }
    }

    public int MaxGreenBallCount
    {
        get { return _maxGreenBallCount;}
        set { _maxGreenBallCount = value;
        if(_maxGreenBallCount<GreenBallCount)
            {
                GreenBallCount += _maxGreenBallCount;
            }
        
        }
    }

    public int GreenBallCount
    {
        get { return _greenBallCount; }
        set
        {
            _greenBallCount = Mathf.Clamp(value, 0, MaxGreenBallCount);
            if (_greenBallCount == MaxGreenBallCount)
            {
                GreenBallAttack();
                _greenBallCount = 0;
            }



        }
    }



    public int MaxIceCount
    {
        get { return _maxIceCount; }
        set
        {
            _maxIceCount = value;
            if (_maxIceCount < IceCount)
            {
                IceCount += _maxIceCount;
            }



        }
    }

    public int IceCount
    {
        get { return _iceCount; }
        set { _iceCount = Mathf.Clamp( value,0,MaxIceCount);
        
            if(_iceCount== MaxIceCount)
            {
                IceAttack();
                _iceCount = 0;
            }
        
        
        }
    }

    public WeaponType EquipWeaponType
    {
        get { return (WeaponType)_type; }
        private set { _type = (int)value;
            switch ((WeaponType)_type)
            {
                case WeaponType.Sword:
                    Sword.SetActive(true);
                    Axe.SetActive(false);
                    Hammer.SetActive(false);
                    Staff.SetActive(false);
                    break;
                case WeaponType.Axe:
                    Sword.SetActive(false);
                    Axe.SetActive(true);
                    Hammer.SetActive(false);
                    Staff.SetActive(false);
                    break;
                case WeaponType.Hammer:
                    Sword.SetActive(false);
                    Axe.SetActive(false);
                    Hammer.SetActive(true);
                    Staff.SetActive(false);
                    break;
                case WeaponType.Stick:
                    Sword.SetActive(false);
                    Axe.SetActive(false);
                    Hammer.SetActive(false);
                    Staff.SetActive(true);
                    break;
                case WeaponType.Hand:
                    Sword.SetActive(false);
                    Axe.SetActive(false);
                    Hammer.SetActive(false);
                    Staff.SetActive(false);
                    break;
            }


        }
    }

    public float CurrentLightningTimer
    {
        get { return _currentLightningTimer; }
        set { _currentLightningTimer = Mathf.Clamp(value, 0.0f, _lightningTimer); 
        
            if( _currentLightningTimer ==_lightningTimer ) 
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, _lightningRange, LayerMask.GetMask("Enemy"));

                if (colliders.Length > 0)
                {
                    int totalDamage = _thunder;
                    int count = Managers.GameManager.PassiveThunderCount;

                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if (count < 1)
                            break;

                        int r=Random.Range(0, colliders.Length);

                        EnemyBase e = colliders[r].GetComponent<EnemyBase>();
                        Poolable p = Managers.Pool.Pop(Managers.Object.PassiveLightningFx);
                        p.Spawn(e.transform);
                        e.OnFixedDamage(totalDamage,DamageType.PassiveThunder);
                        count--;

                        if(Managers.GameManager.PassiveThunderTier3CoolTimeRecovery)
                        {
                            int index=Managers.UIManager.SkillSlotGroup.SlotList.Count;

                            for(int skillIndex=0; skillIndex < index; skillIndex++)
                            {
                                Managers.UIManager.SkillSlotGroup.SlotList[skillIndex].CurrentSkillColTime += 0.05f;
                            }
                        }
                    }
                    _currentLightningTimer = 0.0f;

                }
                else
                {
                    _currentLightningTimer = _lightningTimer - 0.1f;


                }

            }

        }
    }

    public int Fire
    {
        get { return _fire; }
        private set { _fire = value; }
    }

    public int Defence
    {
        get { return _defence; }
        private set { _defence = value; }
    }
    public int FixedDamage
    {
        get { return _fixedDamage; }
        private set { _fixedDamage = value; }
    }

    public float StaminaRecoverySpeed
    {
        get { return _staminaRecoverySpeed; }
        set { _staminaRecoverySpeed = value;}
    }

    public float TouchRecoverySpeed
    {
        get { return _touchRecovery; }
        set { _touchRecovery = value; }
    }

    #region Particle
    public ParticleSystem SkillResetFx
    {
        get; private set;
    }

    public ParticleSystem TouchBuffReadyFx
    {
        get;private set;
    }

    public ParticleSystem MultiPointReadyFx
    {
        get; private set;
    }
    public ParticleSystem MultiPointFx
    {
        get; private set;
    }

    public ParticleSystem OnePointSkillFx
    {
        get; private set;
    }
    #endregion

    public GameObject AttackPoint
    {
        get; private set;
    }

    public int SkillDamage
    {
        get { return _skillDamage; }
    }
    
    public float SkillRecoverySpeed
    {
        get { return _skillRecoverySpeed + Managers.GameManager.ExtraSkillRecovery; }
        private set { _skillRecoverySpeed = value; }
    }

    public int PartnerDamage
    {
        get { return _partnerDamage; }
    }

    float CurrentAutoAttackTimer
    {
        get { return _currentAutoAttackTimer; }
        set
        {
            _currentAutoAttackTimer = Mathf.Clamp(value, 0.0f, _AutoAttackTimer);
            if (_currentAutoAttackTimer == _AutoAttackTimer)
            {
                AutoAttack();
            }

        }
    }

    public int MaxStamina
    {
        get { return _maxStamina; }
        private set { _maxStamina = value;}
    }

    public float StaminaConsum
    {
        get { return _staminaconsum-Managers.GameManager.ExtraStaminaconsum; }
        private set { _staminaconsum = value;}
    }

    public float TouchSpeed
    {
        get { return _touchSpeed - Managers.GameManager.ExtraTouchSpeed; }
        
        private set { _touchSpeed = value; }
    }

    float CurrentExp
    {
        get { return _currentExp; }
        set
        {
            _currentExp = value;
            float tempExp = 0.0f;
            if (_currentExp >= _maxExp)
            {
                _levelUpAudio.Play();

                tempExp = _currentExp - _maxExp;
                _currentExp = 0;
                _level++;
                int nextLevel = _level + 1;
                _maxExp = nextLevel * (nextLevel + 1) * 25 - 100;
                CurrentExp += tempExp;


                Managers.GameManager.LevelUpStack++;
                Managers.GameManager.State = GameState.LevelUp;
                Managers.UIManager.LevelUpButtonGroup.Open();
                //Debug.Log("레벨업!!");
            }

            Managers.UIManager.ExpUI.AmountChange(_currentExp,_maxExp, _level);

            if (Managers.GameManager.PassiveExpTier2Arrow)
            {
                ExpAttack();
            }


        }
    }

    public float CurrenTouchSpeed
    {
        get { return _currentTouchSpeed; }
        set
        {
            _currentTouchSpeed = Mathf.Clamp(value, 0.0f, TouchSpeed);
            if (_currentTouchSpeed == TouchSpeed)
            {
                TouchPossibleCheck = true;
            }

        }
    }

    public float CurrentStamina
    {
        get { return _currentStamina; }
        set
        {
            _currentStamina = Mathf.Clamp(value, 0.0f, MaxStamina+Managers.GameManager.ExtraMaxStamina);

            Managers.UIManager.StaminaUI.AmountChange(_currentStamina, MaxStamina + Managers.GameManager.ExtraMaxStamina);
            if (_currentStamina == 0.0f )
            {
                if (Managers.GameManager.StaminaTier3Overload && StaminaCheck && !_staminaTier3Overload)
                {
                    _staminaTier3Overload = true;
                    Managers.GameManager.ExtraSkillDamage += (int)(SkillDamage * 6.0f);
                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                    Managers.GameManager.ExtraPartnerDamage += (int)(PartnerDamage * 3.0f);
                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);


                }
                if(StaminaCheck)
                {
                    Managers.UIManager.StaminaUI.OverloadColor(StaminaCheck);

                    if(Managers.GameManager.SynergyWaringDragonTier1WaningOn)
                    {
                        Managers.Object.PartnerDragon.AttackSpeedTick = 5.0f;
                        SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].DragonattackSpeedUp);
                    }
                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].overload);
                    //Debug.Log("과부화");
                }

                StaminaCheck = false;
                OverloadAnimation();
                
                
            }

            if( _currentStamina == MaxStamina + Managers.GameManager.ExtraMaxStamina )
            {
                if (Managers.GameManager.StaminaTier3Overload && !StaminaCheck && _staminaTier3Overload)
                {
                    _staminaTier3Overload = false;
                    Managers.GameManager.ExtraSkillDamage -= (int)(SkillDamage * 6.0f);
                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamagedown);
                    Managers.GameManager.ExtraPartnerDamage -= (int)(PartnerDamage * 3.0f);
                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamagedown);


                }

                if (!StaminaCheck)
                {
                    Managers.UIManager.StaminaUI.OverloadColor(StaminaCheck);

                    if (Managers.GameManager.SynergyWaringDragonTier1WaningOn)
                    {
                        Managers.Object.PartnerDragon.AttackSpeedTick = 1.0f;
                        SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].DragonattackSpeedDown);
                    }

                    SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].overloadend);
                    //Debug.Log("과부화해제");
                }

                StaminaCheck = true;
                OverloadAnimation();
                
            }

        }
    }

    public bool TouchPossibleCheck { get; private set; } = false;

    /// <summary>
    /// 스태미나를 오버해서 썻는지 확인하는 변수
    /// </summary>
    public bool StaminaCheck { get;private set; } = true;

    public int TouchDamage
    {
        get { return _touchDamage; }
        private set { _touchDamage = value; }
    }

    private void Awake()
    {
        _playerDieAudio = GetComponent<AudioSource>();
        _levelUpAudio=transform.Find("LevelUpSound").GetComponent<AudioSource>();
        _playerController = GetComponent<PlayerController>();

        _animator = GetComponent<Animator>();
        AttackPoint = transform.Find("AttackPoint").gameObject;
        OnePointSkillFx=transform.Find("OnePointSkillReadyFx").GetComponent<ParticleSystem>();
        OnePointSkillFx.Stop();

        MultiPointFx = transform.Find("MultiPointFx").GetComponent<ParticleSystem>();
        MultiPointFx.Stop();

        MultiPointReadyFx = transform.Find("MultiPointReadyFx").GetComponent<ParticleSystem>();
        MultiPointReadyFx.Stop();

        TouchBuffReadyFx = transform.Find("TouchBuffReadyFx").GetComponent<ParticleSystem>();
        TouchBuffReadyFx.Stop();

        SkillResetFx = transform.Find("SkillResetFx").GetComponent<ParticleSystem>();
        SkillResetFx.Stop();

        GameObject WeaponGroup = transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R/Shoulder_R/Elbow_R/Hand_R/WeaponGroup").gameObject;
        Sword = WeaponGroup.transform.Find("Sword").gameObject;
        Axe = WeaponGroup.transform.Find("Axe").gameObject;
        Hammer = WeaponGroup.transform.Find("Hammer").gameObject;
        Staff = WeaponGroup.transform.Find("Staff").gameObject;

    }


    void Start()
    {
        Weapon weapon = null;
        Managers.Data.WeaponDict.TryGetValue((int)GameDataManager.Instance.EquipWeapon,out weapon);

        Stat stat = null;
        Managers.Data.StatDict.TryGetValue(1,out stat);

        Fixed f = null;
        Managers.Data.FixedDict.TryGetValue(0,out f);

        ExtraAttack extraAttack = null;
        Managers.Data.ExtraAttackDict.TryGetValue(0,out extraAttack);

        

        // 무기데이터 파싱
        EquipWeaponType = (WeaponType)weapon.type;
        TouchDamage = weapon.touchDamage;
        TouchSpeed =weapon.touchSpeed;
        StaminaConsum = weapon.staminaconsum;
        _partnerDamage=weapon.partnerDamage;
        _skillDamage = weapon.skillDamage;

        // 스탯데이터 파싱
        MaxStamina = stat.maxStamina;
        StaminaRecoverySpeed = stat.staminaRecoverySpeed;
        SkillRecoverySpeed = stat.skillRecoverySpeed;
        FixedDamage = stat.fixedDamage;
        _expAmount=stat.expAmount;
        _goldAmount=stat.goldAmount;

        // 로비에서 얻은 증가량 계산
        PowerUp powerUp = null;
        Managers.Data.PowerUpDict.TryGetValue(1, out powerUp);

        int touchDamageIncrement = powerUp.touchDamageIncrement * GameDataManager.Instance.Power_TouchDamageTier;
        float touchSpeedIncrement = powerUp.touchSpeedIncrement * GameDataManager.Instance.Power_TouchSpeedTier;
        int maxStaminaIncrement = powerUp.maxStaminaIncrement * GameDataManager.Instance.Power_MaxStaminaTier;
        int skillDamageIncrement = powerUp.skillDamageIncrement * GameDataManager.Instance.Power_SkillDamageTier;
        float skillCoolTimeRecoveryIncrement = powerUp.skillCooltimeRecoveryIncrement * GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier;
        int partnerDamageIncrement = powerUp.partnerDamageIncrement * GameDataManager.Instance.Power_PartnerDamageTier;
        int fixedDamageIncrement = powerUp.fixedDamageIncrement * GameDataManager.Instance.Power_FixedDamageTier;
        float expIncrement = powerUp.expIncrement * GameDataManager.Instance.Power_ExpUpTier;
        float goldIncrement = powerUp.goldIncrement * GameDataManager.Instance.Power_GoldUpTier;

        TouchDamage += touchDamageIncrement;
        TouchSpeed -= TouchSpeed * touchSpeedIncrement;
        MaxStamina += maxStaminaIncrement;
        _skillDamage += skillDamageIncrement;
        SkillRecoverySpeed += skillCoolTimeRecoveryIncrement;
        _partnerDamage += partnerDamageIncrement;
        FixedDamage += fixedDamageIncrement;
        _expAmount += expIncrement;
        _goldAmount += goldIncrement;

        // 고정데미지 데이터 파싱
        _arrow = f.arrow;
        Defence = f.defence;
        Fire = f.fire;
        _thunder = f.thunder;

        _ice = extraAttack.ice;
        _greenBall=extraAttack.greenBall;
        Meteor = extraAttack.meteor;

        CurrenTouchSpeed = TouchSpeed;
        CurrentStamina = MaxStamina-0.1f;

        Managers.UIManager.ExpUI.AmountChange(_currentExp, _maxExp, _level);

        //Time.timeScale = 2.0f;
        Managers.UIManager.GoldUI.GoldChange(0);
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrenTouchSpeed < TouchSpeed)
            {
                CurrenTouchSpeed += Time.deltaTime*TouchRecoverySpeed;
                //Debug.Log(CurrenTouchSpeed);
            }

            if (CurrentStamina < MaxStamina + Managers.GameManager.ExtraMaxStamina)
            {
                CurrentStamina += StaminaRecoverySpeed * Time.deltaTime;
                //Debug.Log(CurrentStamina);
            }

            if(CurrentAutoAttackTimer<_AutoAttackTimer && Managers.GameManager.TouchBuffTier2AutoAttack)
            {
                CurrentAutoAttackTimer += Time.deltaTime;
            }

            if(CurrentLightningTimer<_lightningTimer && Managers.GameManager.PassiveThunderTier1ThunderOn)
            {
                CurrentLightningTimer += Time.deltaTime;
            }

            if(CurrentTouchCountTimer<_touchCountTimer && Managers.GameManager.TouchAndAutoTouchTier1TouchCountOn && _touchHitCount>0)
            {
                CurrentTouchCountTimer += Time.deltaTime;
            }
        }

        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Die") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.98f)
        {
            OnGameSetUI();
        }
        
    }

    public void ResetTouchSpeed()
    {
        CurrenTouchSpeed = 0.0f;

        if (Managers.GameManager.TouchSpeedTier3RandomConsum)
        {
            float r=Random.Range(0.0f, 1.0f);
            if(r<0.5f)
            {
                CurrentStamina -= StaminaConsum;
                //Debug.Log($"{StaminaConsum} 소비");

            }
            else
            {
                //Debug.Log("스태미나 소모 없음");
            }
        }
        else
        {
            CurrentStamina -= StaminaConsum;
            //Debug.Log($"{StaminaConsum} 소비");
        }
        TouchPossibleCheck=false;
    }

    public void AttackAnimation()
    {
        int r = Random.Range(0, 2);

        if(r==0)
        {
            _animator.SetTrigger("Attack");
        }
        else if(r==1)
        {
            _animator.SetTrigger("Attack2");
        }


        
    }

    void OverloadAnimation()
    {
        _animator.SetBool("Overload", StaminaCheck);
    }

    public void ExpUp(float exp)
    {
        CurrentExp += exp+(exp*_expAmount)+(exp*Managers.GameManager.ExtraExpPersent);
        //Debug.Log(exp + (exp * Managers.GameManager.ExtraExpPersent));
    }

    public void GoldUp(int gold)
    {
        _currentGold += gold + (int)(gold * _goldAmount)+(int)(gold*Managers.GameManager.ExtraGoldPersent);

        Managers.UIManager.GoldUI.GoldChange(_currentGold);
    }

    void AutoAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _AutoAttackRange, LayerMask.GetMask("Enemy"));

        if(colliders.Length > 0 )
        {
            for (int i = 0; i < 1; i++)
            {
                int r=Random.Range(0, colliders.Length);
                if (Managers.GameManager.TouchBuffTier3AutoAttackBuff)
                {
                    colliders[r].GetComponent<EnemyBase>().OnTouchDamage(TouchDamage, DamageType.Touch);
                }
                else
                {
                    colliders[r].GetComponent<EnemyBase>().OnExtraDamage(TouchDamage, DamageType.Touch);
                }
            }

            CurrentAutoAttackTimer = 0.0f;

        }else
        {
            CurrentAutoAttackTimer = _AutoAttackTimer - 0.1f;
        }
    }

    void TouchCountAutoAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _AutoAttackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            
            for (int i = 0; i < 1; i++)
            {
                int r = Random.Range(0, colliders.Length);
                if (Managers.GameManager.TouchBuffTier3AutoAttackBuff)
                {
                    colliders[r].GetComponent<EnemyBase>().OnTouchDamage(TouchDamage, DamageType.Touch);
                }
                else
                {
                    colliders[r].GetComponent<EnemyBase>().OnExtraDamage(TouchDamage, DamageType.Touch);
                }
                _touchHitCount--;
            }

        }
        
    }


    public void ExpAttack()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, _expAttackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            int expCount = 1;
            if(Managers.GameManager.PassiveExpTier3Arrow)
            {
                expCount = 3;
            }

            for (int i = 0; i < expCount; i++)
            {
                int r=Random.Range(0, colliders.Length);

                Poolable bullet = Managers.Pool.Pop(Managers.Object.ExpAllow);

                bullet.transform.position = AttackPoint.transform.position;
                bullet.Spawn(AttackPoint.transform);

                Vector3 dir = (colliders[r].transform.position - AttackPoint.transform.position).normalized;
                bullet.transform.LookAt(colliders[r].transform.position);
                PassiveExpArrow component = bullet.GetComponent<PassiveExpArrow>();

                dir.y += 0.01f;
                component.Rigid.velocity = dir * _allowSpeed;

                component.Damage = _arrow;
                component.Dir = dir;
                component.Speed = _allowSpeed;


                if (Managers.GameManager.State == GameState.LevelUp)
                {
                    component.Rigid.velocity = Vector3.zero;

                }

            }

        }


    }

    public void IceAttack()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, _iceAttackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            int iceCount = 5;
            if(Managers.GameManager.PassiveAndIceTier2MoreIce)
            {
                iceCount = 15;
            }

            for (int i = 0; i < iceCount; i++)
            {
                int r = Random.Range(0, colliders.Length);

                Poolable bullet = Managers.Pool.Pop(Managers.Object.PassiveIce);

                bullet.transform.position = AttackPoint.transform.position;
                bullet.Spawn(AttackPoint.transform);

                Vector3 dir = (colliders[r].transform.position - AttackPoint.transform.position).normalized;
                bullet.transform.LookAt(colliders[r].transform.position);
                PassiveAndIce component = bullet.GetComponent<PassiveAndIce>();

                dir.y += 0.01f;
                component.Rigid.velocity = dir * _iceSpeed;

                component.Damage = _ice;
                component.Dir = dir;
                component.Speed = _iceSpeed;


                if (Managers.GameManager.State == GameState.LevelUp)
                {
                    component.Rigid.velocity = Vector3.zero;

                }

            }

        }


    }

    public void GreenBallAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _greenBallRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            
            for (int i = 0; i < 1; i++)
            {
                int r = Random.Range(0, colliders.Length);

                Poolable bullet = Managers.Pool.Pop(Managers.Object.GreenBall);

                bullet.transform.position = AttackPoint.transform.position;
                bullet.Spawn(AttackPoint.transform);

                Vector3 dir = (colliders[r].transform.position - AttackPoint.transform.position).normalized;
                bullet.transform.LookAt(colliders[r].transform.position);
                SkillAndGreenBall component = bullet.GetComponent<SkillAndGreenBall>();

                dir.y += 0.01f;
                component.Rigid.velocity = dir * _greenBallSpeed;

                component.Damage = _greenBall;
                component.Dir = dir;
                component.Speed = _greenBallSpeed;

                if(Managers.GameManager.SkillAndGreenBallTier2GreenBallSpeedUp)
                {
                    component.Speed += _greenBallSpeed;
                }

                if(Managers.GameManager.SkillAndGreenBallTier3DurationUp)
                {
                    component.DeSpawnTimer += component.DeSpawnTimer;
                }

                if (Managers.GameManager.State == GameState.LevelUp)
                {
                    component.Rigid.velocity = Vector3.zero;

                }

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyBase e= other.GetComponent<EnemyBase>();
            if(e.IsBullet())
            {
                OnDie();
            }else
            {
                e.OnAttack();
            }

            Managers.GameManager.State = GameState.PlayerDie;
        }
        
    }

    public void OnDie()
    {
        if (_isDead)
            return;

        BackGroundSound.Instance.BackGroundStop();
        _playerDieAudio.Play();
        _isDead = true;
        _animator.SetTrigger("Die");
       
    }

    public void GoldSave()
    {
        GameDataManager.Instance.PlayerGold = Mathf.Clamp(GameDataManager.Instance.PlayerGold + _currentGold, 0, GameDataManager.maxGold);
        GameDataManager.Instance.SaveData();

        _currentGold = 0;
    }

    public void OnGameSetUI()
    {
        Managers.UIManager.GameSetUI.Open(false);
    }

    void SpawnText(string text)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.ExTextSpawn(text, Managers.Object.MyPlayer.transform);
    }



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _AutoAttackRange);
    }
#endif
}
