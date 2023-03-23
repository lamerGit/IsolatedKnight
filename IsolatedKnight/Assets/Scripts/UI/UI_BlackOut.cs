using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BlackOut : MonoBehaviour
{
    RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();

        _rect.sizeDelta = new Vector2(Screen.width*2.0f, Screen.height*2.0f);
    }
}
