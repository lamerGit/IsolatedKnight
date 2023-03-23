
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BossRewardButtonGroup : MonoBehaviour
{
    UI_BossRewardButton _left;
    UI_BossRewardButton _Middle;
    UI_BossRewardButton _right;

    public Sprite[] _rewardIcon;

    private void Awake()
    {
        _left = transform.Find("Left").GetComponent<UI_BossRewardButton>();
        _Middle = transform.Find("Middle").GetComponent<UI_BossRewardButton>();
        _right = transform.Find("Right").GetComponent<UI_BossRewardButton>();
    }

    public void Open()
    {
        _left.Option = BossRewardOption.None;
        _Middle.Option = BossRewardOption.None;
        _right.Option = BossRewardOption.None;

        RandomOption();

        gameObject.SetActive(true);
    }

    public void Close()
    {
        if (Managers.GameManager.BossRewardStack > 0)
        {
            RandomOption();
         
        }
        else
        {
            if (Managers.GameManager.LevelUpStack < 1)
            {
                Managers.GameManager.State = GameState.Nomal;
            }

            gameObject.SetActive(false);
        }

        
    }

    private void RandomOption()
    {
        List<BossRewardOption> options = new List<BossRewardOption>();

        if(Managers.GameManager.SwordWindTier<1 && Managers.Object.MyPlayer.EquipWeaponType==WeaponType.Sword || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.SwordWind);
        }

        if(Managers.GameManager.SwordPartnerTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Sword || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.SwordPartner);
        }

        if(Managers.GameManager.SwordTheTogetherTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Sword || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.SwordTheTogether);
        }

        if(Managers.GameManager.AxeHeavyTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Axe || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.AxeHeavy);
        }

        if (Managers.GameManager.AxeArrowTier < 1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Axe || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.AxeArrow);
        }

        if(Managers.GameManager.AxeFrenzyTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Axe || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.Axefrenzy);
        }

        if(Managers.GameManager.HammerStunTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hammer || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.HammerStun);
        }

        if(Managers.GameManager.HammerExtraAttackTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hammer || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.HammerExtraAttack);
        }

        if(Managers.GameManager.HammerFixedTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hammer || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.HammerFixed);
        }

        if(Managers.GameManager.StickNoTouchTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Stick || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.StickNoTouch);
        }

        if(Managers.GameManager.StickRandomSkillTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Stick || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.StickRandomSkill);
        }

        if(Managers.GameManager.StickSkillPlusTier<1 && Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Stick || Managers.Object.MyPlayer.EquipWeaponType == WeaponType.Hand)
        {
            options.Add(BossRewardOption.StickSkillPlus);
        }

        if(Managers.GameManager.HeavyPowerTier<1)
        {
            options.Add(BossRewardOption.HeavyPower);
        }

        if(Managers.GameManager.PartnerPassTier<1)
        {
            options.Add(BossRewardOption.PartnerPass);
        }

        if(Managers.GameManager.SkillWizadTier<1)
        {
            options.Add(BossRewardOption.SkillWizad);
        }

        if(Managers.GameManager.TheHardTier<1)
        {
            options.Add(BossRewardOption.TheHard);
        }

        if(Managers.GameManager.StaminaUpTier<1)
        {
            options.Add(BossRewardOption.StaminaUp);
        }

        if(Managers.GameManager.TheSpeedTier<1)
        {
            options.Add(BossRewardOption.TheSpeed);

        }

        if(Managers.GameManager.FixedUpTier<1)
        {
            options.Add(BossRewardOption.FixedUp);
        }

        if(Managers.GameManager.ExpUpTier<1)
        {
            options.Add(BossRewardOption.ExpUP);
        }

        for (int i = options.Count - 1; i > -1; i--)
        {
            int randIndex = Random.Range(0, i + 1);

            (options[randIndex], options[i]) = (options[i], options[randIndex]);

        }

        for (int i = 0; i < options.Count; i++)
        {
            if (i == 0)
            {
                _left.Option = options[i];
            }

            if (i == 1)
            {
                _Middle.Option = options[i];
            }

            if (i == 2)
            {
                _right.Option = options[i];
            }
        }

    }
}
