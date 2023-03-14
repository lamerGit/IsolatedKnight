using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GameManager 
{
    GameState _state = GameState.Nomal;
    public GameState State { get { return _state; } 
        set { _state = value;
            StateChange?.Invoke();
        } }

    public Action StateChange { get; set; }

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
    public int PassiveFireTier { get; set; } = 0;
    public int PassiveThunderTier { get; set; } = 0;


    #endregion
}
