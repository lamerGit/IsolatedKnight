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
                if (_min == 1)
                {
                    int bossTypeCount=System.Enum.GetValues(typeof(BossType)).Length;
                    //int r=Random.Range(0, bossTypeCount);
                    int r = 1;

                    switch ((BossType)r)
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
                            break;
                        case BossType.WolfBuff:
                            break;
                        case BossType.Bloom:
                            break;
                        case BossType.BloomBuff:
                            break;
                        case BossType.Reaper:
                            break;
                    }

                    
                }
            }

            _timerText.text = string.Format("{0:D2}:{1:D2}", _min, (int)_sec);


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
            Sec += Time.deltaTime*5.0f;
        }
    }
}
