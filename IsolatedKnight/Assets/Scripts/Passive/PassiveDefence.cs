using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PassiveDefence : MonoBehaviour
{
    float _currentAttackTimer = 0.0f;
    float _attackSpeed = 2.0f;

    float _attackRange = 12.0f;

    ParticleSystem _defenceFx;
    

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
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
        _defenceFx=GetComponentInChildren<ParticleSystem>();
        _defenceFx.Stop();

    }

    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentAttackTimer < AttackSpeed)
            {
                CurrentAttackTimer += Time.deltaTime;

            }
        }
    }

    void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {


            _defenceFx.Play();
            int totalDamage = Managers.Object.MyPlayer.Defence+Managers.GameManager.ExtraPassiveDefenceDamage;

            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyBase e = colliders[i].GetComponent<EnemyBase>();
                e.OnFixedDamage(totalDamage,DamageType.PassiveDefence);

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
        _defenceFx.Stop();

    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }


}
