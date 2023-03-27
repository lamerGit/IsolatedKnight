using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Gold : MonoBehaviour
{
    TextMeshProUGUI _levetText;

    private void Awake()
    {
        _levetText = transform.Find("GoldText").GetComponent<TextMeshProUGUI>();
    }

    public void GoldChange(int gold)
    {
        string result;
        result = string.Format("{0:#,0}", gold);

        _levetText.text = result;
    }
}
