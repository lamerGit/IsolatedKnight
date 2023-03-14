using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : Poolable
{
    TextMeshPro _text;
    WaitForSeconds _despawnTimer = new WaitForSeconds(1.0f);

    float _randomSpeed;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshPro>();
        _randomSpeed = Random.Range(1.0f, 3.0f);
    }

    private void Update()
    {
        transform.position += Vector3.up*Time.deltaTime*_randomSpeed;
    }

    public override void DamageTextSpawn(int damage, Transform spawnTransform)
    {
        transform.position = spawnTransform.position;

        _text.text = $"{damage}";

        StartCoroutine(DeSpawnText());
    }

    IEnumerator DeSpawnText()
    {
        yield return _despawnTimer;

        Managers.Pool.Push(this);

    }
}
