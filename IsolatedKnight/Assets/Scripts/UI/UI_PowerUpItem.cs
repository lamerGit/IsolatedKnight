using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerUpItem : MonoBehaviour
{
    TextMeshProUGUI _price;

    Button _button;
    public Button Button { get { return _button; } private set { _button = value; } }

    TextMeshProUGUI _tierText;

    int _priceValue=0;

    public int PriceValue
    {
        get { return _priceValue; }
    }

    private void Awake()
    {
        _price=transform.Find("MoneyValue").GetComponent<TextMeshProUGUI>();

        Button=transform.Find("Button").GetComponent<Button>();

        _tierText = transform.Find("TierText").GetComponent<TextMeshProUGUI>();
        
    }

    public void ButtonSetting(int price,int tier,int maxTier)
    {
        _priceValue=price;

        string result;
        result= string.Format("{0:#,0}", price);

        _price.text = result;
        _tierText.text = $"{tier}/{maxTier}";

        if(tier==maxTier)
        {
            _price.text = "";
        }
    }

}
