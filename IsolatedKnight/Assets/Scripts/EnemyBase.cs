using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Poolable
{
    
    protected int _hp;
    protected int _maxHp;
    protected float _exp;
    protected int _level;
    protected NavMeshAgent _agent;
    protected Animator _animator;
    protected Transform _target;

    protected EnemyState _state = EnemyState.Chase;

    protected Collider _collider;

    protected WaitForSeconds dieTimer = new WaitForSeconds(1.0f);


    SkinnedMeshRenderer _skinnedMeshRenderer;

    float _multiHitRange = 3.0f;

    protected int _speedDownStack = 0;

    float _currentSpeedDownTimer = 0.0f;

    float _SpeedDownTimer = 2.0f;
    float _speedDownPoint = 0.3f;

    
    float CurrentSpeedDownTimer
    {
        get { return _currentSpeedDownTimer; }
        set { _currentSpeedDownTimer = Mathf.Clamp(value,0.0f,_SpeedDownTimer);
        
            if(_currentSpeedDownTimer == _SpeedDownTimer ) {

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

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        
        
        Managers.GameManager.StateChange += StateChange;
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentSpeedDownTimer < _SpeedDownTimer)
            {
                CurrentSpeedDownTimer += Time.deltaTime;
            }
        }
    }



    void StateChange()
    {
        if (!gameObject.activeSelf)
            return;

        switch (Managers.GameManager.State)
        {
            case GameState.Nomal:
                if (_state == EnemyState.Chase)
                {
                    _target = Managers.Object.MyPlayer.transform;
                    _agent.SetDestination(_target.transform.position);
                }
                break;
            case GameState.LevelUp:
                _agent.ResetPath();
                break;
            case GameState.PlayerDie:
                _agent.ResetPath();
                break;
        }

        
    }

    /// <summary>
    /// 파트너에게 공격당했을때 사용하는 함수
    /// </summary>
    /// <param name="damage"></param>
    public void OnPartnerDamage(int damage)
    {
        int totaldamage=damage + Managers.Object.MyPlayer.PartnerDamage + Managers.GameManager.ExtraPartnerDamage;

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        if(Managers.GameManager.PartnerBuffTier3ExtraAttack)
        {
            int extraDamage = (int)(totaldamage * 0.3f);
            OnExtraPartnerDamage(extraDamage);
        }

        Debug.Log(Hp);
    }

    public void OnExtraPartnerDamage(int damage)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(damage, transform);
        StartCoroutine(HitMaterial());
        Hp -= damage;

        Debug.Log(Hp);
    }


    /// <summary>
    /// 터치로 공격당했을때 사용하는 함수
    /// </summary>
    /// <param name="damage">받는 데미지</param>
    public void OnTouchDamage(int damage)
    {
        int totaldamage = damage + Managers.GameManager.ExtraTouchDamage;

        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(totaldamage, transform);
        StartCoroutine(HitMaterial());
        Hp -= totaldamage;

        Poolable fx = Managers.Pool.Pop(Managers.Object.TouchAttackFx);
        fx.Spawn(transform);

        Debug.Log(Hp);

        if(Managers.GameManager.TouchDamageTier2SpeedDown)
        {
            EnemySlow();
        }

        if(Managers.GameManager.TouchDamageTier3MultiHit)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _multiHitRange, LayerMask.GetMask("Enemy"));
            if(colliders.Length > 0)
            {

                for(int i=0; i<colliders.Length; i++)
                {
                    if (colliders[i].gameObject!=transform.gameObject)
                    {
                        colliders[i].GetComponent<EnemyBase>().OnExtraDamage(totaldamage);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 적이 추가데미지를 받을때 쓰는 함수
    /// </summary>
    /// <param name="damage">받는 데미지</param>
    public void OnExtraDamage(int damage)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(damage, transform);
        StartCoroutine(HitMaterial());
        Hp -= damage;

        Poolable fx = Managers.Pool.Pop(Managers.Object.TouchAttackFx);
        fx.Spawn(transform);

        Debug.Log(Hp);
    }



    public void EnemySlow(int stack=1)
    {
        _speedDownStack+=stack;
        CurrentSpeedDownTimer = 0.0f;
        _agent.speed =_agent.speed- _speedDownPoint*stack;
    }

    IEnumerator HitMaterial()
    {
        _skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _skinnedMeshRenderer.material.color = Color.white;
    }

    public void OutLineOn()
    {
        _skinnedMeshRenderer.gameObject.layer = 7;
    }

    public void OutLineOff() {
        _skinnedMeshRenderer.gameObject.layer = LayerMask.GetMask("Default");

    }
    


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _multiHitRange);
    }
#endif
}
