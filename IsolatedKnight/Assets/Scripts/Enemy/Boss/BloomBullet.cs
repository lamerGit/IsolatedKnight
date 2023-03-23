using Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BloomBullet : EnemyBase
{
    Rigidbody _rigid;
    Vector3 _dir;
    float _speed;


    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Vector3 Dir
    {
        get { return _dir; }
        set { _dir = value; }
    }

    public Rigidbody Rigid
    {
        get { return _rigid; }
        private set { _rigid = value; }
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

        Rigid = GetComponent<Rigidbody>();
        _bullet = true;
    }

    protected override void StateChange()
    {
        if (!gameObject.activeSelf)
            return;

        switch (Managers.GameManager.State)
        {
            case GameState.Nomal:
                if (_state == EnemyState.Chase)
                {
                    Rigid.velocity = Dir * Speed;
                }
                break;
            case GameState.LevelUp:
                Rigid.velocity = Vector3.zero;
                break;
            case GameState.PlayerDie:
                Rigid.velocity = Vector3.zero;
                break;
        }

    }

    private void Die()
    {
        _state = EnemyState.Die;
        Rigid.useGravity= true;
        _collider.isTrigger = false;
        gameObject.layer = LayerMask.GetMask("Default");
        gameObject.tag = "Untagged";
        Rigid.velocity = Vector3.zero;

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
        gameObject.tag = "Enemy";
        gameObject.layer = 6;
        _collider.isTrigger = true;

        // Json 데이터 파싱

        Boss boss = null;
        Managers.Data.BossDict.TryGetValue((int)bossType, out boss);

        _maxHp = (int)(boss.maxHp*0.01f);
        Hp = _maxHp;
        //_agent.speed = boss.speed + Managers.GameManager.ExtraEnemySpeed;
        //_exp = boss.exp;

        _state = EnemyState.Chase;
        //_collider.enabled = true;
        Rigid.useGravity = false;

        _target = Managers.Object.MyPlayer.transform;

           
        // 상태이상 스택 초기화
        //_skinnedMeshRenderer.material.color = Color.white;
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

    public override void EnemySlow(int stack = 1)
    {
        //base.EnemySlow(stack);
    }

    protected override IEnumerator HitMaterial()
    {
        yield return null;
    }
}
