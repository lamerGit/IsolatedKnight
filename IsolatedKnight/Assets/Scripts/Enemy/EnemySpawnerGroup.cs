using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGroup : MonoBehaviour
{
    GameObject _nomal;
    GameObject _defence;
    GameObject _speed;
    GameObject _knight;

    EnemySpawner[] _nomalSpawnerGroup;
    EnemySpawner[] _defenceSpawnerGroup;
    EnemySpawner[] _speedSpawnerGroup;
    EnemySpawner[] _knightSpawnerGroup;

    private void Awake()
    {
        _nomal = transform.Find("Spawner_Nomal").gameObject;
        _defence = transform.Find("Spawner_Defence").gameObject;
        _speed = transform.Find("Spawner_Speed").gameObject;
        _knight = transform.Find("Spawner_Knight").gameObject;

        _nomalSpawnerGroup = _nomal.GetComponentsInChildren<EnemySpawner>();
        _defenceSpawnerGroup = _defence.GetComponentsInChildren<EnemySpawner>();
        _speedSpawnerGroup = _speed.GetComponentsInChildren<EnemySpawner>();
        _knightSpawnerGroup = _knight.GetComponentsInChildren<EnemySpawner>();

    }

    public void SpawnerOff()
    {
        _defence.SetActive(false);
        _speed.SetActive(false);
        _knight.SetActive(false);
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
        _knight.SetActive(true);
    }

    public void On1MinWave()
    {
        
        for(int i=0; i<_nomalSpawnerGroup.Length; i++)
        {
            _nomalSpawnerGroup[i].OnWave(10);
        }
    }

    public void On5MinWave()
    {
        
        for (int i = 0; i < _nomalSpawnerGroup.Length; i++)
        {
            _nomalSpawnerGroup[i].OnWave(15);
        }

        for (int i = 0; i < _defenceSpawnerGroup.Length; i++)
        {
            _defenceSpawnerGroup[i].OnWave(15);
        }

        for (int i = 0; i < _speedSpawnerGroup.Length; i++)
        {
            _speedSpawnerGroup[i].OnWave(15);
        }

    }

    public void On8MinWave()
    {
        for (int i = 0; i < _nomalSpawnerGroup.Length; i++)
        {
            _nomalSpawnerGroup[i].OnWave(5);
        }

        for (int i = 0; i < _defenceSpawnerGroup.Length; i++)
        {
            _defenceSpawnerGroup[i].OnWave(5);
        }

        for (int i = 0; i < _speedSpawnerGroup.Length; i++)
        {
            _speedSpawnerGroup[i].OnWave(5);
        }
        for (int i = 0; i < _knightSpawnerGroup.Length; i++)
        {
            _knightSpawnerGroup[i].OnWave(40);
        }
    }
}
