using Data;
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
    PassiveAndIce,
    SkillAndGreenBall,
    TouchAndAutoTouch,
    PartnerAndMeteor,
    GoldUp,
    SynergyFixedUp,
    TouchSkillPartnerUp,
    RandomProjectile
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
    Speed,
    Knight
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
    TheHard,
    StaminaUp,
    TheSpeed,
    FixedUp,
    ExpUP
}

public enum WeaponType
{
    Sword=0,
    Axe,
    Hammer,
    Stick,
    Hand


}

public enum DamageType
{
    Touch=0,
    PartnerDragon,
    PartnerGolem,
    PartnerGost,
    SkillOnePoint,
    SkillMultiPoint,
    PassiveArrow,
    PassiveThunder,
    PassiveFire,
    PassiveDefence,
    SwordWind,
    Ice,
    GreenBall,
    Meteor

}

public enum GameScene
{
    Lobby=0,
    GameScene,
    SwordEnding,
    AxeEnding,
    HammerEnding,
    StickEnding,
    HandEnding
}

public enum LanguageType
{
    us=0,
    kr
}

public enum Language
{
    None = 0,
    CFX,
    BGM,
    Weapon,
    PowerUp,
    Start,
    Swordwindwhentouch,
    Staminarecoverywhentouch,
    Arrowwhentouch,
    Fixeddamagewhentouch,
    Chancetonotskillcooltime,
    Summonandskilldamageupwhenoveload,
    Maxstaminaup,
    Autotouchupgrade,
    Autotouchget,
    Chancetonotstaminaconsum,
    Staminaconsumdown,
    Multiattackwhentouch,
    Slowwhentouch,
    SummonattackSpeedup,
    Dragonattackmultishot,
    Dragonattackpiercing,
    SummonDragon,
    Summonsdealextradamage,
    GhostSlowUp,
    Ghostdodamage,
    Summonghost,
    Golemattackexplosion,
    Golemattackbounce,
    Summongolem,
    skillresetskillget,
    StaminaRecoveryupwhenusingskill,
    Touchspeedupwhenusingskill,
    Touchabilityupskillget,
    HolyshockslowUp,
    Slowwhenholyshockattack,
    Holyshockskillget,
    Enemymaximumhp10persentdamage,
    LightningBallskillget,
    Arrowcountby3,
    Arrowattackwhenexpget,
    ExpUp,
    ShieldattackSpeedUp,
    ShielddamageUp,
    Slowwhenshieldattack,
    Fixeddamageshield,
    BurnRateUp,
    Burnsstackby2stacks,
    Chancetoburnwhenattacking,
    skillrecoveryafterlightninghit,
    lightningCountUp,
    Fixeddamagelightning,
    GoldUp,
    Burntransferafterburnenemydie,
    Dragonattackspeedupafteroverload,
    Arrowsbounce,
    Skillrecoveryspeedup,
    Enemyspeedup,
    Touchspeedup,
    Fixeddamageup,
    Summondamageup,
    Skilldamageup,
    Touchdamageup,
    Randomprojectileafterattacking10touch,
    IceArrowafter30fixeddamage,
    icearrowcountup,
    IceArrowafter50fixeddamage,
    DeathBalldurationup,
    DeathBallspeedup,
    DeathBallafterusing10skill,
    WhirlWindCountUp,
    WhirlWindafterattacking25touch,
    BurnonMeterorHit,
    SlowonMeteorHit,
    Meteorafterattacking30summons,
    Skillrecoveryspeeddown,
    Maxstaminadown,
    Touchdamagedown,
    Summondamagedown,
    Skilldamagedown,
    DragonattackSpeedUp,
    DragonattackSpeedDown,
    overload


}