using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    GameState _state = GameState.Nomal;
    public GameState State { get { return _state; }
        set { _state = value;
            StateChange?.Invoke();
        } }

    public Action StateChange { get; set; }

    public int GameLevel { get; set; } = 0;

    public int LevelUpStack { get; set; } = 0;

    public int BossRewardStack { get; set; } = 0;

    public int ExtraFixedDamage { get; set; } = 0;

    public Dictionary<DamageType, int> DamageCheck { get; private set; } = new Dictionary<DamageType, int>()
    { { DamageType.Touch, 0 },
    { DamageType.PartnerDragon, 0 },
    { DamageType.PartnerGolem, 0 },
    { DamageType.PartnerGost, 0 },
    { DamageType.SkillOnePoint, 0 },
    { DamageType.SkillMultiPoint, 0 },
    { DamageType.PassiveArrow, 0 },
    { DamageType.PassiveThunder, 0 },
    { DamageType.PassiveFire, 0 },
    { DamageType.PassiveDefence, 0 },
    { DamageType.SwordWind, 0 }};



    #region Touch
    public int TouchDamageTier { get; set; } = 0;
    public int TouchSpeedTier { get; set; } = 0;
    
    public int TouchBuffTier { get; set; } = 0;

    public int ExtraTouchDamage { get; set; } = 0;
    public float ExtraTouchSpeed { get; set;} = 0.0f;
    
    public bool TouchDamageTier2SpeedDown { get; set; } = false;

    public bool TouchDamageTier3MultiHit { get; set; } = false;

    public bool TouchSpeedTier3RandomConsum { get; set; } = false;

    public bool TouchBuffTier2AutoAttack { get; set; } = false;
    public bool TouchBuffTier3AutoAttackBuff { get; set; } = false;

    #endregion

    #region Stamina
    public int StaminaTier { get; set; } = 0;
    public float ExtraStaminaconsum { get; set; } = 0.0f;
    public float ExtraMaxStamina { get; set; } = 0.0f;

    public bool StaminaTier3Overload { get; set; } = false;
    #endregion

    #region Exp

    public float ExtraExpPersent { get;set; } = 0.0f;

    #endregion


    #region Dragon

    public int PartnerDragonTier { get; set;} = 0;

    public float ExtraDragonAttackSpeed { get; set; } = 0.0f;

    public bool PartnerDragonTier2SpearShot { get;set; } = false;

    public bool PartnerDragonTier3MultiShot { get; set; } = false;

    #endregion

    #region Golem

    public int PartnerGolemTier { get; set; } = 0;

    public int ExtraGolemDamage { get; set; } = 0;

    public bool PartnerGolemTier2Billia { get; set; } = false;
    public bool PartnerGolemTier3Explosion { get; set; } = false;  

    #endregion

    #region Gost

    public int PartnerGostTier { get; set; } = 0;

    public bool PartnerGostTier2Slow { get; set; } = false;
    public bool PartnerGostTier3Slow { get; set;} = false;

    #endregion

    #region PartnerBuff

    public int PartnerBuffTier { get; set; } = 0;

    public int ExtraPartnerDamage { get; set;} = 0;

    public bool PartnerBuffTier3ExtraAttack { get; set; } = false;

    #endregion

    #region Skill

    public int SkillOnePointTier { get; set; } = 0;

    public int ExtraSkillDamage { get; set;} = 0;

    public bool OnePointSkillTier3HpAttack { get; set; }= false;

    public int SkillMultiPointTier { get; set; } = 0;

    public bool SkillMutiPointTier2Slow { get; set; } = false;
    public bool SkillMutiPointTier3Slow { get; set; } = false;


    public int SkillTouchBuffTier { get; set; } = 0;

    public bool SkillTouchBuffTier2SpeedUp { get; set;} = false;
    public bool SkillTouchBuffTier3StaminaRecovery { get; set;} = false;
    public int SkillBuffTier { get; set; } = 0;

    public float ExtraSkillRecovery { get; set;} = 0.0f;

    #endregion

    #region Passive

    public int PassiveExpTier { get; set; } = 0;

    public bool PassiveExpTier2Arrow { get; set; } = false;
    public bool PassiveExpTier3Arrow { get; set; } = false;
    public int PassiveDefenceTier { get; set; } = 0;

    public int ExtraPassiveDefenceDamage { get; set;} = 0;
    public int PassiveFireTier { get; set; } = 0;

    public bool PassiveFireTire1FireOn { get; set; } = false;

    public bool PassiveFireTire2DoubleFire { get; set; } = false;

    public bool PassiveFireTire3FireOn { get; set;} = false;
    public int PassiveThunderTier { get; set; } = 0;

    public bool PassiveThunderTier1ThunderOn { get; set;} = false;

    public int PassiveThunderCount { get;set; } = 5;

    public bool PassiveThunderTier3CoolTimeRecovery { get;set; } = false;


    #endregion

    #region Synergy

    public int SynergySpeedGameTier { get; set; } = 0;

    public float ExtraEnemySpeed { get; set; } = 0.0f;
    public int SynergyPowerSkillAttackTier { get; set; } = 0;
    public int SynergyThunderArrowTier { get; set; } = 0;

    public bool SynergyThunderArrowTier1billia { get; set;} = false;
    public int SynergyWaringDragonTier { get; set; } = 0;

    public bool SynergyWaringDragonTier1WaningOn { get; set;} = false;
    public int SynergyDefenceFireTier { get; set; } = 0;

    public bool SynergyDefenceFireTier1FireTrans { get; set;} = false;

    #endregion

    #region BossReward

    public int SwordWindTier { get; set;} = 0;

    public bool SwordWindTier1SwordWindOn { get; set;} = false;

    public int SwordPartnerTier { get; set; } = 0;

    public int SwordTheTogetherTier { get; set;} = 0;

    public int AxeHeavyTier { get; set;} = 0;
    public int AxeArrowTier { get; set;} = 0;

    public bool AxeArrowTier1ArrowOn { get; set;} = false;
    public int AxeFrenzyTier { get; set;} = 0;

    public bool AxeFrenzyTier1FrenzyOn { get; set;} = false;

    public int HammerStunTier { get; set;} = 0;

    public bool HammaerStunTier1StunOn { get; set;} = false;
    public int HammerExtraAttackTier { get; set;} = 0;

    public bool HammerExtraAttackTier1ExtraAttackOn { get; set;} = false;
    public int HammerFixedTier { get; set;} = 0;

    public int StickNoTouchTier { get; set; } = 0;
    public int StickRandomSkillTier { get; set; } = 0;

    public bool StickRandomSkillTier1RandomOn { get; set;} = false;
    public int StickSkillPlusTier { get; set; } = 0;

    public int HeavyPowerTier { get; set;} = 0;

    public int PartnerPassTier { get; set; } = 0;

    public int SkillWizadTier { get; set; } = 0;

    public int TheHardTier { get; set; } = 0;

    public int StaminaUpTier { get; set; } = 0;

    public int TheSpeedTier { get; set; } = 0;

    public int FixedUpTier { get; set; } = 0;

    public int ExpUpTier { get; set; } = 0;


    #endregion
}
