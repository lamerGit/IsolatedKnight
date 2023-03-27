using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss_Bloom : EnemyBase
{
    float _skillCoolTime;
    float _skillRecovery;

    

    float _currentSkillCoolTime = 0.0f;

    float _bulletSpeed = 5.0f;

    BossType _type;

    AudioSource _spawnAudio;

    float SkillRecovery
    {
        get { return _skillRecovery; }
        set { _skillRecovery = Mathf.Clamp( value,0.0f, _skillCoolTime); }
    }

    float CurrentSkillCoolTime
    {
        get { return _currentSkillCoolTime; }
        set
        {
            _currentSkillCoolTime = Mathf.Clamp(value, 0.0f, _skillCoolTime);
            if (_currentSkillCoolTime == _skillCoolTime)
            {
                _myAudio.Play();
                _animator.SetTrigger("Skill");
                if (_type == BossType.Bloom)
                {
                    BulletAttack(Vector3.left);
                    BulletAttack(Vector3.right);
                }
                else if (_type == BossType.BloomBuff)
                {
                    BulletAttack(Vector3.left);
                    BulletAttack(Vector3.right);
                    BulletAttack(Vector3.forward);
                }


                _agent.isStopped = true;
                SkillRecovery += 1.0f;
                _currentSkillCoolTime = 0.0f;
            }



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

        _spawnAudio=transform.Find("SpawnSound").GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();

        if (Managers.GameManager.State == GameState.Nomal)
        {
            

            if (CurrentSkillCoolTime < _skillCoolTime && _state == EnemyState.Chase)
            {
                CurrentSkillCoolTime += Time.deltaTime * SkillRecovery;
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Skill") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
               
                _agent.isStopped = false;
                _agent.speed = 0.0f;
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
        Managers.Object.MyPlayer.GoldUp(100);

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

    public override void BossSpawn(Transform t, BossType bossType)
    {
        transform.position = t.position;
        _agent.enabled = true;
        // Json 데이터 파싱
        Boss boss = null;
        Managers.Data.BossDict.TryGetValue((int)bossType, out boss);
        _type = bossType;

        _maxHp = boss.maxHp;
        Hp = boss.maxHp;
        //_agent.speed = boss.speed + Managers.GameManager.ExtraEnemySpeed;
        _agent.speed = boss.speed;
        _exp = boss.exp;
        _skillCoolTime = boss.skillCoolTime;
        SkillRecovery = boss.skillRecovery;

        _state = EnemyState.Chase;
        _collider.enabled = true;




        _target = Managers.Object.MyPlayer.transform;
        _agent.SetDestination(_target.transform.position);
        //_animator.SetBool("Walk", true);
        


        // 상태이상 스택 초기화
        _skinnedMeshRenderer.material.color = Color.white;
        _speedDownStack = 0;
        _fireStack = 0;
        CurrentFireTick = 0;
        _stateFireFx.Stop();

        _spawnAudio.Play();


    }

    void BulletAttack(Vector3 pos)
    {
        Poolable bullet = Managers.Pool.Pop(Managers.Object.BloomBullet);

        bullet.transform.position = transform.position + Vector3.up*2.0f+pos ;
        bullet.BossSpawn(transform,_type);

        Vector3 dir = transform.forward;

        BloomBullet component = bullet.GetComponent<BloomBullet>();

        
        component.Rigid.velocity = dir * _bulletSpeed;

 
        component.Dir = dir;
        component.Speed = _bulletSpeed;

        if (Managers.GameManager.State == GameState.LevelUp)
        {
            component.Rigid.velocity = Vector3.zero;

        }
    }

    IEnumerator ReturnSkel()
    {
        yield return dieTimer;

        Managers.Pool.Push(this);

    }
}
