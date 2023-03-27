using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameSceneOption : MonoBehaviour
{
    Button _cancelButton;

    Slider _bgmSlider;
    Slider _cfxSlider;

    AudioSource _cfxChangeAudio;

    Button _reStartButton;
    Button _giveUpButton;

    private void Awake()
    {
        _cfxChangeAudio = GetComponent<AudioSource>();

        _cancelButton = transform.Find("Cancel_Button").GetComponent<Button>();

        _bgmSlider = transform.Find("BGMSlider").GetComponent<Slider>();
        _cfxSlider = transform.Find("CFXSlider").GetComponent<Slider>();

        _reStartButton = transform.Find("ReStartButton").GetComponent<Button>();
        _giveUpButton = transform.Find("GiveUpButton").GetComponent<Button>();

        _cancelButton.onClick.AddListener(CloseSound);

        _bgmSlider.onValueChanged.AddListener(BgmChange);
        _cfxSlider.onValueChanged.AddListener(CfxChange);

        _reStartButton.onClick.AddListener(OnRestartButton);
        _giveUpButton.onClick.AddListener(OnGiveUpButton);

    }

    void OnGiveUpButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        Managers.Object.MyPlayer.OnDie();
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
