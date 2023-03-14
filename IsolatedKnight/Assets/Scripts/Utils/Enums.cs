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
    TouchBuff,
    PartnerDragon,
    PartnerGolem,
    PartnerGost,
    PartnerBuff,
    SkillOnePoint,
    SkillMultiPoint,
    SkillTouchBuff,
    SkillBuff
}

public enum PartnerType
{
    Dragon=0,
    Golem,
    Gost
}

public enum SkillType
{
    None=0,
    OnePoint,
    MultiPoint,
    TouchBuff,
    Buff
}