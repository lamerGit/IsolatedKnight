using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponSelectGroup : MonoBehaviour
{
    Button _exitButton;

    UI_WeaponSelectItem _sword;
    UI_WeaponSelectItem _axe;
    UI_WeaponSelectItem _hammer;
    UI_WeaponSelectItem _stick;
    UI_WeaponSelectItem _hand;

    int _swordPrice = 0;
    int _axePrice = 2000;
    int _hammerPrice = 2000;
    int _stickPrice = 2000;
    int _handPrice = 2000;

    private void Awake()
    {
        _exitButton = transform.Find("ExitButton").GetComponent<Button>();

        _sword=transform.Find("Scroll View/Viewport/Content/Sword").GetComponent<UI_WeaponSelectItem>();
        _axe = transform.Find("Scroll View/Viewport/Content/Axe").GetComponent<UI_WeaponSelectItem>();
        _hammer = transform.Find("Scroll View/Viewport/Content/Hammer").GetComponent<UI_WeaponSelectItem>();
        _stick = transform.Find("Scroll View/Viewport/Content/Stick").GetComponent<UI_WeaponSelectItem>();
        _hand = transform.Find("Scroll View/Viewport/Content/Hand").GetComponent<UI_WeaponSelectItem>();

        _exitButton.onClick.AddListener(CloseSound);
    }

    private void Start()
    {
        _sword.Button.onClick.AddListener(OnSelectedSword);
        _axe.Button.onClick.AddListener(OnSelectedAxe);
        _hammer.Button.onClick.AddListener(OnSelectedHammer);
        _stick.Button.onClick.AddListener(OnSelectedStick);
        _hand.Button.onClick.AddListener(OnSelectedHand);
    }

    public void Open()
    {
        UI_ClickSound.Instance.ClickPlay();
        gameObject.SetActive(true);
        _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
        _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
        _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
        _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
        _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

        switch (GameDataManager.Instance.EquipWeapon)
        {
            case WeaponType.Sword:
                _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                break;
            case WeaponType.Axe:
                _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                break;
            case WeaponType.Hammer:
                _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                break;
            case WeaponType.Stick:
                _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                break;
            case WeaponType.Hand:
                _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                break;
        }

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

    void OnSelectedSword()
    {
        UI_ClickSound.Instance.ClickPlay();             //
        if (GameDataManager.Instance.SwordOpen)
        {                                                 //
            GameDataManager.Instance.EquipWeapon=WeaponType.Sword;

            _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
            _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
            _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
            _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
            _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

            switch (GameDataManager.Instance.EquipWeapon)
            {
                case WeaponType.Sword:
                    _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                    break;
                case WeaponType.Axe:
                    _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                    break;
                case WeaponType.Hammer:
                    _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                    break;
                case WeaponType.Stick:
                    _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                    break;
                case WeaponType.Hand:
                    _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                    break;
            }
            GameDataManager.Instance.SaveData();
        }
        else
        {                                                  //                                             //
            if(GameDataManager.Instance.PlayerGold - _sword.PriceValue >= 0 && !GameDataManager.Instance.SwordOpen)
            {                                             //
                GameDataManager.Instance.PlayerGold-= _sword.PriceValue;
                GameDataManager.Instance.SwordOpen = true; //

                GameDataManager.Instance.EquipWeapon = WeaponType.Sword; //

                _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
                _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
                _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
                _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
                _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

                switch (GameDataManager.Instance.EquipWeapon)
                {
                    case WeaponType.Sword:
                        _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                        break;
                    case WeaponType.Axe:
                        _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                        break;
                    case WeaponType.Hammer:
                        _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                        break;
                    case WeaponType.Stick:
                        _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                        break;
                    case WeaponType.Hand:
                        _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                        break;
                }

                GameDataManager.Instance.SaveData();
            }
        }
    }

    void OnSelectedAxe()
    {
        UI_ClickSound.Instance.ClickPlay();
        if (GameDataManager.Instance.AxeOpen)
        {
            GameDataManager.Instance.EquipWeapon = WeaponType.Axe;

            _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
            _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
            _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
            _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
            _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

            switch (GameDataManager.Instance.EquipWeapon)
            {
                case WeaponType.Sword:
                    _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                    break;
                case WeaponType.Axe:
                    _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                    break;
                case WeaponType.Hammer:
                    _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                    break;
                case WeaponType.Stick:
                    _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                    break;
                case WeaponType.Hand:
                    _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                    break;
            }
            GameDataManager.Instance.SaveData();
        }
        else
        {
            if (GameDataManager.Instance.PlayerGold - _axe.PriceValue >= 0 && !GameDataManager.Instance.AxeOpen)
            {
                GameDataManager.Instance.PlayerGold -= _axe.PriceValue;
                GameDataManager.Instance.AxeOpen = true;

                GameDataManager.Instance.EquipWeapon = WeaponType.Axe;

                _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
                _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
                _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
                _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
                _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

                switch (GameDataManager.Instance.EquipWeapon)
                {
                    case WeaponType.Sword:
                        _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                        break;
                    case WeaponType.Axe:
                        _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                        break;
                    case WeaponType.Hammer:
                        _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                        break;
                    case WeaponType.Stick:
                        _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                        break;
                    case WeaponType.Hand:
                        _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                        break;
                }

                GameDataManager.Instance.SaveData();
            }
        }
    }

    void OnSelectedHammer()
    {
        UI_ClickSound.Instance.ClickPlay();                    //
        if (GameDataManager.Instance.HammerOpen)
        {                                                 //
            GameDataManager.Instance.EquipWeapon = WeaponType.Hammer;

            _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
            _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
            _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
            _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
            _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

            switch (GameDataManager.Instance.EquipWeapon)
            {
                case WeaponType.Sword:
                    _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                    break;
                case WeaponType.Axe:
                    _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                    break;
                case WeaponType.Hammer:
                    _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                    break;
                case WeaponType.Stick:
                    _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                    break;
                case WeaponType.Hand:
                    _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                    break;
            }
            GameDataManager.Instance.SaveData();
        }
        else
        {                                                  //                                    //
            if (GameDataManager.Instance.PlayerGold - _hammer.PriceValue >= 0 && !GameDataManager.Instance.HammerOpen)
            {                                             //
                GameDataManager.Instance.PlayerGold -= _hammer.PriceValue;
                GameDataManager.Instance.HammerOpen = true; //

                GameDataManager.Instance.EquipWeapon = WeaponType.Hammer; //

                _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
                _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
                _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
                _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
                _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

                switch (GameDataManager.Instance.EquipWeapon)
                {
                    case WeaponType.Sword:
                        _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                        break;
                    case WeaponType.Axe:
                        _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                        break;
                    case WeaponType.Hammer:
                        _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                        break;
                    case WeaponType.Stick:
                        _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                        break;
                    case WeaponType.Hand:
                        _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                        break;
                }

                GameDataManager.Instance.SaveData();
            }
        }
    }

    void OnSelectedStick()
    {
        UI_ClickSound.Instance.ClickPlay();                     //
        if (GameDataManager.Instance.StickOpen)
        {                                                 //
            GameDataManager.Instance.EquipWeapon = WeaponType.Stick;

            _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
            _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
            _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
            _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
            _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

            switch (GameDataManager.Instance.EquipWeapon)
            {
                case WeaponType.Sword:
                    _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                    break;
                case WeaponType.Axe:
                    _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                    break;
                case WeaponType.Hammer:
                    _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                    break;
                case WeaponType.Stick:
                    _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                    break;
                case WeaponType.Hand:
                    _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                    break;
            }
            GameDataManager.Instance.SaveData();
        }
        else
        {                                                  //                                             //
            if (GameDataManager.Instance.PlayerGold - _stick.PriceValue >= 0 && !GameDataManager.Instance.StickOpen)
            {                                             //
                GameDataManager.Instance.PlayerGold -= _stick.PriceValue;
                GameDataManager.Instance.StickOpen = true; //

                GameDataManager.Instance.EquipWeapon = WeaponType.Stick; //

                _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
                _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
                _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
                _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
                _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

                switch (GameDataManager.Instance.EquipWeapon)
                {
                    case WeaponType.Sword:
                        _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                        break;
                    case WeaponType.Axe:
                        _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                        break;
                    case WeaponType.Hammer:
                        _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                        break;
                    case WeaponType.Stick:
                        _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                        break;
                    case WeaponType.Hand:
                        _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                        break;
                }

                GameDataManager.Instance.SaveData();
            }
        }
    }

    void OnSelectedHand()
    {
        UI_ClickSound.Instance.ClickPlay();                       //
        if (GameDataManager.Instance.HandOpen)
        {                                                 //
            GameDataManager.Instance.EquipWeapon = WeaponType.Hand;

            _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
            _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
            _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
            _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
            _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

            switch (GameDataManager.Instance.EquipWeapon)
            {
                case WeaponType.Sword:
                    _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                    break;
                case WeaponType.Axe:
                    _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                    break;
                case WeaponType.Hammer:
                    _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                    break;
                case WeaponType.Stick:
                    _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                    break;
                case WeaponType.Hand:
                    _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                    break;
            }
            GameDataManager.Instance.SaveData();
        }
        else
        {                                                  //                                             //
            if (GameDataManager.Instance.PlayerGold - _hand.PriceValue >= 0 && !GameDataManager.Instance.HandOpen)
            {                                             //
                GameDataManager.Instance.PlayerGold -= _hand.PriceValue;
                GameDataManager.Instance.HandOpen = true; //

                GameDataManager.Instance.EquipWeapon = WeaponType.Hand; //

                _sword.ButtonSetting(_swordPrice, false, GameDataManager.Instance.SwordOpen);
                _axe.ButtonSetting(_axePrice, false, GameDataManager.Instance.AxeOpen);
                _hammer.ButtonSetting(_hammerPrice, false, GameDataManager.Instance.HammerOpen);
                _stick.ButtonSetting(_stickPrice, false, GameDataManager.Instance.StickOpen);
                _hand.ButtonSetting(_handPrice, false, GameDataManager.Instance.HandOpen);

                switch (GameDataManager.Instance.EquipWeapon)
                {
                    case WeaponType.Sword:
                        _sword.ButtonSetting(_swordPrice, true, GameDataManager.Instance.SwordOpen);
                        break;
                    case WeaponType.Axe:
                        _axe.ButtonSetting(_axePrice, true, GameDataManager.Instance.AxeOpen);
                        break;
                    case WeaponType.Hammer:
                        _hammer.ButtonSetting(_hammerPrice, true, GameDataManager.Instance.HammerOpen);
                        break;
                    case WeaponType.Stick:
                        _stick.ButtonSetting(_stickPrice, true, GameDataManager.Instance.StickOpen);
                        break;
                    case WeaponType.Hand:
                        _hand.ButtonSetting(_handPrice, true, GameDataManager.Instance.HandOpen);
                        break;
                }

                GameDataManager.Instance.SaveData();
            }
        }
    }

}
