using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LobbyOption : MonoBehaviour
{
    Button _cancelButton;

    Slider _bgmSlider;
    Slider _cfxSlider;

    Button _quitButton;

    AudioSource _cfxChangeAudio;

    TextMeshProUGUI _titleText;
    TextMeshProUGUI _bgmText;
    TextMeshProUGUI _cfxText;

    Button _usButton;
    Button _krButton;

    TextMeshProUGUI _quitText;

    private void Awake()
    {
        _cfxChangeAudio = GetComponent<AudioSource>();

        _cancelButton = transform.Find("Cancel_Button").GetComponent<Button>();

        _bgmSlider = transform.Find("BGMSlider").GetComponent<Slider>();
        _cfxSlider = transform.Find("CFXSlider").GetComponent<Slider>();

        _quitButton = transform.Find("QuitButton").GetComponent<Button>();

        _titleText=transform.Find("title").GetComponent<TextMeshProUGUI>();
        _bgmText=transform.Find("BGM").GetComponent<TextMeshProUGUI>();
        _cfxText = transform.Find("CFX").GetComponent<TextMeshProUGUI>();

        _usButton = transform.Find("UsButton").GetComponent<Button>();
        _krButton = transform.Find("KrButton").GetComponent<Button>();

        _quitText= transform.Find("QuitButton/Text").GetComponent<TextMeshProUGUI>();

        _cancelButton.onClick.AddListener(CloseSound);

        _bgmSlider.onValueChanged.AddListener(BgmChange);
        _cfxSlider.onValueChanged.AddListener(CfxChange);

        _quitButton.onClick.AddListener(GameQuit);

        _usButton.onClick.AddListener(UsLanguage);
        _krButton.onClick.AddListener(KrLanguage);
        
    }

    private void Start()
    {
        LanguageCheck();

        GameDataManager.Instance.ChangeLanguage += LanguageCheck;
    }

    void KrLanguage()
    {
        GameDataManager.Instance.LanguageType = LanguageType.kr;
        GameDataManager.Instance.SaveData();
    }
    void UsLanguage()
    {
        GameDataManager.Instance.LanguageType = LanguageType.us;
        GameDataManager.Instance.SaveData();
    }

    void LanguageCheck()
    {
        _titleText.text= GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].option;
        _bgmText.text= GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].BGM;
        _cfxText.text= GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].CFX;
        _quitText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].quit;
    }


    void GameQuit()
    {
        UI_ClickSound.Instance.ClickPlay();
        GameDataManager.Instance.SaveData();

        Application.Quit();
    }


    public void Open()
    {
        gameObject.SetActive(true);
        _bgmSlider.value = GameDataManager.Instance.BgmVolume;
        _cfxSlider.value = GameDataManager.Instance.CfxVolume;
    }

    private void CfxChange(float arg0)
    {
        if (arg0 == GameDataManager.Instance.CfxVolume)
            return;

        _cfxChangeAudio.Play();
        GameDataManager.Instance.CfxVolume = arg0;
    }

    private void BgmChange(float arg0)
    {
        GameDataManager.Instance.BgmVolume = arg0;
        
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

    
}
