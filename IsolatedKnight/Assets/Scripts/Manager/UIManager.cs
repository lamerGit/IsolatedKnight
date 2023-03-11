using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public UI_LevelUpButtonGroup LevelUpButtonGroup { get; private set; }


    //���� ���϶��� ��Ÿ���� UI
    public void GameScenInit()
    {
        GameObject l= Resources.Load<GameObject>($"Prefabs/LevelUpButtonGroup");
        GameObject Inst=Object.Instantiate(l,Managers.Instance.Canvas.transform);
        Inst.name = l.name;
        
        LevelUpButtonGroup=Inst.GetComponent<UI_LevelUpButtonGroup>();
        LevelUpButtonGroup.Close();
    }
}
