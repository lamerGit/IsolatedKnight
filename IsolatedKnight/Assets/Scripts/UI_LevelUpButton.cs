using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_LevelUpButton : MonoBehaviour
{
    LevelUpOption _option;
    Button _button;

    UI_LevelUpButtonGroup _group;

    public LevelUpOption Option
    {
        get { return _option; }
        set { _option = value; }
    }

    private void Awake()
    {  
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButton);

        _group=GetComponentInParent<UI_LevelUpButtonGroup>();
    }

    void OnButton()
    {
        Debug.Log(Option);
        Managers.GameManager.State = GameState.Nomal;

        _group.Close();
    }
}
