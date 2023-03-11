using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    


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
        Poolable temp = Managers.Pool.Pop(Managers.Object.Skel);
        temp.Spawn(transform);
    }

}
