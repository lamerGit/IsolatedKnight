using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGroup : MonoBehaviour
{
    GameObject _nomal;
    GameObject _defence;
    GameObject _speed;
    GameObject _Knight;

    private void Awake()
    {
        _nomal = transform.Find("Spawner_Nomal").gameObject;
        _defence = transform.Find("Spawner_Defence").gameObject;
        _speed = transform.Find("Spawner_Speed").gameObject;
        _Knight = transform.Find("Spawner_Knight").gameObject;
    }

    public void SpawnerOff()
    {
        _defence.SetActive(false);
        _speed.SetActive(false);
        _Knight.SetActive(false);
    }

    public void OnDefence()
    {
        _defence.SetActive(true);
    }

    public void OnSpeed()
    {
        _speed.SetActive(true);
    }

    public void OnKnight()
    {
        _Knight.SetActive(true);
    }
}
