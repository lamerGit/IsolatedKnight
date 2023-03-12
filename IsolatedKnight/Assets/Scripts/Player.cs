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
    float _partnerAttackSpeed;
    float _fixedDamage;
    float _expAmount;
    float _goldAmount;



    float _currentTouchSpeed = 0.0f;
    float _currentStamina = 0.0f;

    // 레벨 x (레벨+1) x 25 - 100
    int _level = 1;
    float _currentExp = 0.0f;
    float _maxExp = 100.0f;

    Animator _animator;

    float _currentAutoAttackTimer = 0.0f;
    float _AutoAttackTimer = 5.0f;
    float _AutoAttackRange = 60.0f;

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
        get { return _touchSpeed- Managers.GameManager.ExtraTouchSpeed; }
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
                _currentExp += tempExp;

                Managers.GameManager.State = GameState.LevelUp;
                Managers.UIManager.LevelUpButtonGroup.Open();
                Debug.Log("레벨업!!");
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
        private set
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
    }


    void Start()
    {
        Weapon weapon = null;
        Managers.Data.WeaponDict.TryGetValue(1,out weapon);

        Stat stat = null;
        Managers.Data.StatDict.TryGetValue(1,out stat);

        // 무기데이터 파싱
        _type=weapon.type;
        TouchDamage = weapon.touchDamage;
        TouchSpeed =weapon.touchSpeed;
        StaminaConsum = weapon.staminaconsum;
        _partnerDamage=weapon.partnerDamage;
        _skillDamage = weapon.skillDamage;

        // 스탯데이터 파싱
        MaxStamina = stat.maxStamina; 
        _staminaRecoverySpeed=stat.staminaRecoverySpeed;
        _skillRecoverySpeed = stat.skillRecoverySpeed;
        _partnerAttackSpeed=stat.partnerAttackSpeed;
        _fixedDamage=stat.fixedDamage;
        _expAmount=stat.expAmount;
        _goldAmount=stat.goldAmount;

        ////////////////////////////////

        CurrenTouchSpeed = TouchSpeed;
        CurrentStamina = MaxStamina-0.1f;
        
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
                CurrentStamina += _staminaRecoverySpeed * Time.deltaTime;
                //Debug.Log(CurrentStamina);
            }

            if(CurrentAutoAttackTimer<_AutoAttackTimer && Managers.GameManager.TouchBuffTier2AutoAttack)
            {
                CurrentAutoAttackTimer += Time.deltaTime;
            }
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
        _animator.SetTrigger("Attack");
    }

    void OverloadAnimation()
    {
        _animator.SetBool("Overload", StaminaCheck);
    }

    public void ExpUp(float exp)
    {
        CurrentExp += exp+(exp*Managers.GameManager.ExtraExpPersent);
        Debug.Log(exp + (exp * Managers.GameManager.ExtraExpPersent));
    }

    void AutoAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _AutoAttackRange, LayerMask.GetMask("Enemy"));

        if(colliders.Length > 0 )
        {
            for (int i = 0; i < 1; i++)
            {
                int touchDamage = TouchDamage + Managers.GameManager.ExtraTouchDamage;
                if (Managers.GameManager.TouchBuffTier3AutoAttackBuff)
                {
                    colliders[i].GetComponent<EnemyBase>().OnTouchDamage(touchDamage);
                }
                else
                {
                    colliders[i].GetComponent<EnemyBase>().OnMultiDamage(touchDamage);
                }
            }

            CurrentAutoAttackTimer = 0.0f;

        }else
        {
            CurrentAutoAttackTimer = _AutoAttackTimer - 0.1f;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _AutoAttackRange);
    }
#endif
}
