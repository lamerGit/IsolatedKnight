using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameSet : MonoBehaviour
{
    UI_DamageRank _damageRank;
    TextMeshProUGUI _gameSetText;

    Button _tryAgeinButton;
    Button _robbyButton;

    AudioSource _audioSource;

    TextMeshProUGUI _lobbyText;
    TextMeshProUGUI _tryAgeinText;

    bool _win;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _damageRank = transform.Find("Scroll View").GetComponent<UI_DamageRank>();
        _gameSetText=transform.Find("GameSetText").GetComponent<TextMeshProUGUI>();

        _tryAgeinButton=transform.Find("TryAgeinButton").GetComponent<Button>();
        _robbyButton = transform.Find("RobbyButton").GetComponent<Button>();

        _lobbyText= transform.Find("RobbyButton/Text").GetComponent<TextMeshProUGUI>();
        _tryAgeinText = transform.Find("TryAgeinButton/Text").GetComponent<TextMeshProUGUI>();

        _tryAgeinButton.onClick.AddListener(OnTryAgeinButton);
        _robbyButton.onClick.AddListener(OnRobbyButton);
    }

    private void Start()
    {
        GameDataManager.Instance.ChangeLanguage += LanguageCheck;
    }
    void LanguageCheck()
    {
        _lobbyText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].lobby;
        _tryAgeinText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].tryagein;
        if (_win)
        {
            _gameSetText.color = Color.yellow;
            _gameSetText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].win;
        }
        else
        {
            _gameSetText.color = Color.red;
            _gameSetText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].gameover;
        }
    }
    public void Open(bool win)
    {
        if (gameObject.activeSelf)
            return;

        Managers.Object.MyPlayer.GoldSave();
      
        gameObject.SetActive(true);
        
        _damageRank.Open();

        _win=win;
        if(win)
        {
            _gameSetText.color = Color.yellow;
            _gameSetText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].win;
        }else
        {
            _gameSetText.color = Color.red;
            _gameSetText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].gameover;
            _audioSource.Play();
        }

        LanguageCheck();

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void OnTryAgeinButton()
    {
        UI_ClickSound.Instance.ClickPlay();

        if (_win)
        {
            switch (Managers.Object.MyPlayer.EquipWeaponType)
            {
                case WeaponType.Sword:
                    if (!GameDataManager.Instance.SwordClear)
                    {
                        GameDataManager.Instance.SwordClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_sword, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.SwordEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.GameScene);
                    }
                    break;
                case WeaponType.Axe:
                    if (!GameDataManager.Instance.AxeClear)
                    {
                        GameDataManager.Instance.AxeClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_axe, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.AxeEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.GameScene);
                    }
                    break;
                case WeaponType.Hammer:
                    if (!GameDataManager.Instance.HammerClear)
                    {
                        GameDataManager.Instance.HammerClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_hammer, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.HammerEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.GameScene);
                    }
                    break;
                case WeaponType.Stick:
                    if (!GameDataManager.Instance.StickClear)
                    {
                        GameDataManager.Instance.StickClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_staff, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.StickEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.GameScene);
                    }
                    break;
                case WeaponType.Hand:
                    if (!GameDataManager.Instance.HandClear)
                    {
                        GameDataManager.Instance.HandClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_hand, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.HandEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.GameScene);
                    }
                    break;
            }


        }
        else
        {
            SceneManager.LoadScene((int)GameScene.GameScene);
        }



       
    }

    void OnRobbyButton()
    {
        UI_ClickSound.Instance.ClickPlay();

        if(_win)
        {
            switch (Managers.Object.MyPlayer.EquipWeaponType)
            {
                case WeaponType.Sword:
                    if(!GameDataManager.Instance.SwordClear)
                    {
                        GameDataManager.Instance.SwordClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_sword, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.SwordEnding);
                    }else
                    {
                        SceneManager.LoadScene((int)GameScene.Lobby);
                    }
                    break;
                case WeaponType.Axe:
                    if (!GameDataManager.Instance.AxeClear)
                    {
                        GameDataManager.Instance.AxeClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_axe, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.AxeEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.Lobby);
                    }
                    break;
                case WeaponType.Hammer:
                    if (!GameDataManager.Instance.HammerClear)
                    {
                        GameDataManager.Instance.HammerClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_hammer, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.HammerEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.Lobby);
                    }
                    break;
                case WeaponType.Stick:
                    if (!GameDataManager.Instance.StickClear)
                    {
                        GameDataManager.Instance.StickClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_staff, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.StickEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.Lobby);
                    }
                    break;
                case WeaponType.Hand:
                    if (!GameDataManager.Instance.HandClear)
                    {
                        GameDataManager.Instance.HandClear = true;
                        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_hand, success => { });
                        GameDataManager.Instance.SaveData();
                        SceneManager.LoadScene((int)GameScene.HandEnding);
                    }
                    else
                    {
                        SceneManager.LoadScene((int)GameScene.Lobby);
                    }
                    break;
            }


        }
        else
        {
            SceneManager.LoadScene((int)GameScene.Lobby);
        }



    }
}
