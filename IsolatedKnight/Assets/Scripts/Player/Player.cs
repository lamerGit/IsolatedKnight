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



    float _currentTouchSpeed = 0.0f;
    float _currentStamina = 0.0f;

    // 레벨 x (레벨+1) x 25 - 100
    int _level = 1;
    float _currentExp = 0.0f;
    float _maxExp = 100.0f;

    Animator _animator;

    float _currentAutoAttackTimer = 0.0f;
    float _AutoAttackTimer = 2.0f;
    float _AutoAttackRange = 60.0f;

    float _expAttackRange = 60.0f;
    float _allowSpeed = 40.0f;

    float _currentLightningTimer = 0.0f;
    float _lightningTimer = 2.0f;
    float _lightningRange = 60.0f;

    GameObject Sword;
    GameObject Axe;
    GameObject Hammer;
    GameObject Staff;

    bool isDead = false;
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
                if (Managers.GameManager.StaminaTier3Overload && StaminaCheck)
                {
                    _partnerDamage += 15;
                    _skillDamage += 30;
                    Debug.Log(_partnerDamage);
                    Debug.Log(_skillDamage);
                    
                }
                if(StaminaCheck)
                {
                    Managers.UIManager.StaminaUI.OverloadColor(StaminaCheck);

                    if(Managers.GameManager.SynergyWaringDragonTier1WaningOn)
                    {
                        Managers.Object.PartnerDragon.AttackSpeedTick = 3.0f;
                    }

                    Debug.Log("과부화");
                }

                StaminaCheck = false;
                OverloadAnimation();
                
                
            }

            if( _currentStamina == MaxStamina + Managers.GameManager.ExtraMaxStamina )
            {
                if (Managers.GameManager.StaminaTier3Overload && !StaminaCheck)
                {
                    _partnerDamage -= 15;
                    _skillDamage -= 30;
                    Debug.Log(_partnerDamage);
                    Debug.Log(_skillDamage);
                    
                }

                if(!StaminaCheck)
                {
                    Managers.UIManager.StaminaUI.OverloadColor(StaminaCheck);

                    if (Managers.GameManager.SynergyWaringDragonTier1WaningOn)
                    {
                        Managers.Object.PartnerDragon.AttackSpeedTick = 1.0f;
                    }

                    Debug.Log("과부화해제");
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
        Managers.Data.WeaponDict.TryGetValue((int)WeaponType.Sword,out weapon);

        Stat stat = null;
        Managers.Data.StatDict.TryGetValue(1,out stat);

        Fixed f = null;
        Managers.Data.FixedDict.TryGetValue(0,out f);

        

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

        CurrenTouchSpeed = TouchSpeed;
        CurrentStamina = MaxStamina-0.1f;

        Managers.UIManager.ExpUI.AmountChange(_currentExp, _maxExp, _level);

        //Time.timeScale = 2.0f;
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrenTouchSpeed < TouchSpeed)
            {
                CurrenTouchSpeed += Time.deltaTime;
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
                Debug.Log(CurrentStamina);

            }
            else
            {
                Debug.Log("스태미나 소모 없음");
            }
        }
        else
        {
            CurrentStamina -= StaminaConsum;
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
        CurrentExp += exp+(exp*Managers.GameManager.ExtraExpPersent);
        //Debug.Log(exp + (exp * Managers.GameManager.ExtraExpPersent));
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


    public void ExpAttack()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, _expAttackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            for (int i = 0; i < 1; i++)
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


                if (Managers.GameManager.PassiveExpTier3Arrow)
                {
                    Poolable left = Managers.Pool.Pop(Managers.Object.ExpAllow);
                    Poolable right = Managers.Pool.Pop(Managers.Object.ExpAllow);

                    left.transform.position = AttackPoint.transform.position + Vector3.left;
                    right.transform.position = AttackPoint.transform.position + Vector3.forward;

                    left.Spawn(AttackPoint.transform);
                    right.Spawn(AttackPoint.transform);

                    dir = (colliders[r].transform.position - AttackPoint.transform.position).normalized;
                    left.transform.LookAt(colliders[r].transform.position);
                    right.transform.LookAt(colliders[r].transform.position);

                    PassiveExpArrow leftComponent = left.GetComponent<PassiveExpArrow>();
                    PassiveExpArrow rightComponent = right.GetComponent<PassiveExpArrow>();

                    dir.y += 0.01f;

                    leftComponent.Rigid.velocity = dir * _allowSpeed;
                    rightComponent.Rigid.velocity = dir * _allowSpeed;

                    leftComponent.Damage = _arrow;
                    rightComponent.Damage = _arrow;

                    leftComponent.Dir = dir;
                    rightComponent.Dir = dir;

                    leftComponent.Speed = _allowSpeed;
                    rightComponent.Speed = _allowSpeed;

                    if (Managers.GameManager.State == GameState.LevelUp)
                    {
                        leftComponent.Rigid.velocity = Vector3.zero;
                        rightComponent.Rigid.velocity = Vector3.zero;

                    }

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
        if (isDead)
            return;

        isDead = true;
        _animator.SetTrigger("Die");
       
    }

    public void OnGameSetUI()
    {
        Managers.UIManager.GameSetUI.Open(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _AutoAttackRange);
    }
#endif
}
