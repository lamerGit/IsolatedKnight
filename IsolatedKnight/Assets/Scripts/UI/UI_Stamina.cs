using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stamina : MonoBehaviour
{
    Image _image;

    private void Awake()
    {
        _image=transform.Find("Background").transform.Find("Stamina").GetComponent<Image>();

    }
    public void AmountChange(float current,float max)
    {
        _image.fillAmount=current/max;
    }

    public void OverloadColor(bool result)
    {
        if(result)
        {
            _image.color = Color.red;
        }else
        {
            _image.color= Color.yellow;
        }
    }
}
