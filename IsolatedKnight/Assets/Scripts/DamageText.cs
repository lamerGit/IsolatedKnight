using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : Poolable
{
    TextMeshPro _text;
    WaitForSeconds _despawnTimer = new WaitForSeconds(1.0f);

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        transform.position += Vector3.up*Time.deltaTime;
    }

    public override void DamageTextSpawn(int damage, Transform spawnTransform)
    {
        transform.position = spawnTransform.position;

        _text.text = damage.ToString();

        StartCoroutine(DeSpawnText());
    }

    IEnumerator DeSpawnText()
    {
        yield return _despawnTimer;

        Managers.Pool.Push(this);

    }
}
