using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LobbyGroup : MonoBehaviour
{
    Button _startButton;
    Button _powerUpButton;
    Button _weaponButton;

    
    RectTransform _rect;
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();

        _startButton=transform.Find("StartButton").GetComponent<Button>();
        _powerUpButton = transform.Find("PowerUpButton").GetComponent<Button>();
        _weaponButton = transform.Find("WeaponButton").GetComponent<Button>();
       

        _startButton.onClick.AddListener(OnStartButton);
        _powerUpButton.onClick.AddListener(OnPowerUpGroup);
        _weaponButton.onClick.AddListener(OnWeaponSelectGroup);
        
    }

    private void Start()
    {
        Camera camera = Camera.main;

        _rect.sizeDelta=new Vector2(camera.pixelWidth,camera.pixelHeight);


        
    }

    

    void OnStartButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        SceneManager.LoadScene((int)GameScene.GameScene);
    }

    void OnPowerUpGroup()
    {
        LobbyManager.LobbyUIManager.PowerUpGroup.Open();
    }

    void OnWeaponSelectGroup()
    {
        LobbyManager.LobbyUIManager.WeaponSelectGroup.Open();
    }

}
