using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Exp : MonoBehaviour
{
    Image _expValue;
    TextMeshProUGUI _levetText;

    private void Awake()
    {
        _expValue = transform.Find("Background").transform.Find("Exp").GetComponent<Image>();
        _levetText = transform.Find("Background").transform.Find("LevelText").GetComponent<TextMeshProUGUI>();

    }

    public void AmountChange(float current, float max,int level)
    {
        _expValue.fillAmount = current / max;
        _levetText.text=$"LEVEL {level}";
    }
}
