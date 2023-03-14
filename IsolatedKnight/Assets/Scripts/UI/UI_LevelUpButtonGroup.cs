using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelUpButtonGroup : MonoBehaviour
{
    UI_LevelUpButton _left;
    UI_LevelUpButton _Middle;
    UI_LevelUpButton _right;

    public Sprite[] _levelIcon;

    private void Awake()
    {
        _left=transform.Find("Left").GetComponent<UI_LevelUpButton>();
        _Middle = transform.Find("Middle").GetComponent<UI_LevelUpButton>();
        _right = transform.Find("Right").GetComponent<UI_LevelUpButton>();
    }

    public void Open()
    {
        _left.Option=LevelUpOption.SkillOnePoint;
        _Middle.Option=LevelUpOption.SkillMultiPoint;
        _right.Option = LevelUpOption.SkillTouchBuff;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
