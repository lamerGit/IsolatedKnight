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

    protected WaitForSeconds SpeedDownTimer = new WaitForSeconds(1.0f);

 

    SkinnedMeshRenderer _skinnedMeshRenderer;

    float _multiHitRange = 3.0f;

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

    public void OnTouchDamage(int damage)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(damage, transform);
        StartCoroutine(HitMaterial());
        Hp-=damage;
        Debug.Log(Hp);
        if(Managers.GameManager.TouchTier2SpeedDown)
        {
            StartCoroutine(TouchTier2SpeedDown());
        }

        if(Managers.GameManager.TouchTier2MultiHit)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _multiHitRange, LayerMask.GetMask("Enemy"));
            if(colliders.Length > 0)
            {

                for(int i=0; i<colliders.Length; i++)
                {
                    if (colliders[i].gameObject!=transform.gameObject)
                    {
                        colliders[i].GetComponent<EnemyBase>().OnMultiDamage(damage);
                    }
                }
            }
        }
    }

    void OnMultiDamage(int damage)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.DamageTextSpawn(damage, transform);
        StartCoroutine(HitMaterial());
        Hp -= damage;
        Debug.Log(Hp);
    }

    IEnumerator TouchTier2SpeedDown()
    {
        _agent.speed = _agent.speed - 0.2f;
        yield return SpeedDownTimer;
        _agent.speed = _agent.speed + 0.2f;
    }

    IEnumerator HitMaterial()
    {
        _skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _skinnedMeshRenderer.material.color = Color.white;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, _multiHitRange);
    }
#endif
}
