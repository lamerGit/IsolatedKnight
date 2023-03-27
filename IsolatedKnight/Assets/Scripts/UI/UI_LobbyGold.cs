using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_LobbyGold : MonoBehaviour
{
    TextMeshProUGUI _goldText;

    private void Awake()
    {
        _goldText=transform.Find("GoldText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        string result;
        result = string.Format("{0:#,0}", GameDataManager.Instance.PlayerGold);

        _goldText.text = result;

        GameDataManager.Instance.ChangeGold += ChangeGoldText;
    }


    void ChangeGoldText()
    {
        string result;
        result = string.Format("{0:#,0}", GameDataManager.Instance.PlayerGold);

        _goldText.text = result;
    }
}
