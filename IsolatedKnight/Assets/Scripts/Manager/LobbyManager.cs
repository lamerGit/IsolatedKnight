using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    static LobbyManager s_instance;
    public static LobbyManager Instance { get { Init(); return s_instance; } }

    public Canvas Canvas;

    LobbyUIManager _lobbyUiManager = new LobbyUIManager();
    public static LobbyUIManager LobbyUIManager { get { return Instance._lobbyUiManager; } }

    private void Start()
    {

        Canvas = FindObjectOfType<Canvas>();

        Init();

    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@LobbyManagers");
            if (go == null)
            {
                go = new GameObject { name = "@LobbyManagers" };
                go.AddComponent<LobbyManager>();
            }

            //DontDestroyOnLoad(go);
            s_instance = go.GetComponent<LobbyManager>();

            s_instance.LobbySceneInit();
            
        }
    }

    void LobbySceneInit()
    {
        Canvas = FindObjectOfType<Canvas>();

        s_instance._lobbyUiManager.LobbySceneInit();
    }
}
