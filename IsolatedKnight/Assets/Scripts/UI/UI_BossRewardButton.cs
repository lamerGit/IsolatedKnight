using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossRewardButton : MonoBehaviour
{
    BossRewardOption _option;
    Button _button;

    UI_BossRewardButtonGroup _group;

    public BossRewardOption Option
    {
        get { return _option; }
        set
        {
            _option = value;

            switch (_option)
            {
                case BossRewardOption.None:
                    _button.image.sprite = _group._rewardIcon[0];
                    break;
                case BossRewardOption.SwordWind:
                    _button.image.sprite = _group._rewardIcon[1];
                    break;
                case BossRewardOption.SwordPartner:
                    _button.image.sprite = _group._rewardIcon[2];
                    break;
                case BossRewardOption.SwordTheTogether:
                    _button.image.sprite = _group._rewardIcon[3];
                    break;
                case BossRewardOption.AxeHeavy:
                    _button.image.sprite = _group._rewardIcon[4];
                    break;
                case BossRewardOption.AxeArrow:
                    _button.image.sprite = _group._rewardIcon[5];
                    break;
                case BossRewardOption.Axefrenzy:
                    _button.image.sprite = _group._rewardIcon[6];
                    break;
                case BossRewardOption.HammerStun:
                    _button.image.sprite = _group._rewardIcon[7];
                    break;
                case BossRewardOption.HammerExtraAttack:
                    _button.image.sprite = _group._rewardIcon[8];
                    break;
                case BossRewardOption.HammerFixed:
                    _button.image.sprite = _group._rewardIcon[9];
                    break;
                case BossRewardOption.StickNoTouch:
                    _button.image.sprite = _group._rewardIcon[10];
                    break;
                case BossRewardOption.StickRandomSkill:
                    _button.image.sprite = _group._rewardIcon[11];
                    break;
                case BossRewardOption.StickSkillPlus:
                    _button.image.sprite = _group._rewardIcon[12];
                    break;
                case BossRewardOption.HeavyPower:
                    _button.image.sprite = _group._rewardIcon[13];
                    break;
                case BossRewardOption.PartnerPass:
                    _button.image.sprite = _group._rewardIcon[14];
                    break;
                case BossRewardOption.SkillWizad:
                    _button.image.sprite = _group._rewardIcon[15];
                    break;
                case BossRewardOption.TheHard:
                    _button.image.sprite = _group._rewardIcon[16];
                    break;
                case BossRewardOption.StaminaUp:
                    _button.image.sprite = _group._rewardIcon[17];
                    break;
                case BossRewardOption.TheSpeed:
                    _button.image.sprite = _group._rewardIcon[18];
                    break;
                case BossRewardOption.FixedUp:
                    _button.image.sprite = _group._rewardIcon[19];
                    break;
                case BossRewardOption.ExpUP:
                    _button.image.sprite = _group._rewardIcon[20];
                    break;
            }



        }
    }

    private void Awake()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButton);

        _group = GetComponentInParent<UI_BossRewardButtonGroup>();

    }

    private void OnButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        switch (Option)
        {
            case BossRewardOption.None:
                Managers.Object.MyPlayer.GoldUp(50);
                break;
            case BossRewardOption.SwordWind:
                SwordWindTierSelected();
                break;
            case BossRewardOption.SwordPartner:
                SwordPartnerTierSelected();
                break;
            case BossRewardOption.SwordTheTogether:
                SwordTheToghtherTierSelected();
                break;
            case BossRewardOption.AxeHeavy:
                AxeHeavyTierSelected();
                break;
            case BossRewardOption.AxeArrow:
                AxeArrowTierSelected();
                break;
            case BossRewardOption.Axefrenzy:
                AxeFrenzyTierSelected();
                break;
            case BossRewardOption.HammerStun:
                HammerStunTierSelected();
                break;
            case BossRewardOption.HammerExtraAttack:
                HammerExtraAttackTierSelected();
                break;
            case BossRewardOption.HammerFixed:
                HammerFixedTierSelected();
                break;
            case BossRewardOption.StickNoTouch:
                StickNoTouchTierSelected();
                break;
            case BossRewardOption.StickRandomSkill:
                StickRandomSkillTierSelected();
                break;
            case BossRewardOption.StickSkillPlus:
                StickSkillPlusTierSelected();
                break;
            case BossRewardOption.HeavyPower:
                HeavyPowerTierSelected();
                break;
            case BossRewardOption.PartnerPass:
                PartnerPassTierSelected();
                break;
            case BossRewardOption.SkillWizad:
                SkillWizadTierSelected();
                break;
            case BossRewardOption.TheHard:
                TheHardTierSelected();
                break;
            case BossRewardOption.StaminaUp:
                StaminaUpTierSelected();
                break;
            case BossRewardOption.TheSpeed:
                TheSpeedTierSelected();
                break;
            case BossRewardOption.FixedUp:
                FixedUpTierSelected();
                break;
            case BossRewardOption.ExpUP:
                ExpUpTierSelected();
                break;
        }
        Managers.GameManager.BossRewardStack--;

        _group.Close();
    }

    #region Common
    private void HeavyPowerTierSelected()
    {
        switch (Managers.GameManager.HeavyPowerTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 2.0f);
                Managers.GameManager.ExtraMaxStamina -= (int)(Managers.Object.MyPlayer.MaxStamina * 0.2f);
                break;

        }
        Managers.GameManager.HeavyPowerTier++;
    }

    private void PartnerPassTierSelected()
    {
        switch (Managers.GameManager.PartnerPassTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 2.0f);
                Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                break;

        }
        Managers.GameManager.PartnerPassTier++;
    }

    private void SkillWizadTierSelected()
    {
        switch (Managers.GameManager.SkillWizadTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 3.0f);
                Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 0.3f);
                Managers.GameManager.ExtraPartnerDamage -= (int)(Managers.Object.MyPlayer.PartnerDamage * 0.3f);
                break;

        }
        Managers.GameManager.SkillWizadTier++;
    }

    private void TheHardTierSelected()
    {
        switch (Managers.GameManager.TheHardTier)
        {
            case 0:
                Managers.GameManager.ExtraFixedDamage += 3;
                Managers.GameManager.ExtraEnemySpeed += 1.0f;
                Managers.GameManager.ExtraExpPersent += 1.0f;
                break;

        }
        Managers.GameManager.TheHardTier++;
    }

    private void StaminaUpTierSelected()
    {
        switch (Managers.GameManager.StaminaUpTier)
        {
            case 0:
                Managers.GameManager.ExtraMaxStamina += (int)(Managers.Object.MyPlayer.MaxStamina * 1.0f);
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                break;

        }
        Managers.GameManager.StaminaUpTier++;
    }

    private void TheSpeedTierSelected()
    {
        switch (Managers.GameManager.TheSpeedTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillRecovery += 3.0f;
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.3f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                Managers.GameManager.ExtraEnemySpeed += 0.5f;
                break;

        }
        Managers.GameManager.TheSpeedTier++;
    }

    private void FixedUpTierSelected()
    {
        switch (Managers.GameManager.FixedUpTier)
        {
            case 0:
                Managers.GameManager.ExtraFixedDamage += 3;
                break;

        }
        Managers.GameManager.FixedUpTier++;
    }

    private void ExpUpTierSelected()
    {
        switch (Managers.GameManager.ExpUpTier)
        {
            case 0:
                Managers.GameManager.ExtraExpPersent += 2.0f;
                break;

        }
        Managers.GameManager.ExpUpTier++;
    }

    #endregion

    #region Stick
    private void StickNoTouchTierSelected()
    {
        switch (Managers.GameManager.StickNoTouchTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillRecovery += 10.0f;
                Managers.GameManager.ExtraTouchDamage -= (int)(Managers.Object.MyPlayer.TouchDamage * 1.0f);
                break;

        }
        Managers.GameManager.StickNoTouchTier++;
    }

    private void StickRandomSkillTierSelected()
    {
        switch (Managers.GameManager.StickRandomSkillTier)
        {
            case 0:
                Managers.GameManager.StickRandomSkillTier1RandomOn = true;
                break;

        }
        Managers.GameManager.StickRandomSkillTier++;
    }

    private void StickSkillPlusTierSelected()
    {
        switch (Managers.GameManager.StickSkillPlusTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage -= (int)(Managers.Object.MyPlayer.PartnerDamage * 0.5f);
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 3.0f);
                Managers.GameManager.ExtraFixedDamage += 1;
                break;

        }
        Managers.GameManager.StickSkillPlusTier++;
    }
    #endregion

    #region Hammer
    private void HammerStunTierSelected()
    {
        switch (Managers.GameManager.HammerStunTier)
        {
            case 0:
                Managers.GameManager.HammaerStunTier1StunOn = true;
                break;

        }
        Managers.GameManager.HammerStunTier++;
    }

    private void HammerExtraAttackTierSelected()
    {
        switch (Managers.GameManager.HammerExtraAttackTier)
        {
            case 0:
                Managers.GameManager.HammerExtraAttackTier1ExtraAttackOn = true;
                break;

        }
        Managers.GameManager.HammerExtraAttackTier++;
    }

    private void HammerFixedTierSelected()
    {
        switch (Managers.GameManager.HammerFixedTier)
        {
            case 0:
                Managers.GameManager.ExtraFixedDamage += 3;
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.5f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;

                break;

        }
        Managers.GameManager.HammerFixedTier++;
    }
    #endregion

    #region Axe
    private void AxeHeavyTierSelected()
    {
        switch (Managers.GameManager.AxeHeavyTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 2.0f);
                break;

        }
        Managers.GameManager.AxeHeavyTier++;
    }

    private void AxeArrowTierSelected()
    {
        switch (Managers.GameManager.AxeArrowTier)
        {
            case 0:
                Managers.GameManager.AxeArrowTier1ArrowOn = true;
                break;

        }
        Managers.GameManager.AxeArrowTier++;
    }

    private void AxeFrenzyTierSelected()
    {
        switch (Managers.GameManager.AxeFrenzyTier)
        {
            case 0:
                Managers.GameManager.AxeFrenzyTier1FrenzyOn = true;
                break;

        }
        Managers.GameManager.AxeFrenzyTier++;
    }
    #endregion

    #region Sword

    private void SwordTheToghtherTierSelected()
    {
        switch (Managers.GameManager.SwordTheTogetherTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.3f);
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.3f);
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.3f);
                Managers.GameManager.ExtraFixedDamage += 1;
                break;

        }
        Managers.GameManager.SwordTheTogetherTier++;
    }
    private void SwordPartnerTierSelected()
    {
        switch (Managers.GameManager.SwordPartnerTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 2.0f);
                Managers.GameManager.ExtraMaxStamina -= (int)(Managers.Object.MyPlayer.MaxStamina * 0.3f);
                break;

        }
        Managers.GameManager.SwordPartnerTier++;
    }

    private void SwordWindTierSelected()
    {
        switch (Managers.GameManager.SwordWindTier)
        {
            case 0:
                Managers.GameManager.SwordWindTier1SwordWindOn = true;
                break;

        }
        Managers.GameManager.SwordWindTier++;
    }
    #endregion
}
