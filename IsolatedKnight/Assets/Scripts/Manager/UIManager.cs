using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public UI_LevelUpButtonGroup LevelUpButtonGroup { get; private set; }

    public UI_Stamina StaminaUI { get; private set; }

    //게임 씬일때만 나타나는 UI
    public void GameScenInit()
    {
        GameObject l= Resources.Load<GameObject>($"Prefabs/LevelUpButtonGroup");
        GameObject Inst=Object.Instantiate(l,Managers.Instance.Canvas.transform);
        Inst.name = l.name;
        
        LevelUpButtonGroup=Inst.GetComponent<UI_LevelUpButtonGroup>();
        LevelUpButtonGroup.Close();

        GameObject s= Resources.Load<GameObject>($"Prefabs/StaminaUI");
        GameObject InstStaminaUI= Object.Instantiate(s, Managers.Instance.Canvas.transform);
        InstStaminaUI.name=s.name;

        StaminaUI=InstStaminaUI.GetComponent<UI_Stamina>();
    }
}
