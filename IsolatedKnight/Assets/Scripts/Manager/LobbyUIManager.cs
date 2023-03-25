using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager 
{
    public UI_LobbyGroup LobbyGroup { get;private set; }

    public UI_PowerUpGroup PowerUpGroup { get; private set; }

    public UI_WeaponSelectGroup WeaponSelectGroup { get; private set;}

    public void LobbySceneInit()
    {
        GameObject lobbyGroup= Resources.Load<GameObject>($"Prefabs/LobbyUIGroup");
        GameObject InstLobbyGroup= Object.Instantiate(lobbyGroup, LobbyManager.Instance.Canvas.transform);
        InstLobbyGroup.name = lobbyGroup.name;

        LobbyGroup=InstLobbyGroup.GetComponent<UI_LobbyGroup>();


        GameObject powerUpGroup= Resources.Load<GameObject>($"Prefabs/PowerUpGroup");
        GameObject InstPowerUpGroup= Object.Instantiate(powerUpGroup, LobbyManager.Instance.Canvas.transform);
        InstPowerUpGroup.name = powerUpGroup.name;

        PowerUpGroup=InstPowerUpGroup.GetComponent<UI_PowerUpGroup>();
        PowerUpGroup.Close();

        GameObject weaponSelectGroup= Resources.Load<GameObject>($"Prefabs/WeaponSelectGroup");
        GameObject InstWeaponSelectGroup= Object.Instantiate(weaponSelectGroup, LobbyManager.Instance.Canvas.transform);
        InstWeaponSelectGroup.name = weaponSelectGroup.name;

        WeaponSelectGroup=InstWeaponSelectGroup.GetComponent<UI_WeaponSelectGroup>();
        WeaponSelectGroup.Close();

    }
}
