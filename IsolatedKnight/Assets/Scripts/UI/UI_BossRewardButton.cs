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
                    break;
                case BossRewardOption.PartnerPass:
                    break;
                case BossRewardOption.SkillWizad:
                    break;
                case BossRewardOption.ThaHard:
                    break;
                case BossRewardOption.StaminaUp:
                    break;
                case BossRewardOption.TheSpeed:
                    break;
                case BossRewardOption.FixedUp:
                    break;
                case BossRewardOption.ExpUP:
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
        switch (Option)
        {
            case BossRewardOption.None:
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
                break;
            case BossRewardOption.PartnerPass:
                break;
            case BossRewardOption.SkillWizad:
                break;
            case BossRewardOption.ThaHard:
                break;
            case BossRewardOption.StaminaUp:
                break;
            case BossRewardOption.TheSpeed:
                break;
            case BossRewardOption.FixedUp:
                break;
            case BossRewardOption.ExpUP:
                break;
        }
        Managers.GameManager.BossRewardStack--;

        _group.Close();
    }

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
