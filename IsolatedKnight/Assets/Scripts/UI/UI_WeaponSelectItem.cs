using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponSelectItem : MonoBehaviour
{
    TextMeshProUGUI _price;

    Button _button;
    public Button Button { get { return _button; } private set { _button = value; } }

    TextMeshProUGUI _equipText;

    int _priceValue = 0;

    public int PriceValue
    {
        get { return _priceValue; }
    }

    private void Awake()
    {
        _price = transform.Find("MoneyValue").GetComponent<TextMeshProUGUI>();

        Button = transform.Find("Button").GetComponent<Button>();

        _equipText = transform.Find("EquipText").GetComponent<TextMeshProUGUI>();

    }

    public void ButtonSetting(int price, bool euiped,bool open)
    {
        _priceValue = price;

        string result;
        result = string.Format("{0:#,0}", price);

        _price.text = result;
        
        if (open)
        {
            _price.text = "";
        }

        if(euiped)
        {
            _equipText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].equip;
        }
        else
        {
            _equipText.text = "";
        }

    }
}
