using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public SpawnerType _type=SpawnerType.Nomal;

    float _currentSkelSpawnTimer = 0.0f;
    float _skelSpawnTime = 3.0f;
    
    float CurrentSkelSpawnTimer
    {
        get { return _currentSkelSpawnTimer; }

        set
        {
            _currentSkelSpawnTimer = Mathf.Clamp(value, 0.0f, _skelSpawnTime);
            
            if(_currentSkelSpawnTimer>=_skelSpawnTime)
            {
                SkelSpawn();
                _currentSkelSpawnTimer=0.0f;
            }
        }
    }


    private void Update()
    {
        if(CurrentSkelSpawnTimer<_skelSpawnTime && Managers.GameManager.State==GameState.Nomal)
        {
            CurrentSkelSpawnTimer+= Time.deltaTime;
        }
    }

    void SkelSpawn()
    {
        switch (_type)
        {
            case SpawnerType.Nomal:
                Poolable tempNomal = Managers.Pool.Pop(Managers.Object.Skel);
                tempNomal.Spawn(transform);
                break;
            case SpawnerType.Defence:
                Poolable tempDefence = Managers.Pool.Pop(Managers.Object.SkelDefence);
                tempDefence.Spawn(transform);
                break;
            case SpawnerType.Speed:
                Poolable tempSpeed = Managers.Pool.Pop(Managers.Object.SkelSpeed);
                tempSpeed.Spawn(transform);
                break;
            case SpawnerType.Knight:
                Poolable tempKnight = Managers.Pool.Pop(Managers.Object.SkelKnight);
                tempKnight.Spawn(transform);
                break;
        }


    }

}
