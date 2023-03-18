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
    SkillBuff,
    PassiveExp,
    PassiveDefence,
    PassiveFire,
    PassiveThunder,
    SpeedGame,
    PowerSkillAttack,
    ThunderArrow,
    WaringDragon,
    DefenceFire,
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

public enum SpawnerType
{
    Nomal=0,
    Defence,
    Speed
}

public enum BossType
{
    Snake=0,
    SnakeBuff,
    Wolf,
    WolfBuff,
    Bloom,
    BloomBuff,
    Reaper
}

public enum BossRewardOption
{
    None=0,
    SwordWind,
    SwordPartner,
    SwordTheTogether,
    AxeHeavy,
    AxeArrow,
    Axefrenzy,
    HammerStun,
    HammerExtraAttack,
    HammerFixed,
    StickNoTouch,
    StickRandomSkill,
    StickSkillPlus,
    HeavyPower,
    PartnerPass,
    SkillWizad,
    ThaHard,
    StaminaUp,
    TheSpeed,
    FixedUp,
    ExpUP
}