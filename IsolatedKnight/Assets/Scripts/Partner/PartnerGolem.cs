using Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PartnerGolem : MonoBehaviour
{
    float _currentAttackTimer = 0.0f;
    float _attackSpeed = 6.0f;
    int _attackDamage = 15;

    float _attackRange = 60.0f;

    Animator _animator;

    public Transform _hand;

    float _bulletSpeed = 20.0f;

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
        _hand = transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R/Shoulder_R/Elbow_R/Hand_R");
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
            for (int i = 0; i < 1; i++)
            {
                int r=Random.Range(0, colliders.Length);

                transform.LookAt(colliders[r].gameObject.transform.position);
                _animator.SetTrigger("Attack");

                Poolable bullet = Managers.Pool.Pop(Managers.Object.GolemRock);

                bullet.transform.position = _hand.transform.position;
                bullet.Spawn(_hand);

                Vector3 dir = (colliders[r].transform.position - _hand.transform.position).normalized;
                GolemRock component = bullet.GetComponent<GolemRock>();

                dir.y += 0.01f;
                component.Rigid.velocity = dir * _bulletSpeed;

                component.Damage = AttackDamge+Managers.GameManager.ExtraGolemDamage;
                component.Dir = dir;
                component.Speed = _bulletSpeed;


                Debug.Log("АјАн");
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
        Managers.Data.PartnerDict.TryGetValue((int)PartnerType.Golem, out partner);


        AttackSpeed = partner.attackSpeed;
        AttackDamge = partner.attackDamage;

        Debug.Log(AttackSpeed);
        Debug.Log(AttackDamge);
    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }
}
