using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GolemRock : Poolable
{
    int _damage;
    Vector3 _dir;
    float _speed;

    float _currentDeSpawnTimer = 0.0f;
    float _deSpawnTimer = 3.0f;

    int _count = 3;

    float _billiaRange = 10.0f;
    float _explosionRange = 3.0f;

    float CurrentDeSpawnTimer
    {
        get { return _currentDeSpawnTimer; }
        set
        {
            _currentDeSpawnTimer = Mathf.Clamp(value, 0.0f, _deSpawnTimer);
            if (_currentDeSpawnTimer == _deSpawnTimer)
            {
                CurrentDeSpawnTimer = 0.0f;
                Managers.Pool.Push(this);
            }

        }
    }

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
        get;
        private set;
    } = null;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();

        Managers.GameManager.StateChange += StateChange;
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentDeSpawnTimer < _deSpawnTimer)
            {
                CurrentDeSpawnTimer += Time.deltaTime;
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
                Rigid.velocity = Dir * Speed;
                break;
            case GameState.LevelUp:
                Rigid.velocity = Vector3.zero;
                break;
            case GameState.PlayerDie:
                Rigid.velocity = Vector3.zero;
                break;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && Managers.GameManager.State == GameState.Nomal)
        {
            
            other.GetComponent<EnemyBase>().OnPartnerDamage(Damage, DamageType.PartnerGolem);
            _count--;

            if (_count > 0)
            {

                if (Managers.GameManager.PartnerGolemTier2Billia)
                {

                    Collider[] colliders = Physics.OverlapSphere(transform.position, _billiaRange, LayerMask.GetMask("Enemy"));

                    if (colliders.Length > 1)
                    {
                        for (int i = 0; i < colliders.Length; i++)
                        {

                            if (colliders[i].gameObject != other.gameObject)
                            {
                                Vector3 dir = (colliders[i].transform.position - transform.position).normalized;
                                dir.y += 0.1f;
                               
                                Rigid.velocity = dir * Speed;
                                CurrentDeSpawnTimer = 0.0f;
                                Dir=dir;

                                // 순서문제로 여기서도 체크해야함
                                if (Managers.GameManager.State == GameState.LevelUp)
                                    Rigid.velocity = Vector3.zero;
                            }

                        }

                    }else
                    {
                        Explosion();
                    }

                }
            }else
            {
                Explosion();
            }


        }
    }

    private void Explosion()
    {
        if (Managers.GameManager.PartnerGolemTier3Explosion)
        {
            Poolable explosion = Managers.Pool.Pop(Managers.Object.RockExplosion);
            explosion.Spawn(transform);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRange, LayerMask.GetMask("Enemy"));
            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].GetComponent<EnemyBase>().OnPartnerDamage(Damage,DamageType.PartnerGolem);
                }
            }

        }

        CurrentDeSpawnTimer = 0.0f;
        Managers.Pool.Push(this);
    }

    public override void Spawn(Transform spawnTransform)
    {
        CurrentDeSpawnTimer = 0.0f;
        if (Managers.GameManager.PartnerGolemTier2Billia)
        {
            _count = 3;
        }else
        {
            _count = 0;
        }

    }
}
