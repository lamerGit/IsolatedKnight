using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Snake : EnemyBase
{

    float _skillCoolTime;
    float _skillRecovery;

    List<Transform> _path;
    int _currentPathIndex = 0;
    int _pathMaxIndex = 6;
    int _nextPathIndex = 0;


    float _currentSkillCoolTime = 0.0f;

    float CurrentSkillCoolTime
    {
        get { return _currentSkillCoolTime; }
        set
        {
            _currentSkillCoolTime = Mathf.Clamp(value, 0.0f, _skillCoolTime);
            if (_currentSkillCoolTime == _skillCoolTime)
            {
                _animator.SetTrigger("Skill");
                StateClean();
                _agent.isStopped = true;
                _agent.speed = _agent.speed + 0.5f;
                _currentSkillCoolTime = 0.0f;
            }



        }
    }

    int CurrentPathIndex
    {
        get { return _currentPathIndex; }
        set { _currentPathIndex=Mathf.Clamp(value, 0, _pathMaxIndex-1);

            _agent.SetDestination(_path[_currentPathIndex].transform.position);
            _nextPathIndex = _currentPathIndex+1;
        }
    }


    protected override int Hp
    {
        get => base.Hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, _maxHp);
            if (_hp == 0)
            {
                Die();
            }



        }
    }

    protected override void Update()
    {
        base.Update();

        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (_agent.remainingDistance < 1.0f && CurrentPathIndex < _pathMaxIndex - 1)
            {
                CurrentPathIndex=_nextPathIndex;
                //Debug.Log(CurrentPathIndex);
            }

            if(CurrentSkillCoolTime<_skillCoolTime && _state==EnemyState.Chase)
            {
                CurrentSkillCoolTime += Time.deltaTime * _skillRecovery;
            }

            if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Skill") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.9f)
            {
                _agent.isStopped = false;
            }
        }

    }

    protected override void StateChange()
    {
        if (!gameObject.activeSelf)
            return;
        if (!_agent.enabled) return;

        switch (Managers.GameManager.State)
        {
            case GameState.Nomal:
                if (_state == EnemyState.Chase)
                {
                    _agent.isStopped = false;
                }
                break;
            case GameState.LevelUp:
                _agent.isStopped = true;
                break;
            case GameState.PlayerDie:
                _agent.isStopped = true;
                break;
        }

    }

    private void Die()
    {
        if (_state == EnemyState.Die)
            return;

        _state = EnemyState.Die;
        //_agent.ResetPath();
        _agent.enabled = false;
        _animator.SetTrigger("Die");
        _collider.enabled = false;

        Managers.Object.MyPlayer.ExpUp(_exp);
        Managers.GameManager.State = GameState.LevelUp;
        Managers.GameManager.BossRewardStack++;
        Managers.UIManager.BossRewardButtonGroup.Open();

        if (Managers.GameManager.SynergyDefenceFireTier1FireTrans && _fireStack > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _fireTranRange, LayerMask.GetMask("Enemy"));
            if (colliders.Length > 0)
            {

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != transform.gameObject)
                    {
                        colliders[i].GetComponent<EnemyBase>().EnemyFire();
                    }
                }
            }
        }

        StartCoroutine(ReturnSkel());
    }

    public override void BossSpawn(Transform t,BossType bossType)
    {
        transform.position = t.position;
        _agent.enabled = true;
        // Json 데이터 파싱
        Boss boss = null;
        Managers.Data.BossDict.TryGetValue((int)bossType, out boss);

        _maxHp = boss.maxHp;
        Hp = boss.maxHp;
        _agent.speed = boss.speed + Managers.GameManager.ExtraEnemySpeed;
        _exp = boss.exp;
        _skillCoolTime = boss.skillCoolTime;
        _skillRecovery=boss.skillRecovery;

        _state = EnemyState.Chase;
        _collider.enabled = true;


        Transform[] point=Managers.Object.SnakePath.GetComponentsInChildren<Transform>();
        _path = new List<Transform>();

        for(int i=0; i<point.Length; i++)
        {
            if (point[i]!=Managers.Object.SnakePath.transform)
            {
                _path.Add(point[i]);
            }
        }
        

        _pathMaxIndex= _path.Count;
        _target = Managers.Object.MyPlayer.transform;
        _agent.SetDestination(_path[CurrentPathIndex].transform.position);
        _animator.SetBool("Walk", true);
        CurrentPathIndex++;
        _nextPathIndex = CurrentPathIndex;


        // 상태이상 스택 초기화
        _skinnedMeshRenderer.material.color = Color.white;
        _speedDownStack = 0;
        _fireStack = 0;
        CurrentFireTick = 0;
        _stateFireFx.Stop();



    }

    IEnumerator ReturnSkel()
    {
        yield return dieTimer;

        Managers.Pool.Push(this);

    }
}
