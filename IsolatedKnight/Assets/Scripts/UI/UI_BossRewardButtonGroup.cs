using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BossRewardButtonGroup : MonoBehaviour
{
    UI_BossRewardButton _left;
    UI_BossRewardButton _Middle;
    UI_BossRewardButton _right;

    public Sprite[] _rewardIcon;

    private void Awake()
    {
        _left = transform.Find("Left").GetComponent<UI_BossRewardButton>();
        _Middle = transform.Find("Middle").GetComponent<UI_BossRewardButton>();
        _right = transform.Find("Right").GetComponent<UI_BossRewardButton>();
    }

    public void Open()
    {
        _left.Option = BossRewardOption.StickNoTouch;
        _Middle.Option = BossRewardOption.StickRandomSkill;
        _right.Option = BossRewardOption.StickSkillPlus;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        if (Managers.GameManager.BossRewardStack > 0)
        {
            RandomOption();
         
        }
        else
        {
            if (Managers.GameManager.LevelUpStack < 1)
            {
                Managers.GameManager.State = GameState.Nomal;
            }

            gameObject.SetActive(false);
        }

        
    }

    private void RandomOption()
    {
        gameObject.SetActive(false);
    }
}
