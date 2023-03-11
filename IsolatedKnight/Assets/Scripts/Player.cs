using Data;
using System.Collections;
using System.Collections.Generic;
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

    // 레벨 x (레벨+1) x 25 - 50
    int _level = 1;
    float _currentExp = 0.0f;
    float _maxExp = 100.0f;

    Animator _animator;

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
                _maxExp = nextLevel * (nextLevel + 1) * 25 - 50;
                _currentExp += tempExp;

                Managers.GameManager.State = GameState.LevelUp;
                Managers.UIManager.LevelUpButtonGroup.Open();
                Debug.Log("레벨업!!");
            }



        }
    }

    float CurrenTouchSpeed
    {
        get { return _currentTouchSpeed; }
        set
        {
            _currentTouchSpeed = Mathf.Clamp(value, 0.0f, _touchSpeed);
            if (_currentTouchSpeed == _touchSpeed)
            {
                TouchPossibleCheck = true;
            }

        }
    }

    float CurrentStamina
    {
        get { return _currentStamina; }
        set
        {
            _currentStamina = Mathf.Clamp(value, 0.0f, _maxStamina);
            if (_currentStamina == 0.0f)
            {
                StaminaCheck = false;
                OverloadAnimation();
                Debug.Log("과부화");
            }

            if( _currentStamina == _maxStamina)
            {
                StaminaCheck = true;
                OverloadAnimation();
                Debug.Log("과부화해제");
            }

        }
    }

    public bool TouchPossibleCheck { get; private set; } = false;
    public bool StaminaCheck { get;private set; } = true;

    public int TouchDamage
    {
        get { return _touchDamage; }

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
        _touchDamage=weapon.touchDamage;
        _touchSpeed=weapon.touchSpeed;
        _staminaconsum=weapon.staminaconsum;
        _partnerDamage=weapon.partnerDamage;
        _skillDamage = weapon.skillDamage;

        // 스탯데이터 파싱
        _maxStamina = stat.maxStamina; 
        _staminaRecoverySpeed=stat.staminaRecoverySpeed;
        _skillRecoverySpeed = stat.skillRecoverySpeed;
        _partnerAttackSpeed=stat.partnerAttackSpeed;
        _fixedDamage=stat.fixedDamage;
        _expAmount=stat.expAmount;
        _goldAmount=stat.goldAmount;

        ////////////////////////////////

        CurrenTouchSpeed = _touchSpeed;
        CurrentStamina = _maxStamina;
        
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrenTouchSpeed < _touchSpeed)
            {
                CurrenTouchSpeed += Time.deltaTime;
                //Debug.Log(CurrenTouchSpeed);
            }

            if (CurrentStamina < _maxStamina)
            {
                CurrentStamina += _staminaRecoverySpeed * Time.deltaTime;
                //Debug.Log(CurrentStamina);
            }
        }
        
    }

    public void ResetTouchSpeed()
    {
        CurrenTouchSpeed = 0.0f;
        CurrentStamina -= _staminaconsum;
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
        CurrentExp += exp;
    }

}
