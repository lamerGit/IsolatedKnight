using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LobbyGroup : MonoBehaviour
{
    Button _startButton;
    Button _powerUpButton;
    Button _optionButton;
    Button _weaponButton;

    TextMeshProUGUI _goldText;
    private void Awake()
    {
        _startButton=transform.Find("StartButton").GetComponent<Button>();
        _powerUpButton = transform.Find("PowerUpButton").GetComponent<Button>();
        _weaponButton = transform.Find("WeaponButton").GetComponent<Button>();
        _optionButton = transform.Find("OptionButton").GetComponent<Button>();

        _goldText=transform.Find("GoldUIGroup/GoldText").GetComponent<TextMeshProUGUI>();

        _startButton.onClick.AddListener(OnStartButton);
        _powerUpButton.onClick.AddListener(OnPowerUpGroup);
        _weaponButton.onClick.AddListener(OnWeaponSelectGroup);
    }

    private void Start()
    {
        string result;
        result = string.Format("{0:#,0}", GameDataManager.Instance.PlayerGold);

        _goldText.text = result;

        GameDataManager.Instance.ChangeGold += ChangeGoldText;
    }

    void OnStartButton()
    {
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

    void ChangeGoldText()
    {
        string result;
        result = string.Format("{0:#,0}", GameDataManager.Instance.PlayerGold);

        _goldText.text = result;
    }
}
