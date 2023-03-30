using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    GameObject _camera1;
    GameObject _camera2;

    Animator _player;

    Button _lobbyButton;
    TextMeshProUGUI _lobbyText;

    private void Start()
    {
        _camera1 = GameObject.Find("camera1").gameObject;
        _camera2 = GameObject.Find("camera2").gameObject;
        _player = GameObject.Find("Player").GetComponent<Animator>();
        _lobbyButton = GameObject.Find("RobbyButton").GetComponent<Button>();
        _lobbyText = GameObject.Find("RobbyButton/Text").GetComponent<TextMeshProUGUI>();




        LanguageCheck();
        GameDataManager.Instance.ChangeLanguage += LanguageCheck;
        StartCoroutine(Camera1Off());
        _lobbyButton.onClick.AddListener(OnLobby);
        _lobbyButton.gameObject.SetActive(false);
    }
    IEnumerator Camera1Off()
    {
        yield return new WaitForSeconds(3.0f);
        _camera1.SetActive(false);
        StartCoroutine(PlayerSit());
    }

    IEnumerator PlayerSit()
    {
        yield return new WaitForSeconds(3.0f);
        _player.SetTrigger("Action");
        StartCoroutine(LobbyOn());
    }

    IEnumerator LobbyOn()
    {
        yield return new WaitForSeconds(4.0f);
        _lobbyButton.gameObject.SetActive(true);
    }

    void LanguageCheck()
    {
        _lobbyText.text = GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].lobby;
        
    }

    void OnLobby()
    {
        SceneManager.LoadScene((int)GameScene.Lobby);
    }
}
