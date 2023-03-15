using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveLightningFx : Poolable
{
    ParticleSystem _particle;

    WaitForSeconds _duration;
    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _duration = new WaitForSeconds(_particle.main.duration);
    }

    public override void Spawn(Transform spawnTransform)
    {
        transform.position = spawnTransform.position + Vector3.up;


        StartCoroutine(DeSpawn());
    }

    IEnumerator DeSpawn()
    {
        _particle.Play();
        yield return _duration;
        Managers.Pool.Push(this);
    }
}
