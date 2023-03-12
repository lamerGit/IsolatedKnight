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

    #endregion

    #region Gost

    public int PartnerGostTier { get; set; } = 0;

    #endregion

    #region PartnerBuff

    public int PartnerBuffTier { get; set; } = 0;

    #endregion
}
