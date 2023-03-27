using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager 
{
    public UI_LobbyGroup LobbyGroup { get;private set; }

    public UI_PowerUpGroup PowerUpGroup { get; private set; }

    public UI_WeaponSelectGroup WeaponSelectGroup { get; private set;}

    public UI_LobbyOption LobbyOption { get; private set; }

    public UI_LobbyOptionButton LobbyOptionButton { get; private set; }

    public UI_LobbyGold LobbyGold { get; private set; }

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

        GameObject lobbyOption = Resources.Load<GameObject>($"Prefabs/LobbyOption");
        GameObject InstLobbyOption=Object.Instantiate(lobbyOption,LobbyManager.Instance.Canvas.transform);
        InstLobbyOption.name = lobbyOption.name;

        LobbyOption=InstLobbyOption.GetComponent<UI_LobbyOption>();
        LobbyOption.Close();

        GameObject optionButton = Resources.Load<GameObject>($"Prefabs/OptionButton");
        GameObject InstOptionButton=Object.Instantiate(optionButton,LobbyManager.Instance.Canvas.transform);
        InstOptionButton.name = optionButton.name;

        LobbyOptionButton=InstOptionButton.GetComponent<UI_LobbyOptionButton>();

        GameObject goldUIGroup = Resources.Load<GameObject>($"Prefabs/GoldUIGroup");
        GameObject InstGoldUIGroup= Object.Instantiate(goldUIGroup,LobbyManager.Instance.Canvas.transform);
        InstOptionButton.name= goldUIGroup.name;

        LobbyGold=InstGoldUIGroup.GetComponent<UI_LobbyGold>();


    }
}
