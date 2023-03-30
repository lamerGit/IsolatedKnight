using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss_Reaper : EnemyBase
{
    AudioSource _dieAudioSource;

    AudioSource _spawnAudio;

    float _skillCoolTime;
    float _skillRecovery;

    List<Transform> _path;
    int _currentPathIndex = 1;
    int _pathMaxIndex = 6;

    WaitForSeconds _reaperDieTimer=new WaitForSeconds(3.0f);
    WaitForSeconds _blackOutTimer = new WaitForSeconds(0.3f);

    float _currentSkillCoolTime = 0.0f;

    float CurrentSkillCoolTime
    {
        get { return _currentSkillCoolTime; }
        set
        {
            _currentSkillCoolTime = Mathf.Clamp(value, 0.0f, _skillCoolTime);
            if (_currentSkillCoolTime == _skillCoolTime)
            {

                Managers.UIManager.BlackOutUI.SetActive(true);
                StateClean();
                _agent.isStopped = true;
                _agent.enabled = false;
                transform.position = _path[CurrentPathIndex].position;
                
                CurrentPathIndex++;
                _currentSkillCoolTime = 0.0f;

                _spawnAudio.Play();

                StartCoroutine(BlackOutOn());
            }



        }
    }

    int CurrentPathIndex
    {
        get { return _currentPathIndex; }
        set
        {
            _currentPathIndex = Mathf.Clamp(value, 0, _pathMaxIndex - 1);
            
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

    protected override void Awake()
    {
        base.Awake();

        _dieAudioSource=transform.Find("RepaerDieSound").GetComponent<AudioSource>();

        _spawnAudio = transform.Find("SpawnSound").GetComponent<AudioSource>();
    }
    protected override void Update()
    {
        base.Update();

        if (Managers.GameManager.State == GameState.Nomal)
        {
           

            if (CurrentSkillCoolTime < _skillCoolTime && _state == EnemyState.Chase)
            {
                CurrentSkillCoolTime += Time.deltaTime * _skillRecovery;
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

        BackGroundSound.Instance.BackGroundStop();
        Managers.Object.MyPlayer.GoldUp(1000);
        _dieAudioSource.Play();
        _state = EnemyState.Die;
        //_agent.ResetPath();
        _agent.enabled = false;
        _animator.SetTrigger("Die");
        _collider.enabled = false;


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

        Managers.GameManager.State = GameState.PlayerDie;
        Managers.UIManager.GameSetUI.Open(true);

        StartCoroutine(ReturnSkel());
    }

    public override void BossSpawn(Transform t, BossType bossType)
    {
        transform.position = t.position;
        _agent.enabled = true;
        // Json 데이터 파싱
        Boss boss = null;
        Managers.Data.BossDict.TryGetValue((int)bossType, out boss);

        _maxHp = boss.maxHp;
        Hp = boss.maxHp;
        _maxSpeed = boss.speed;
        BaseSpeed = _maxSpeed;
        _exp = boss.exp;
        _skillCoolTime = boss.skillCoolTime;
        _skillRecovery = boss.skillRecovery;

        _state = EnemyState.Chase;
        _collider.enabled = true;


        Transform[] point = Managers.Object.ReaperPath.GetComponentsInChildren<Transform>();
        _path = new List<Transform>();

        for (int i = 0; i < point.Length; i++)
        {
            if (point[i] != Managers.Object.SnakePath.transform)
            {
                _path.Add(point[i]);
            }
        }


        _pathMaxIndex = _path.Count;
        _target = Managers.Object.MyPlayer.transform;

        Managers.UIManager.BlackOutUI.SetActive(true);
        StartCoroutine(BlackOutOn());


        // 상태이상 스택 초기화
        _skinnedMeshRenderer.material.color = Color.white;
        _speedDownStack = 0;
        _fireStack = 0;
        CurrentFireTick = 0;
        StateClean();
        _stateFireFx.Stop();

        _spawnAudio.Play();

    }

    IEnumerator BlackOutOn()
    {
        yield return _blackOutTimer;
        _agent.enabled = true;
        Managers.UIManager.BlackOutUI.SetActive(false);
    }
    IEnumerator ReturnSkel()
    {
        yield return _reaperDieTimer;

        Managers.Pool.Push(this);

    }
}
