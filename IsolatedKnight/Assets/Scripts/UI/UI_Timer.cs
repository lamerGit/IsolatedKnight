using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    TextMeshProUGUI _timerText;
    float _sec = 0.0f;
    int _min=0;
    float Sec
    {
        get { return _sec; }
        set {
            _sec = value;

            
            if(_sec>59.0f)
            {
                _sec = 0.0f;
                _min++;
                Managers.GameManager.GameLevel = _min;

                switch(_min)
                {
                    case 2:
                        Managers.Object.EnemySpawnerGroup.OnDefence();
                    break;
                    case 3:
                        List<BossType> list = new List<BossType>();
                        list.Add(BossType.Snake);
                        list.Add(BossType.Wolf);
                        list.Add(BossType.Bloom);
                        for (int i = list.Count - 1; i > -1; i--)
                        {
                            int randIndex = Random.Range(0, i+1);

                            (list[randIndex], list[i]) = (list[i], list[randIndex]);

                        }
                        BossSpawn(list[0]);

                        break;
                    case 4:
                        Managers.Object.EnemySpawnerGroup.OnSpeed();
                        break;
                    case 6:
                        List<BossType> listBuff = new List<BossType>();
                        listBuff.Add(BossType.SnakeBuff);
                        listBuff.Add(BossType.WolfBuff);
                        listBuff.Add(BossType.BloomBuff);
                        for (int i = listBuff.Count - 1; i > -1; i--)
                        {
                            int randIndex = Random.Range(0, i+1);

                            (listBuff[randIndex], listBuff[i]) = (listBuff[i], listBuff[randIndex]);

                        }
                        BossSpawn(listBuff[0]);
                        break;
                    case 7:
                        Managers.Object.EnemySpawnerGroup.OnKnight();
                        break;
                    case 9:
                        BossSpawn(BossType.Reaper);
                        break;

                }


            }

            _timerText.text = string.Format("{0:D2}:{1:D2}", _min, (int)_sec);


        }
    }

    private void BossSpawn(BossType r)
    {
        switch (r)
        {
            case BossType.Snake:
                Poolable snake = Managers.Pool.Pop(Managers.Object.BossSnake);
                snake.BossSpawn(Managers.Object.BossZone.transform, BossType.Snake);
                break;
            case BossType.SnakeBuff:
                Poolable snakeBuff = Managers.Pool.Pop(Managers.Object.BossSnakeBuff);
                snakeBuff.BossSpawn(Managers.Object.BossZone.transform, BossType.SnakeBuff);
                break;
            case BossType.Wolf:
                Poolable wolf = Managers.Pool.Pop(Managers.Object.BossWolf);
                wolf.BossSpawn(Managers.Object.BossZone.transform, BossType.Wolf);
                break;
            case BossType.WolfBuff:
                Poolable wolfBuff = Managers.Pool.Pop(Managers.Object.BossWolfBuff);
                wolfBuff.BossSpawn(Managers.Object.BossZone.transform, BossType.WolfBuff);
                break;
            case BossType.Bloom:
                Poolable bloom = Managers.Pool.Pop(Managers.Object.BossBloom);
                bloom.BossSpawn(Managers.Object.BossZone2.transform, BossType.Bloom);
                break;
            case BossType.BloomBuff:
                Poolable bloomBuff = Managers.Pool.Pop(Managers.Object.BossBloomBuff);
                bloomBuff.BossSpawn(Managers.Object.BossZone2.transform, BossType.BloomBuff);
                break;
            case BossType.Reaper:
                Poolable reaper = Managers.Pool.Pop(Managers.Object.BossReaper);
                reaper.BossSpawn(Managers.Object.BossZone2.transform, BossType.Reaper);
                break;
        }
    }

    private void Awake()
    {
        _timerText=GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Managers.GameManager.State == GameState.Nomal && _min<10)
        {
            Sec += Time.deltaTime;
        }
    }
}
