using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyOptionButton : MonoBehaviour
{
    Button _optionButton;

    private void Awake()
    {
        _optionButton = GetComponent<Button>();

        _optionButton.onClick.AddListener(OnOptionButton);
    }

    void OnOptionButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        LobbyManager.LobbyUIManager.LobbyOption.Open();
    }
}
