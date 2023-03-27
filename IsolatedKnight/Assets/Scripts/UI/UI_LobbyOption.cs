using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyOption : MonoBehaviour
{
    Button _cancelButton;

    Slider _bgmSlider;
    Slider _cfxSlider;

    Button _quitButton;

    AudioSource _cfxChangeAudio;

    private void Awake()
    {
        _cfxChangeAudio = GetComponent<AudioSource>();

        _cancelButton=transform.Find("Cancel_Button").GetComponent<Button>();

        _bgmSlider=transform.Find("BGMSlider").GetComponent<Slider>();
        _cfxSlider=transform.Find("CFXSlider").GetComponent <Slider>();

        _quitButton= transform.Find("QuitButton").GetComponent<Button>();

        _cancelButton.onClick.AddListener(CloseSound);

        _bgmSlider.onValueChanged.AddListener(BgmChange);
        _cfxSlider.onValueChanged.AddListener(CfxChange);

        _quitButton.onClick.AddListener(GameQuit);
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
