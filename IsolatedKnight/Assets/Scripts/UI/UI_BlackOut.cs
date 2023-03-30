using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BlackOut : MonoBehaviour
{
    RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();

        Camera camera = Camera.main;

        _rect.sizeDelta = new Vector2(camera.pixelWidth*2.0f, camera.pixelHeight*2.0f);
    }
}
