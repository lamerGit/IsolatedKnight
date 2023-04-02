using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LobbyGroup : MonoBehaviour
{
    Button _startButton = null;
    Button _powerUpButton = null;
    Button _weaponButton = null;


    RectTransform _rect = null;

    TextMeshProUGUI _titleText=null;

    TextMeshProUGUI _startButtonText = null;
    TextMeshProUGUI _powerUpButtonText = null;
    TextMeshProUGUI _weaponButtonText = null;
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();

        _startButton=transform.Find("StartButton").GetComponent<Button>();
        _powerUpButton = transform.Find("PowerUpButton").GetComponent<Button>();
        _weaponButton = transform.Find("WeaponButton").GetComponent<Button>();

        _titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();


        _startButtonText = transform.Find("StartButton/Text").GetComponent<TextMeshProUGUI>();
        _powerUpButtonText = transform.Find("PowerUpButton/Text").GetComponent<TextMeshProUGUI>();
        _weaponButtonText = transform.Find("WeaponButton/Text").GetComponent<TextMeshProUGUI>();
       
        _startButton.onClick.AddListener(OnStartButton);
        _powerUpButton.onClick.AddListener(OnPowerUpGroup);
        _weaponButton.onClick.AddListener(OnWeaponSelectGroup);
        
    }

    private void Start()
    {
        Camera camera = Camera.main;

        _rect.sizeDelta=new Vector2(camera.pixelWidth,camera.pixelHeight);


        LanguageCheck();

        GameDataManager.Instance.ChangeLanguage += LanguageCheck;

    }


    void LanguageCheck()
    {
        _titleText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].lonelyKnight;
        _startButtonText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Start;
        _powerUpButtonText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].PowerUp;
        _weaponButtonText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Weapon;

    }

    

    void OnStartButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        SceneManager.LoadScene((int)GameScene.GameScene);
    }

    void OnPowerUpGroup()
    {
        LobbyManager.LobbyUIManager.PowerUpGroup.Open();
    }

    void OnWeaponSelectGroup()
    {
        LobbyManager.LobbyUIManager.WeaponSelectGroup.Open();
    }

}
