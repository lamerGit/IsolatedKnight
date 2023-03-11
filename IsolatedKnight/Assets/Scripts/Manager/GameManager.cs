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
    public int ExtraTouchSpeed { get; set;} = 0;
    public float ExtraStaminaconsum { get;set; } = 0.0f;

    public bool TouchTier2SpeedDown { get; set; } = false;

    public bool TouchTier2MultiHit { get; set; } = false;

    #endregion

    #region Stamina
    public int StaminaTier { get; set; } = 0;

    public float ExtraMaxStamina { get; set; } = 0.0f;
    #endregion
}
