using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public UI_LevelUpButtonGroup LevelUpButtonGroup { get; private set; }

    public UI_Stamina StaminaUI { get; private set; }

    public UI_Exp ExpUI { get; private set; }

    public UI_SkillSlotGroup SkillSlotGroup { get; private set; }

    public UI_Timer TimerUI { get; private set; }   

    public UI_BossRewardButtonGroup BossRewardButtonGroup { get; private set; }

    public GameObject BlackOutUI { get; private set; }

    public UI_GameSet GameSetUI { get; private set; }

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

        GameObject e = Resources.Load<GameObject>($"Prefabs/ExpUI");
        GameObject InstExpUI = Object.Instantiate(e, Managers.Instance.Canvas.transform);
        InstExpUI.name=e.name;

        ExpUI=InstExpUI.GetComponent<UI_Exp>();


        GameObject skillSlotGroup= Resources.Load<GameObject>($"Prefabs/SkillSlotGroupUI");
        GameObject InstSlotGroup= Object.Instantiate(skillSlotGroup, Managers.Instance.Canvas.transform);
        InstSlotGroup.name=skillSlotGroup.name;

        SkillSlotGroup=InstSlotGroup.GetComponent<UI_SkillSlotGroup>();

        GameObject timerUI= Resources.Load<GameObject>($"Prefabs/TimerUI");
        GameObject InstTimerUI= Object.Instantiate(timerUI, Managers.Instance.Canvas.transform);
        InstTimerUI.name=timerUI.name;

        TimerUI=InstTimerUI.GetComponent<UI_Timer>();

        GameObject bossRewardUI= Resources.Load<GameObject>($"Prefabs/BossRewardButtonGroup");
        GameObject InstBossRewardUI= Object.Instantiate(bossRewardUI, Managers.Instance.Canvas.transform);
        InstBossRewardUI.name=bossRewardUI.name;

        BossRewardButtonGroup=InstBossRewardUI.GetComponent<UI_BossRewardButtonGroup>();
        BossRewardButtonGroup.Close();

        GameObject blackOutUI= Resources.Load<GameObject>($"Prefabs/BlackOutUI");
        BlackOutUI= Object.Instantiate(blackOutUI, Managers.Instance.Canvas.transform);
        BlackOutUI.gameObject.SetActive(false);

        GameObject gameSetUI= Resources.Load<GameObject>($"Prefabs/GameSetUI");
        GameObject InstGameSetUI= Object.Instantiate(gameSetUI, Managers.Instance.Canvas.transform);
        InstGameSetUI.name=gameSetUI.name;

        GameSetUI = InstGameSetUI.GetComponent<UI_GameSet>();
        GameSetUI.Close();
    }
}
