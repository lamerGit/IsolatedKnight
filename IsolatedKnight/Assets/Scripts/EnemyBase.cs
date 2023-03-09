using System.Collections;
using System.Collections.Generic;
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

    public void OnDamage(int damage)
    {
        Hp-=damage;
        Debug.Log(Hp);
    }
}
