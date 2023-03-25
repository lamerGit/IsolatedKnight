using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponSelectGroup : MonoBehaviour
{
    Button _exitButton;
    private void Awake()
    {
        _exitButton = transform.Find("ExitButton").GetComponent<Button>();

        _exitButton.onClick.AddListener(Close);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
