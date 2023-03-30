using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PartnerMeteor : MonoBehaviour
{

    int _attackDamage = 3;

    float _attackRange = 10.0f;

   
    AudioSource _audioSoruce;
    ParticleSystem _particleSystem;
    
    public int AttackDamge
    {
        get { return _attackDamage; }
        private set { _attackDamage = value; }
    }


    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSoruce = GetComponent<AudioSource>();
    }


    public void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            _audioSoruce.Play();
            _particleSystem.Play();
            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyBase e = colliders[i].GetComponent<EnemyBase>();
                e.OnPartnerDamage(AttackDamge, DamageType.Meteor);
                
                if(Managers.GameManager.PartnerAndMeteorTier2MeteorSlow)
                {
                    e.EnemySlow(stack: 10);
                }

                if(Managers.GameManager.PartnerAndMeteorTier3MeteorFire)
                {
                    e.EnemyFire();
                    e.EnemyFire();
                    e.EnemyFire();
                    e.EnemyFire();
                    e.EnemyFire();
                }

            }
            
        }
        


    }

    public void Spawn()
    {
        gameObject.SetActive(true);

        AttackDamge = Managers.Object.MyPlayer.Meteor;

        Attack();

    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }

}
