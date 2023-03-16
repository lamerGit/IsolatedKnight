using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PartnerDragon : MonoBehaviour
{
    float _currentAttackTimer = 0.0f;
    float _attackSpeed=3.0f;
    int _attackDamage=5;

    float _attackRange = 60.0f;

    Animator _animator;

    Transform _head;


    float _bulletSpeed = 10.0f;

    float _attackSpeedTick = 1.0f;

    public float AttackSpeedTick
    {
        get { return _attackSpeedTick; }
        set { _attackSpeedTick = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed - Managers.GameManager.ExtraDragonAttackSpeed; }
        private set { _attackSpeed = value; }
    }

    public float CurrentAttackTimer
    {
        get { return _currentAttackTimer; }
        set { _currentAttackTimer = Mathf.Clamp(value,0.0f, AttackSpeed);
        
            if(_currentAttackTimer == AttackSpeed)
            {
                Attack();
            }
        
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _head = transform.Find("RigHeadGizmo");
    }
    private void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal)
        {
            if (CurrentAttackTimer < AttackSpeed)
            {
                CurrentAttackTimer += Time.deltaTime*AttackSpeedTick;

            }
        }
    }

    void Attack()
    {
        Collider[] colliders= Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            for (int i = 0; i < 1; i++)
            {
                transform.LookAt(colliders[i].gameObject.transform.position);
                _animator.SetTrigger("Attack");

                Poolable bullet = Managers.Pool.Pop(Managers.Object.DragonBreath);

                bullet.transform.position=_head.transform.position;
                bullet.Spawn(_head);

                Vector3 dir = (colliders[i].transform.position - _head.transform.position).normalized;
                DragonBreath component= bullet.GetComponent<DragonBreath>();

                //component.Rigid.transform.LookAt(colliders[i].transform.position);
                dir.y += 0.01f;
                component.Rigid.velocity = dir * _bulletSpeed;

                component.Damage = _attackDamage;
                component.Dir = dir;
                component.Speed = _bulletSpeed;

                if(Managers.GameManager.PartnerDragonTier3MultiShot)
                {
                    Poolable left = Managers.Pool.Pop(Managers.Object.DragonBreath);
                    Poolable right = Managers.Pool.Pop(Managers.Object.DragonBreath);

                    left.transform.position = _head.transform.position + Vector3.left;
                    right.transform.position = _head.transform.position + Vector3.forward;

                    left.Spawn(_head);
                    right.Spawn(_head);

                    DragonBreath leftComponent= left.GetComponent<DragonBreath>();
                    DragonBreath rightComponent= right.GetComponent<DragonBreath>();

                    leftComponent.Rigid.velocity = dir * _bulletSpeed;
                    rightComponent.Rigid.velocity = dir * _bulletSpeed;

                    leftComponent.Damage = _attackDamage;
                    rightComponent.Damage = _attackDamage;

                    leftComponent.Dir=dir;
                    rightComponent.Dir = dir;

                    leftComponent.Speed = _bulletSpeed;
                    rightComponent.Speed = _bulletSpeed;

                }


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
        Managers.Data.PartnerDict.TryGetValue((int)PartnerType.Dragon, out partner);


        AttackSpeed = partner.attackSpeed;
        _attackDamage = partner.attackDamage;

        Debug.Log(AttackSpeed);
        Debug.Log(_attackDamage);
    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }

}
