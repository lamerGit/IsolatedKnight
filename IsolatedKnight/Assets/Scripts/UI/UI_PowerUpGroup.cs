using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerUpGroup : MonoBehaviour
{
    Button _exitButton;

    UI_PowerUpItem _powerUpTouchDamage;
    UI_PowerUpItem _powerUpTouchSpeed;
    UI_PowerUpItem _powerUpMaxStamina;
    UI_PowerUpItem _powerUpSkillDamage;
    UI_PowerUpItem _powerUpSkillRecovery;
    UI_PowerUpItem _powerUpPartnerDamage;
    UI_PowerUpItem _powerUpFixedDamage;
    UI_PowerUpItem _powerUpExpUp;
    UI_PowerUpItem _powerUpGoldUp;

    int _touchDamageBasePrice = 200;
    int _touchSpeedBasePrice = 500;
    int _maxStaminaBasePrice = 200;
    int _skillDamageBasePrice = 200;
    int _skillRecoveryBasePrice = 500;
    int _partnerDamageBasePrice = 200;
    int _fixedDamageBasePrice = 1500;
    int _ExpUpBasePrice = 1000;
    int _GoldUpBasePrice = 1000;

    private void Awake()
    {
        _exitButton = transform.Find("ExitButton").GetComponent<Button>();

        _exitButton.onClick.AddListener(CloseSound);

        _powerUpTouchDamage=transform.Find("Scroll View/Viewport/Content/PowerUpTouchDamage").GetComponent<UI_PowerUpItem>();
        _powerUpTouchSpeed = transform.Find("Scroll View/Viewport/Content/PowerUpTouchSpeed").GetComponent<UI_PowerUpItem>();
        _powerUpMaxStamina = transform.Find("Scroll View/Viewport/Content/PowerUpMaxStamina").GetComponent<UI_PowerUpItem>();
        _powerUpSkillDamage = transform.Find("Scroll View/Viewport/Content/PowerUpSkillDamage").GetComponent<UI_PowerUpItem>();
        _powerUpSkillRecovery = transform.Find("Scroll View/Viewport/Content/PowerUpSkillRecovery").GetComponent<UI_PowerUpItem>();
        _powerUpPartnerDamage = transform.Find("Scroll View/Viewport/Content/PowerUpPartnerDamage").GetComponent<UI_PowerUpItem>();
        _powerUpFixedDamage = transform.Find("Scroll View/Viewport/Content/PowerUpFixedDamage").GetComponent<UI_PowerUpItem>();
        _powerUpExpUp = transform.Find("Scroll View/Viewport/Content/PowerUpExpUp").GetComponent<UI_PowerUpItem>();
        _powerUpGoldUp = transform.Find("Scroll View/Viewport/Content/PowerUpGoldUp").GetComponent<UI_PowerUpItem>();

        
    }

    private void Start()
    {
        _powerUpTouchDamage.Button.onClick.AddListener(OnPowerUpTouchDamageButton);
        _powerUpTouchSpeed.Button.onClick.AddListener(OnPowerUpTouchSpeedButton);
        _powerUpMaxStamina.Button.onClick.AddListener(OnPowerUpMaxStaminaButton);
        _powerUpSkillDamage.Button.onClick.AddListener(OnPowerUpSkillDamageButton);
        _powerUpSkillRecovery.Button.onClick.AddListener(OnPowerUpSkillRecoveryButton);
        _powerUpPartnerDamage.Button.onClick.AddListener(OnPowerUpPartnerDamageButton);
        _powerUpFixedDamage.Button.onClick.AddListener(OnPowerUpFixedDamageButton);
        _powerUpExpUp.Button.onClick.AddListener(OnPowerUpExpUpButton);
        _powerUpGoldUp.Button.onClick.AddListener(OnPowerUpGoldUpButton);
    }

    public void Open()
    {
        UI_ClickSound.Instance.ClickPlay();
        gameObject.SetActive(true);
        _powerUpTouchDamage.ButtonSetting(_touchDamageBasePrice* (GameDataManager.Instance.Power_TouchDamageTier+1), GameDataManager.Instance.Power_TouchDamageTier, GameDataManager.maxTouchDamageTier);
        _powerUpTouchSpeed.ButtonSetting(_touchSpeedBasePrice * (GameDataManager.Instance.Power_TouchSpeedTier + 1), GameDataManager.Instance.Power_TouchSpeedTier, GameDataManager.maxTouchSpeedTier);
        _powerUpMaxStamina.ButtonSetting(_maxStaminaBasePrice * (GameDataManager.Instance.Power_MaxStaminaTier + 1), GameDataManager.Instance.Power_MaxStaminaTier, GameDataManager.maxMaxStaminaTier);
        _powerUpSkillDamage.ButtonSetting(_skillDamageBasePrice * (GameDataManager.Instance.Power_SkillDamageTier + 1), GameDataManager.Instance.Power_SkillDamageTier, GameDataManager.maxSkillDamageTier);
        _powerUpSkillRecovery.ButtonSetting(_skillRecoveryBasePrice * (GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier + 1), GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier, GameDataManager.maxSkillCollTimeRecoveryTier);
        _powerUpPartnerDamage.ButtonSetting(_partnerDamageBasePrice * (GameDataManager.Instance.Power_PartnerDamageTier + 1), GameDataManager.Instance.Power_PartnerDamageTier, GameDataManager.maxPartnerDamageTier);
        _powerUpFixedDamage.ButtonSetting(_fixedDamageBasePrice * (GameDataManager.Instance.Power_FixedDamageTier + 1), GameDataManager.Instance.Power_FixedDamageTier, GameDataManager.maxFixedDamageTier);
        _powerUpExpUp.ButtonSetting(_ExpUpBasePrice * (GameDataManager.Instance.Power_ExpUpTier + 1), GameDataManager.Instance.Power_ExpUpTier, GameDataManager.maxExpUpTier);
        _powerUpGoldUp.ButtonSetting(_GoldUpBasePrice * (GameDataManager.Instance.Power_GoldUpTier + 1), GameDataManager.Instance.Power_GoldUpTier, GameDataManager.maxGoldUpTier);


    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void CloseSound()
    {
        UI_ClickSound.Instance.ClickPlay();
        gameObject.SetActive(false);
    }

    void OnPowerUpTouchDamageButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold- _powerUpTouchDamage.PriceValue>=0 && GameDataManager.Instance.Power_TouchDamageTier<GameDataManager.maxTouchDamageTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpTouchDamage.PriceValue;
                                           //
            GameDataManager.Instance.Power_TouchDamageTier++;
                    //                                //                                             //                                                         //                              //
            _powerUpTouchDamage.ButtonSetting(_touchDamageBasePrice * (GameDataManager.Instance.Power_TouchDamageTier + 1), GameDataManager.Instance.Power_TouchDamageTier, GameDataManager.maxTouchDamageTier);

            GameDataManager.Instance.SaveData();
        }
    }
    void OnPowerUpTouchSpeedButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        if (GameDataManager.Instance.PlayerGold - _powerUpTouchSpeed.PriceValue >= 0 && GameDataManager.Instance.Power_TouchSpeedTier < GameDataManager.maxTouchSpeedTier)
        {
            GameDataManager.Instance.PlayerGold -= _powerUpTouchSpeed.PriceValue;
            GameDataManager.Instance.Power_TouchSpeedTier++;

            _powerUpTouchSpeed.ButtonSetting(_touchSpeedBasePrice * (GameDataManager.Instance.Power_TouchSpeedTier + 1), GameDataManager.Instance.Power_TouchSpeedTier, GameDataManager.maxTouchSpeedTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpMaxStaminaButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                      //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpMaxStamina.PriceValue >= 0 && GameDataManager.Instance.Power_MaxStaminaTier < GameDataManager.maxMaxStaminaTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpMaxStamina.PriceValue;
            //
            GameDataManager.Instance.Power_MaxStaminaTier++;
            //                                //                                             //                                                         //                              //
            _powerUpMaxStamina.ButtonSetting(_maxStaminaBasePrice * (GameDataManager.Instance.Power_MaxStaminaTier + 1), GameDataManager.Instance.Power_MaxStaminaTier, GameDataManager.maxMaxStaminaTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpSkillDamageButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                  //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpSkillDamage.PriceValue >= 0 && GameDataManager.Instance.Power_SkillDamageTier < GameDataManager.maxSkillDamageTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpSkillDamage.PriceValue;
            //
            GameDataManager.Instance.Power_SkillDamageTier++;
            //                                //                                             //                                                         //                              //
            _powerUpSkillDamage.ButtonSetting(_skillDamageBasePrice * (GameDataManager.Instance.Power_SkillDamageTier + 1), GameDataManager.Instance.Power_SkillDamageTier, GameDataManager.maxSkillDamageTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpSkillRecoveryButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                 //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpSkillRecovery.PriceValue >= 0 && GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier < GameDataManager.maxSkillCollTimeRecoveryTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpSkillRecovery.PriceValue;
            //
            GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier++;
            //                                //                                             //                                                         //                              //
            _powerUpSkillRecovery.ButtonSetting(_skillRecoveryBasePrice * (GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier + 1), GameDataManager.Instance.Power_SkillCoolTimeRecoveryTier, GameDataManager.maxSkillCollTimeRecoveryTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpPartnerDamageButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                 //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpPartnerDamage.PriceValue >= 0 && GameDataManager.Instance.Power_PartnerDamageTier < GameDataManager.maxPartnerDamageTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpPartnerDamage.PriceValue;
            //
            GameDataManager.Instance.Power_PartnerDamageTier++;
            //                                //                                             //                                                         //                              //
            _powerUpPartnerDamage.ButtonSetting(_partnerDamageBasePrice * (GameDataManager.Instance.Power_PartnerDamageTier + 1), GameDataManager.Instance.Power_PartnerDamageTier, GameDataManager.maxPartnerDamageTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpFixedDamageButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                  //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpFixedDamage.PriceValue >= 0 && GameDataManager.Instance.Power_FixedDamageTier < GameDataManager.maxFixedDamageTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpFixedDamage.PriceValue;
            //
            GameDataManager.Instance.Power_FixedDamageTier++;
            //                                //                                             //                                                         //                              //
            _powerUpFixedDamage.ButtonSetting(_fixedDamageBasePrice * (GameDataManager.Instance.Power_FixedDamageTier + 1), GameDataManager.Instance.Power_FixedDamageTier, GameDataManager.maxFixedDamageTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpExpUpButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                       //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpExpUp.PriceValue >= 0 && GameDataManager.Instance.Power_ExpUpTier < GameDataManager.maxExpUpTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpExpUp.PriceValue;
            //
            GameDataManager.Instance.Power_ExpUpTier++;
            //                                //                                             //                                                         //                              //
            _powerUpExpUp.ButtonSetting(_ExpUpBasePrice * (GameDataManager.Instance.Power_ExpUpTier + 1), GameDataManager.Instance.Power_ExpUpTier, GameDataManager.maxExpUpTier);

            GameDataManager.Instance.SaveData();
        }
    }

    void OnPowerUpGoldUpButton()
    {
        UI_ClickSound.Instance.ClickPlay();                                   //                                                                   //                              //
        if (GameDataManager.Instance.PlayerGold - _powerUpGoldUp.PriceValue >= 0 && GameDataManager.Instance.Power_GoldUpTier < GameDataManager.maxGoldUpTier)
        {                                                     //
            GameDataManager.Instance.PlayerGold -= _powerUpGoldUp.PriceValue;
            //
            GameDataManager.Instance.Power_GoldUpTier++;
            //                                //                                             //                                                         //                              //
            _powerUpGoldUp.ButtonSetting(_GoldUpBasePrice * (GameDataManager.Instance.Power_GoldUpTier + 1), GameDataManager.Instance.Power_GoldUpTier, GameDataManager.maxGoldUpTier);

            GameDataManager.Instance.SaveData();
        }
    }

}
