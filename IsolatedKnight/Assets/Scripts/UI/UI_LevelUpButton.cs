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
        }


        Managers.GameManager.State = GameState.Nomal;

        _group.Close();
    }

    #region PartnerSelected
    private void PartnerGolemTierSelected()
    {
        switch (Managers.GameManager.PartnerGolemTier)
        {
            case 0:
                Managers.Object.PartnerGolem.Spawn();
                break;
            case 1:

                break;
            case 2:

                break;

        }
        Managers.GameManager.PartnerGolemTier++;
    }

    private void PartnerGostTierSelected()
    {
        switch (Managers.GameManager.PartnerGostTier)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;

        }
        Managers.GameManager.PartnerGostTier++;
    }

    private void PartnerBuffTierSelected()
    {
        switch (Managers.GameManager.PartnerBuffTier)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

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
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.3f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
               
                break;
            case 1:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.3f;
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                break;
            case 2:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.3f;
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
