using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameSet : MonoBehaviour
{
    UI_DamageRank _damageRank;
    TextMeshProUGUI _gameSetText;

    Button _tryAgeinButton;
    Button _robbyButton;

    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _damageRank = transform.Find("Scroll View").GetComponent<UI_DamageRank>();
        _gameSetText=transform.Find("GameSetText").GetComponent<TextMeshProUGUI>();

        _tryAgeinButton=transform.Find("TryAgeinButton").GetComponent<Button>();
        _robbyButton = transform.Find("RobbyButton").GetComponent<Button>();

        _tryAgeinButton.onClick.AddListener(OnTryAgeinButton);
        _robbyButton.onClick.AddListener(OnRobbyButton);
    }

    public void Open(bool win)
    {
        if (gameObject.activeSelf)
            return;
      
        gameObject.SetActive(true);
        
        _damageRank.Open();

        if(win)
        {
            _gameSetText.color = Color.yellow;
            _gameSetText.text = "Win";
        }else
        {
            _gameSetText.color = Color.red;
            _gameSetText.text = "Game Over";
            _audioSource.Play();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void OnTryAgeinButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        SceneManager.LoadScene((int)GameScene.GameScene);
    }

    void OnRobbyButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        SceneManager.LoadScene((int)GameScene.Lobby);
    }
}
