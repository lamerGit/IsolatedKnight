using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Idle=0,
    Chase,
    Die
}

public enum GameState
{
    Nomal=0,
    LevelUp,
    PlayerDie

}

public enum LevelUpOption
{
    None=0,
    TouchDamage,
    TouchSpeed,
    Stamina,
    TouchBuff
}