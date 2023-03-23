using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_LevelUpButton : MonoBehaviour
{
    LevelUpOption _option;
    Button _button;

    UI_LevelUpButtonGroup _group;

    TextMeshProUGUI _tierText;
    public LevelUpOption Option
    {
        get { return _option; }
        set
        {
            _option = value;
            switch (_option)
            {
                case LevelUpOption.None:
                    _button.image.sprite = _group._levelIcon[0];
                    break;
                case LevelUpOption.TouchDamage:
                    _button.image.sprite = _group._levelIcon[1];
                    TierCheck(Managers.GameManager.TouchDamageTier);
                    break;
                case LevelUpOption.TouchSpeed:
                    _button.image.sprite = _group._levelIcon[2];
                    TierCheck(Managers.GameManager.TouchSpeedTier);
                    break;
                case LevelUpOption.Stamina:
                    _button.image.sprite = _group._levelIcon[3];
                    TierCheck(Managers.GameManager.StaminaTier);
                    break;
                case LevelUpOption.TouchBuff:
                    _button.image.sprite = _group._levelIcon[4];
                    TierCheck(Managers.GameManager.TouchBuffTier);
                    break;
                case LevelUpOption.PartnerDragon:
                    _button.image.sprite = _group._levelIcon[5];
                    TierCheck(Managers.GameManager.PartnerDragonTier);
                    break;
                case LevelUpOption.PartnerGolem:
                    _button.image.sprite = _group._levelIcon[6];
                    TierCheck(Managers.GameManager.PartnerGolemTier);
                    break;
                case LevelUpOption.PartnerGost:
                    _button.image.sprite = _group._levelIcon[7];
                    TierCheck(Managers.GameManager.PartnerGostTier);
                    break;
                case LevelUpOption.PartnerBuff:
                    _button.image.sprite = _group._levelIcon[8];
                    TierCheck(Managers.GameManager.PartnerBuffTier);
                    break;
                case LevelUpOption.SkillOnePoint:
                    _button.image.sprite = _group._levelIcon[9];
                    TierCheck(Managers.GameManager.SkillOnePointTier);
                    break;
                case LevelUpOption.SkillMultiPoint:
                    _button.image.sprite = _group._levelIcon[10];
                    TierCheck(Managers.GameManager.SkillMultiPointTier);
                    break;
                case LevelUpOption.SkillTouchBuff:
                    _button.image.sprite = _group._levelIcon[11];
                    TierCheck(Managers.GameManager.SkillTouchBuffTier);
                    break;
                case LevelUpOption.SkillBuff:
                    _button.image.sprite = _group._levelIcon[12];
                    TierCheck(Managers.GameManager.SkillBuffTier);
                    break;
                case LevelUpOption.PassiveExp:
                    _button.image.sprite = _group._levelIcon[13];
                    TierCheck(Managers.GameManager.PassiveExpTier);
                    break;
                case LevelUpOption.PassiveDefence:
                    _button.image.sprite = _group._levelIcon[14];
                    TierCheck(Managers.GameManager.PassiveDefenceTier);
                    break;
                case LevelUpOption.PassiveFire:
                    _button.image.sprite = _group._levelIcon[15];
                    TierCheck(Managers.GameManager.PassiveFireTier);
                    break;
                case LevelUpOption.PassiveThunder:
                    _button.image.sprite = _group._levelIcon[16];
                    TierCheck(Managers.GameManager.PassiveThunderTier);
                    break;
                case LevelUpOption.SpeedGame:
                    _button.image.sprite = _group._levelIcon[17];
                    TierCheck(Managers.GameManager.SynergySpeedGameTier);
                    break;
                case LevelUpOption.PowerSkillAttack:
                    _button.image.sprite = _group._levelIcon[18];
                    TierCheck(Managers.GameManager.SynergyPowerSkillAttackTier);
                    break;
                case LevelUpOption.ThunderArrow:
                    _button.image.sprite = _group._levelIcon[19];
                    TierCheck(Managers.GameManager.SynergyThunderArrowTier);
                    break;
                case LevelUpOption.WaringDragon:
                    _button.image.sprite = _group._levelIcon[20];
                    TierCheck(Managers.GameManager.SynergyWaringDragonTier);
                    break;
                case LevelUpOption.DefenceFire:
                    _button.image.sprite = _group._levelIcon[21];
                    TierCheck(Managers.GameManager.SynergyDefenceFireTier);
                    break;
            }


        }
    }

    private void Awake()
    {  
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButton);

        _group=GetComponentInParent<UI_LevelUpButtonGroup>();
        _tierText=GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnButton()
    {
        switch (Option)
        {
            case LevelUpOption.None:
                break;
            case LevelUpOption.TouchDamage:
                TouchDamageTierSelected();
                break;
            case LevelUpOption.TouchSpeed:
                TouchSpeedTierSelected();
                break;
            case LevelUpOption.Stamina:
                StaminaTierSelected();
                break;
            case LevelUpOption.TouchBuff:
                TouchBuffTierSelected();
                break;
            case LevelUpOption.PartnerDragon:
                PartnerDragonTierSelected();
                break;
            case LevelUpOption.PartnerGolem:
                PartnerGolemTierSelected();
                break;
            case LevelUpOption.PartnerGost:
                PartnerGostTierSelected();
                break;
            case LevelUpOption.PartnerBuff:
                PartnerBuffTierSelected();
                break;
            case LevelUpOption.SkillOnePoint:
                SkillOnePointTierSelected();
                break;
            case LevelUpOption.SkillMultiPoint:
                SkillMultitTierSelected();
                break;
            case LevelUpOption.SkillTouchBuff:
                SkillTouchBuffTierSelected();
                break;
            case LevelUpOption.SkillBuff:
                SkillBuffTierSelected();
                break;
            case LevelUpOption.PassiveExp:
                PassiveExpTierSelected();
                break;
            case LevelUpOption.PassiveDefence:
                PassiveDefenceTierSelected();
                break;
            case LevelUpOption.PassiveFire:
                PassiveFireTierSelected();
                break;
            case LevelUpOption.PassiveThunder:
                PassiveThunderTierSelected();
                break;
            case LevelUpOption.SpeedGame:
                SynergySpeedGameTierSelected();
                break;
            case LevelUpOption.PowerSkillAttack:
                SynergyPowerSkillAttackTierSelected();
                break;
            case LevelUpOption.ThunderArrow:
                SynergyThunderArrowTierSelected();
                break;
            case LevelUpOption.WaringDragon:
                SynergyWaringDragonTierSelected();
                break;
            case LevelUpOption.DefenceFire:
                SynergyDefenceFireTierSelected();
                break;
        }

        Managers.GameManager.LevelUpStack--;
        
        _group.Close();
    }

    #region Synergy
    private void SynergySpeedGameTierSelected()
    {
        switch (Managers.GameManager.SynergySpeedGameTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                Managers.GameManager.ExtraEnemySpeed += 0.5f;
                break;

        }
        Managers.GameManager.SynergySpeedGameTier++;
    }

    private void SynergyPowerSkillAttackTierSelected()
    {
        switch (Managers.GameManager.SynergyPowerSkillAttackTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 2.0f);
                Managers.GameManager.ExtraSkillRecovery -= Managers.Object.MyPlayer.SkillRecoverySpeed * 0.5f;
                break;

        }
        Managers.GameManager.SynergyPowerSkillAttackTier++;
    }

    private void SynergyThunderArrowTierSelected()
    {
        switch (Managers.GameManager.SynergyThunderArrowTier)
        {
            case 0:
                Managers.GameManager.SynergyThunderArrowTier1billia = true;
                break;

        }
        Managers.GameManager.SynergyThunderArrowTier++;
    }

    private void SynergyWaringDragonTierSelected()
    {
        switch (Managers.GameManager.SynergyWaringDragonTier)
        {
            case 0:
                Managers.GameManager.SynergyWaringDragonTier1WaningOn = true;
                break;

        }
        Managers.GameManager.SynergyWaringDragonTier++;
    }

    private void SynergyDefenceFireTierSelected()
    {
        switch (Managers.GameManager.SynergyDefenceFireTier)
        {
            case 0:
                Managers.GameManager.SynergyDefenceFireTier1FireTrans = true;
                break;
            
        }
        Managers.GameManager.SynergyDefenceFireTier++;
    }

    #endregion

    #region PassiveSelected

    private void PassiveThunderTierSelected()
    {
        switch (Managers.GameManager.PassiveThunderTier)
        {
            case 0:
                Managers.GameManager.PassiveThunderTier1ThunderOn = true;
                Managers.GameManager.PassiveThunderCount = 1;
                break;
            case 1:
                Managers.GameManager.PassiveThunderCount = 5;
                break;
            case 2:
                Managers.GameManager.PassiveThunderTier3CoolTimeRecovery = true;
                Managers.GameManager.PassiveThunderCount = 15;
                break;

        }
        Managers.GameManager.PassiveThunderTier++;
    }

    private void PassiveFireTierSelected()
    {
        switch (Managers.GameManager.PassiveFireTier)
        {
            case 0:
                Managers.GameManager.PassiveFireTire1FireOn = true;
                break;
            case 1:
                Managers.GameManager.PassiveFireTire2DoubleFire = true;
                break;
            case 2:
                Managers.GameManager.PassiveFireTire3FireOn = true;
                break;

        }
        Managers.GameManager.PassiveFireTier++;
    }

    private void PassiveDefenceTierSelected()
    {
        switch (Managers.GameManager.PassiveDefenceTier)
        {
            case 0:
                Managers.Object.PassiveDefence.Spawn();
                break;
            case 1:
                Managers.GameManager.ExtraPassiveDefenceDamage += 5;
                break;
            case 2:
                Managers.Object.PassiveDefence.AttackSpeed = 1.0f;
                Managers.Object.PassiveDefence.CurrentAttackTimer = 0.0f;
                break;

        }
        Managers.GameManager.PassiveDefenceTier++;
    }

    private void PassiveExpTierSelected()
    {
        switch (Managers.GameManager.PassiveExpTier)
        {
            case 0:
                Managers.GameManager.ExtraExpPersent += 0.5f;
                
                break;
            case 1:
                Managers.GameManager.ExtraExpPersent += 0.6f;
                Managers.GameManager.PassiveExpTier2Arrow = true;
                break;
            case 2:
                Managers.GameManager.ExtraExpPersent += 0.7f;
                Managers.GameManager.PassiveExpTier3Arrow = true;
                break;

        }
        Managers.GameManager.PassiveExpTier++;
    }

    #endregion


    #region SkillSelected
    private void SkillOnePointTierSelected()
    {
        switch (Managers.GameManager.SkillOnePointTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.OnePoint);
                break;
            case 1:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 1.0f);
                break;
            case 2:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 1.0f);
                Managers.GameManager.OnePointSkillTier3HpAttack = true;
                break;

        }
        Managers.GameManager.SkillOnePointTier++;
    }

    private void SkillMultitTierSelected()
    {
        switch (Managers.GameManager.SkillMultiPointTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.MultiPoint);
                break;
            case 1:
                Managers.GameManager.SkillMutiPointTier2Slow = true;
                break;
            case 2:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.5f);
                Managers.GameManager.SkillMutiPointTier3Slow = true;
                break;

        }
        Managers.GameManager.SkillMultiPointTier++;
    }

    private void SkillTouchBuffTierSelected()
    {
        switch (Managers.GameManager.SkillTouchBuffTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.TouchBuff);
                break;
            case 1:
                Managers.GameManager.SkillTouchBuffTier2SpeedUp = true;
                break;
            case 2:
                Managers.GameManager.SkillTouchBuffTier3StaminaRecovery = true;
                break;

        }
        Managers.GameManager.SkillTouchBuffTier++;
    }

    private void SkillBuffTierSelected()
    {
        switch (Managers.GameManager.SkillBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.2f);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                break;
            case 1:
                Managers.GameManager.ExtraSkillRecovery += Managers.Object.MyPlayer.SkillRecoverySpeed * 1.0f;

                break;
            case 2:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.Buff);
                break;

        }
        Managers.GameManager.SkillBuffTier++;
    }
    #endregion

    #region PartnerSelected
    private void PartnerGolemTierSelected()
    {
        switch (Managers.GameManager.PartnerGolemTier)
        {
            case 0:
                Managers.Object.PartnerGolem.Spawn();
                break;
            case 1:
                Managers.GameManager.PartnerGolemTier2Billia = true;
                Managers.GameManager.ExtraGolemDamage += (int)(Managers.Object.PartnerGolem.AttackDamge * 0.5f);
                break;
            case 2:
                Managers.GameManager.PartnerGolemTier3Explosion = true;
                Managers.GameManager.ExtraGolemDamage += (int)(Managers.Object.PartnerGolem.AttackDamge * 0.5f);
                break;

        }
        Managers.GameManager.PartnerGolemTier++;
    }

    private void PartnerGostTierSelected()
    {
        switch (Managers.GameManager.PartnerGostTier)
        {
            case 0:
                Managers.Object.PartnerGost.Spawn();
                break;
            case 1:
                Managers.GameManager.PartnerGostTier2Slow= true;
                break;
            case 2:
                Managers.GameManager.PartnerGostTier3Slow = true;
                break;

        }
        Managers.GameManager.PartnerGostTier++;
    }

    private void PartnerBuffTierSelected()
    {
        switch (Managers.GameManager.PartnerBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.2f);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                break;
            case 1:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.3f);
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.3f);
                break;
            case 2:
                Managers.GameManager.PartnerBuffTier3ExtraAttack = true;
                break;

        }
        Managers.GameManager.PartnerBuffTier++;
    }

    private void PartnerDragonTierSelected()
    {
        switch (Managers.GameManager.PartnerDragonTier)
        {
            case 0:
                Managers.Object.PartnerDragon.Spawn();
                break;
            case 1:
                Managers.GameManager.ExtraDragonAttackSpeed += Managers.Object.PartnerDragon.AttackSpeed * 0.3f;
                Managers.Object.PartnerDragon.CurrentAttackTimer = 0.0f;
                Managers.GameManager.PartnerDragonTier2SpearShot = true;
                break;
            case 2:
                Managers.GameManager.ExtraDragonAttackSpeed += Managers.Object.PartnerDragon.AttackSpeed * 0.5f;
                Managers.Object.PartnerDragon.CurrentAttackTimer = 0.0f;
                Managers.GameManager.PartnerDragonTier3MultiShot = true;
                break;

        }
        Managers.GameManager.PartnerDragonTier++;
    }
    #endregion

    #region TouchSelected
    void TouchDamageTierSelected()
    {
        switch (Managers.GameManager.TouchDamageTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                break;
            case 1:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.7f);
                Managers.GameManager.TouchDamageTier2SpeedDown = true;
                break;
            case 2:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 1.0f);
                Managers.GameManager.TouchDamageTier3MultiHit = true;
                break;

        }

       

        Managers.GameManager.TouchDamageTier++;
    }

    void TouchSpeedTierSelected()
    {
        switch (Managers.GameManager.TouchSpeedTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.1f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
               
                break;
            case 1:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                break;
            case 2:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                Managers.GameManager.TouchSpeedTier3RandomConsum= true;
                break;

        }

        Managers.GameManager.TouchSpeedTier++;
    }

    void TouchBuffTierSelected()
    {
        switch (Managers.GameManager.TouchBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.2f);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                break;
            case 1:
                Managers.GameManager.TouchBuffTier2AutoAttack = true;
                break;
            case 2:
                Managers.GameManager.TouchBuffTier3AutoAttackBuff = true;
                break;

        }

        Managers.GameManager.TouchBuffTier++;


    }
    #endregion

    void StaminaTierSelected()
    {
        switch (Managers.GameManager.StaminaTier)
        {
            case 0:
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                break;
            case 1:
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                Managers.GameManager.ExtraMaxStamina += (int)(Managers.Object.MyPlayer.MaxStamina * 0.5f);
                Debug.Log(Managers.Object.MyPlayer.MaxStamina + Managers.GameManager.ExtraMaxStamina);
                break;
            case 2:
                Managers.GameManager.StaminaTier3Overload = true;
                break;

        }
        Managers.GameManager.StaminaTier++;
    }



    void TierCheck(int tier)
    {
        _tierText.text = $"T {tier + 1}";
    }

}
