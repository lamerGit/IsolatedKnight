using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PowerUpGroup : MonoBehaviour
{
    private void Awake()
    {
        Close();
    }

    void Close()
    {
        gameObject.SetActive(false);
    }
}
