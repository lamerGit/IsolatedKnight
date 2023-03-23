using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public UI_PowerUpGroup PowerUpGroup { get; private set; }
    private void Start()
    {
        PowerUpGroup=FindObjectOfType<UI_PowerUpGroup>();
    }
}
