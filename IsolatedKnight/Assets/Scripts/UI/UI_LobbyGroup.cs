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

    TextMeshProUGUI _goldText;
    private void Awake()
    {
        _startButton=transform.Find("StartButton").GetComponent<Button>();
        _powerUpButton = transform.Find("PowerUpButton").GetComponent<Button>();
        _optionButton = transform.Find("OptionButton").GetComponent<Button>();

        _goldText=transform.Find("GoldUIGroup/GoldText").GetComponent<TextMeshProUGUI>();

        _startButton.onClick.AddListener(OnStartButton);
    }

    void OnStartButton()
    {
        SceneManager.LoadScene((int)GameScene.GameScene);
    }
}
