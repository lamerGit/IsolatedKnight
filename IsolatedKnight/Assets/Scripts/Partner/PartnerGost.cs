using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerGost : MonoBehaviour
{
    float _currentAttackTimer = 0.0f;
    float _attackSpeed = 2.0f;
    int _attackDamage = 3;

    float _attackRange = 5.0f;

    Animator _animator;

    float _attackSpeedTick = 1.0f;

    AudioSource _audioSoruce;
    float AttackSpeedTick
    {
        get { return _attackSpeedTick + Managers.GameManager.ExtraPartnerAttackSpeedTick; }
        set { _attackSpeedTick = value; }
    }
    public int AttackDamge
    {
        get { return _attackDamage; }
        private set { _attackDamage = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        private set { _attackSpeed = value; }
    }

    public float CurrentAttackTimer
    {
        get { return _currentAttackTimer; }
        set
        {
            _currentAttackTimer = Mathf.Clamp(value, 0.0f, AttackSpeed);

            if (_currentAttackTimer == AttackSpeed)
            {
                Attack();
            }

        }
    }



    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSoruce = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentAttackTimer < AttackSpeed)
            {
                CurrentAttackTimer += Time.deltaTime* AttackSpeedTick;

            }
        }
    }

    void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            if (Managers.GameManager.PartnerAndMeteorTier1MeteorOn)
            {
                Managers.Object.MyPlayer.MeteorCount++;
            }

            _audioSoruce.Play();
            _animator.SetTrigger("Attack");
            Poolable p = Managers.Pool.Pop(Managers.Object.GostAttackFx);
            p.Spawn(transform);
            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyBase e = colliders[i].GetComponent<EnemyBase>();
                e.EnemySlow(stack:3);
                if (Managers.GameManager.PartnerGostTier2Damage)
                {
                    e.OnPartnerDamage(AttackDamge,DamageType.PartnerGost);
                }
                if(Managers.GameManager.PartnerGostTier3Slow)
                {
                    e.EnemySlow(stack: 6);
                }

            }
            CurrentAttackTimer = 0.0f;

        }
        else
        {
            CurrentAttackTimer = AttackSpeed - 0.1f;


        }


    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        Partner partner = null;
        Managers.Data.PartnerDict.TryGetValue((int)PartnerType.Gost, out partner);


        AttackSpeed = partner.attackSpeed;
        AttackDamge = partner.attackDamage;

        //Debug.Log(AttackSpeed);
        //Debug.Log(AttackDamge);
    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }
}
