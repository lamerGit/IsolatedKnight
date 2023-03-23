using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Speed : EnemyBase
{
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

    private void Die()
    {
        _state = EnemyState.Die;
        //_agent.ResetPath();
        _agent.enabled = false;
        _animator.SetTrigger("Die");
        _collider.enabled = false;

        Managers.Object.MyPlayer.ExpUp(_exp);

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

    public override void Spawn(Transform t)
    {
        transform.position = t.position;
        _agent.enabled = true;
        // Json 데이터 파싱
        SkelSpeed skelSpeed = null;
        Managers.Data.SkelSpeedDict.TryGetValue(Managers.GameManager.GameLevel, out skelSpeed);

        _level = skelSpeed.level;
        _maxHp = skelSpeed.maxHp;
        Hp = skelSpeed.maxHp;
        _agent.speed = skelSpeed.speed + Managers.GameManager.ExtraEnemySpeed;
        _exp = skelSpeed.exp;

        _state = EnemyState.Chase;
        _collider.enabled = true;
        

        if (Managers.Object.MyPlayer != null)
        {
            _target = Managers.Object.MyPlayer.transform;
            _agent.SetDestination(_target.transform.position);
            _animator.SetBool("Walk", true);
        }

        // 상태이상 스택 초기화
        _skinnedMeshRenderer.material.color = Color.white;
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
}
