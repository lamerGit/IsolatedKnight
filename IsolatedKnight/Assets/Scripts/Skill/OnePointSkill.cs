using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePointSkill : Poolable
{
    int _damage;
    Vector3 _dir;
    float _speed;

    float _currentDeSpawnTimer = 0.0f;
    float _deSpawnTimer = 3.0f;

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

            EnemyBase e = other.GetComponent<EnemyBase>();

            e.OnSkillDamge(Damage,DamageType.SkillOnePoint);

            if(Managers.GameManager.OnePointSkillTier3HpAttack)
            {
                int extraDamage = (int)(e.GetMaxHp() * 0.1f);
                e.OnExtraSkillDamage(extraDamage,DamageType.SkillOnePoint);
            }

            

        }
    }

    public override void Spawn(Transform spawnTransform)
    {
        CurrentDeSpawnTimer = 0.0f;
    }
}
