using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Skel : EnemyBase
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
        _agent.ResetPath();
        _animator.SetTrigger("Die");
        _collider.enabled = false;

        StartCoroutine(ReturnSkel());
    }

    public override void Spawn(Transform t)
    {
        Skel skel = null;
        Managers.Data.SkelDict.TryGetValue(1, out skel);

        _level = skel.level;
        _maxHp = skel.maxHp;
        Hp = skel.maxHp;
        _agent.speed = skel.speed;
        _exp = skel.exp;

        _state = EnemyState.Chase;
        _collider.enabled = true;
        transform.position = t.position;

        if (Managers.Object.MyPlayer != null)
        {
            _target = Managers.Object.MyPlayer.transform;
            _agent.SetDestination(_target.transform.position);
            _animator.SetBool("Walk", true);
        }
    }

    IEnumerator ReturnSkel()
    {
        yield return dieTimer;

        Managers.Pool.Push(this);

    }

}
