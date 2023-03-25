using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Poolable
{
    [SerializeField]
    protected int _hp;
    protected int _maxHp;
    protected float _exp;
    protected int _level;
    protected NavMeshAgent _agent;
    protected Animator _animator;
    protected Transform _target;
    protected Light _light;

    protected EnemyState _state = EnemyState.Chase;

    protected Collider _collider;

    protected WaitForSeconds dieTimer = new WaitForSeconds(1.0f);


    protected SkinnedMeshRenderer _skinnedMeshRenderer;

    float _multiHitRange = 3.0f;

    protected int _speedDownStack = 0;

    float _currentSpeedDownTimer = 0.0f;

    float _SpeedDownTimer = 2.0f;
    float _speedDownPoint = 0.3f;

    protected ParticleSystem _stateFireFx;

    float _currentFireTimer = 0.0f;
    float _fireTimer = 2.0f;
    protected int _fireStack = 0;

    float _currentFireTick = 0.0f;
    float _fireTick = 0.8f;

    protected float _fireTranRange = 5.0f;

    protected bool _bullet = false;

    protected AudioSource _myAudio;

    protected float CurrentFireTick
    {
        get { return _currentFireTick; }
        set
        {
            _currentFireTick = Mathf.Clamp(value, 0.0f, _fireTick);
            if (_currentFireTick == _fireTick && Hp!=0)
            {
                int totalDamage = (Managers.Object.MyPlayer.Fire+ Managers.Object.MyPlayer.FixedDamage + Managers.GameManager.ExtraFixedDamage)*_fireStack;

                OnExtraFixedDamage(totalDamage,DamageType.PassiveFire);
                _currentFireTick = 0.0f;
            
            
            }

        }
    }

    float CurrentFireTimer
    {
        get { return _currentFireTimer; }
        set
        {
            _currentFireTimer = Mathf.Clamp(value, 0.0f, _fireTimer);
            if (_currentFireTimer == _fireTimer)
            {
                _stateFireFx.Stop();
                _light.enabled = false;
                _fireStack = 0;
            }


        }
    }

    protected virtual float CurrentSpeedDownTimer
    {
        get { return _currentSpeedDownTimer; }
        set { _currentSpeedDownTimer = Mathf.Clamp(value,0.0f,_SpeedDownTimer);
        
            if(_currentSpeedDownTimer == _SpeedDownTimer ) {

                if (_agent == null)
                    return;

                _agent.speed =_agent.speed+ _speedDownStack * _speedDownPoint;
                _speedDownStack = 0;
            
            }
        
        
        }
    }

    protected virtual int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        

        _stateFireFx=transform.Find("State_Fire").GetComponent<ParticleSystem>();
        _stateFireFx.Stop();

        _light = transform.Find("State_Fire").GetComponent<Light>();
        _light.enabled = false;

        _myAudio = GetComponent<AudioSource>();

        Managers.GameManager.StateChange += StateChange;
    }

    protected virtual void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentSpeedDownTimer < _SpeedDownTimer && _speedDownStack>0)
            {
                CurrentSpeedDownTimer += Time.deltaTime;
            }

            if(CurrentFireTimer<_fireTimer)
            {
                CurrentFireTimer += Time.deltaTime;
            }

            if(CurrentFireTick<_fireTick && _fireStack>0)
            {
                CurrentFireTick += Time.deltaTime;
            }
        }

        if (!_bullet && _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            GameOver();
        }
    }



    protected virtual void StateChange()
    {
        if (!gameObject.activeSelf)
            return;

        if(!_agent.enabled) return;

        switch (Managers.GameManager.State)
        {
            case GameState.Nomal:
                if (_state == EnemyState.Chase)
                {
                    //_target = Managers.Object.MyPlayer.transform;
                    //_agent.SetDestination(_target.transform.position);
                    _agent.isStopped = false;
                }
                break;
            case GameState.LevelUp:
                //_agent.ResetPath();
                _agent.isStopped = true;
                break;
            case GameState.PlayerDie:
                //_agent.ResetPath();
                _agent.isStopped = true;
                break;
        }

        
    }

    public void OnFixedDamage(int damage,DamageType damageType)
    {
        EnemyHitSound.Instance.HitPlay();


        int totaldamage = damage + Managers.Object.MyPlayer.FixedDamage+Managers.GameManager.ExtraFixedDamage;

        if(totaldamage < 0) {
        totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        FireCheck();

        //Debug.Log(Hp);
    }

    public void OnExtraFixedDamage(int damage,DamageType damageType)
    {
        int totaldamage = damage;

        
        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        //Debug.Log(Hp);
    }

    public void OnSkillDamge(int damage,DamageType damageType)
    {
        EnemyHitSound.Instance.HitPlay();

        int totaldamage = damage + Managers.Object.MyPlayer.SkillDamage+Managers.GameManager.ExtraSkillDamage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        FireCheck();
        //Debug.Log(Hp);
    }

    public void OnExtraSkillDamage(int damage,DamageType damageType)
    {
        int totaldamage = damage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        //Debug.Log(Hp);
    }


    /// <summary>
    /// 파트너에게 공격당했을때 사용하는 함수
    /// </summary>
    /// <param name="damage"></param>
    public void OnPartnerDamage(int damage,DamageType damageType)
    {
        EnemyHitSound.Instance.HitPlay();

        int totaldamage=damage + Managers.Object.MyPlayer.PartnerDamage + Managers.GameManager.ExtraPartnerDamage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        if(Managers.GameManager.PartnerBuffTier3ExtraAttack)
        {
            int extraDamage = (int)(totaldamage * 0.3f);
            OnExtraPartnerDamage(extraDamage,damageType);
        }
        FireCheck();
        //Debug.Log(Hp);
    }

    public void OnExtraPartnerDamage(int damage,DamageType damageType)
    {
        int totaldamage = damage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        //Debug.Log(Hp);
    }


    /// <summary>
    /// 터치로 공격당했을때 사용하는 함수
    /// </summary>
    /// <param name="damage">받는 데미지</param>
    public void OnTouchDamage(int damage,DamageType damageType)
    {
        EnemyHitSound.Instance.HitPlay();

        int totaldamage = damage + Managers.GameManager.ExtraTouchDamage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;
            
        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);



        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        Poolable fx = Managers.Pool.Pop(Managers.Object.TouchAttackFx);
        fx.Spawn(transform);

        //Debug.Log(Hp);

        if (Managers.GameManager.TouchDamageTier2SpeedDown)
        {
            EnemySlow();
        }

        if (Managers.GameManager.TouchDamageTier3MultiHit)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _multiHitRange, LayerMask.GetMask("Enemy"));
            if (colliders.Length > 0)
            {

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != transform.gameObject)
                    {
                        colliders[i].GetComponent<EnemyBase>().OnExtraDamage(totaldamage,DamageType.Touch);
                    }
                }
            }
        }

        if(Managers.GameManager.HammaerStunTier1StunOn)
        {
            EnemySlow(stack:3);
        }

        if(Managers.GameManager.HammerExtraAttackTier1ExtraAttackOn)
        {
            OnFixedDamage(totaldamage, damageType);
        }

        FireCheck();
    }

    /// <summary>
    /// 적이 추가데미지를 받을때 쓰는 함수
    /// </summary>
    /// <param name="damage">받는 데미지</param>
    public void OnExtraDamage(int damage, DamageType damageType)
    {
        int totaldamage = damage;

        if (totaldamage < 0)
        {
            totaldamage = 0;
        }

        int damageCheck = totaldamage;
        if (Hp - totaldamage < 0)
        {
            damageCheck = Hp - totaldamage;
            damageCheck += totaldamage;

        }

        Managers.GameManager.DamageCheck[damageType] += damageCheck;
        //Debug.Log(Managers.GameManager.DamageCheck[damageType]);


        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        Poolable fx = Managers.Pool.Pop(Managers.Object.TouchAttackFx);
        fx.Spawn(transform);

        //Debug.Log(Hp);
    }

    private void FireCheck()
    {
        if (Managers.GameManager.PassiveFireTire1FireOn)
        {
            if (Managers.GameManager.PassiveFireTire3FireOn)
            {
                float r = Random.Range(0.0f, 1.0f);

                if (r < 0.71f)
                {
                    EnemyFire();
                }
            }
            else
            {
                float r = Random.Range(0.0f, 1.0f);

                if (r < 0.31f)
                {
                    EnemyFire();
                }
            }

        }
    }

    

    public void EnemyFire()
    {
        _stateFireFx.Play();
        _light.enabled = true;
        _fireStack ++;

        if(Managers.GameManager.PassiveFireTire2DoubleFire)
        {
            _fireStack++;
        }

        CurrentFireTimer = 0.0f;
    }

    public virtual void EnemySlow(int stack=1)
    {
        _speedDownStack+=stack;
        CurrentSpeedDownTimer = 0.0f;
        _agent.speed =_agent.speed- _speedDownPoint*stack;
    }

    protected virtual IEnumerator HitMaterial()
    {
        _skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _skinnedMeshRenderer.material.color = Color.white;
    }


    public int GetMaxHp()
    {
        return _maxHp;
    }
    

    protected void StateClean()
    {
        CurrentFireTimer = _fireTimer;
        CurrentSpeedDownTimer = _SpeedDownTimer;
    }

    public void OnAttack()
    {
        _myAudio.Play();
        _animator.SetTrigger("Attack");
    }

    void GameOver()
    {
        Managers.Object.MyPlayer.OnDie();
    }

    public bool IsBullet()
    {
        return _bullet;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _multiHitRange);
    }
#endif
}
