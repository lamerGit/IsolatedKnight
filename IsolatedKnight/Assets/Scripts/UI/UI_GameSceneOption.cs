using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameSceneOption : MonoBehaviour
{
    Button _cancelButton;

    Slider _bgmSlider;
    Slider _cfxSlider;

    AudioSource _cfxChangeAudio;

    TextMeshProUGUI _titleText;
    TextMeshProUGUI _bgmText;
    TextMeshProUGUI _cfxText;

    Button _usButton;
    Button _krButton;

    Button _reStartButton;
    Button _giveUpButton;

    TextMeshProUGUI _restartText;
    TextMeshProUGUI _giveUpText;

    private void Awake()
    {
        _cfxChangeAudio = GetComponent<AudioSource>();

        _cancelButton = transform.Find("Cancel_Button").GetComponent<Button>();

        _bgmSlider = transform.Find("BGMSlider").GetComponent<Slider>();
        _cfxSlider = transform.Find("CFXSlider").GetComponent<Slider>();

        _titleText = transform.Find("title").GetComponent<TextMeshProUGUI>();
        _bgmText = transform.Find("BGM").GetComponent<TextMeshProUGUI>();
        _cfxText = transform.Find("CFX").GetComponent<TextMeshProUGUI>();

        _reStartButton = transform.Find("ReStartButton").GetComponent<Button>();
        _giveUpButton = transform.Find("GiveUpButton").GetComponent<Button>();

        _restartText = transform.Find("ReStartButton/Text").GetComponent<TextMeshProUGUI>();
        _giveUpText = transform.Find("GiveUpButton/Text").GetComponent<TextMeshProUGUI>();

        _usButton = transform.Find("UsButton").GetComponent<Button>();
        _krButton = transform.Find("KrButton").GetComponent<Button>();

        _cancelButton.onClick.AddListener(CloseSound);

        _bgmSlider.onValueChanged.AddListener(BgmChange);
        _cfxSlider.onValueChanged.AddListener(CfxChange);

        _reStartButton.onClick.AddListener(OnRestartButton);
        _giveUpButton.onClick.AddListener(OnGiveUpButton);

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
        _titleText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].option;
        _bgmText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].BGM;
        _cfxText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].CFX;
        _restartText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].restart;
        _giveUpText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].giveup;
    }


    void OnGiveUpButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        Managers.Object.MyPlayer.OnDie();
        Managers.GameManager.State = GameState.PlayerDie;
        gameObject.SetActive(false);
    }

    void OnRestartButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        SceneManager.LoadScene((int)GameScene.GameScene);
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
