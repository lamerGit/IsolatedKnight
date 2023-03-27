using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData 
{
    public int PlayerGold;

    public int Power_TouchDamageTier;
    public int Power_TouchSpeedTier;
    public int Power_MaxStaminaTier;
    public int Power_SkillDamageTier;
    public int Power_SkillCoolTimeRecoveryTier;
    public int Power_PartnerDamageTier;
    public int Power_FixedDamageTier;
    public int Power_ExpUpTier;
    public int Power_GoldUpTier;

    public int EquipWeapon;

    public bool SwordOpen;
    public bool AxeOpen;
    public bool HammerOpen;
    public bool StickOpen;
    public bool HandOpen;

    public float BgmValue;
    public float CfxValue;
}
