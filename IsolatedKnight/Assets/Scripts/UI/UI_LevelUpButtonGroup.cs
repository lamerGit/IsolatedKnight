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
        _left.Option=LevelUpOption.None;
        _Middle.Option = LevelUpOption.None ;
        _right.Option = LevelUpOption.None;
        RandomOption();
        
        gameObject.SetActive(true);
    }

    void RandomOption()
    {
        List<LevelUpOption> options = new List<LevelUpOption>();

        #region Nomal

        if (Managers.GameManager.TouchDamageTier<3)
        {
            options.Add(LevelUpOption.TouchDamage);
        }

        if(Managers.GameManager.TouchSpeedTier<3)
        {
            options.Add(LevelUpOption.TouchSpeed);
        }

        if(Managers.GameManager.StaminaTier<3)
        {
            options.Add(LevelUpOption.Stamina);
        }

        if(Managers.GameManager.TouchBuffTier<3)
        {
            options.Add(LevelUpOption.TouchBuff);
        }

        if(Managers.GameManager.PartnerDragonTier<3)
        {
            options.Add(LevelUpOption.PartnerDragon);
        }

        if(Managers.GameManager.PartnerGolemTier<3)
        {
            options.Add(LevelUpOption.PartnerGolem);
        }

        if(Managers.GameManager.PartnerGostTier<3)
        {
            options.Add(LevelUpOption.PartnerGost);
        }

        if(Managers.GameManager.PartnerBuffTier<3)
        {
            options.Add(LevelUpOption.PartnerBuff);
        }

        if(Managers.GameManager.SkillOnePointTier<3)
        {
            options.Add(LevelUpOption.SkillOnePoint);
        }

        if(Managers.GameManager.SkillMultiPointTier<3)
        {
            options.Add(LevelUpOption.SkillMultiPoint);
        }

        if(Managers.GameManager.SkillTouchBuffTier<3)
        {
            options.Add(LevelUpOption.SkillTouchBuff);
        }

        if(Managers.GameManager.SkillBuffTier<3)
        {
            options.Add(LevelUpOption.SkillBuff);
        }

        if(Managers.GameManager.PassiveExpTier<3)
        {
            options.Add(LevelUpOption.PassiveExp);
        }

        if(Managers.GameManager.PassiveDefenceTier<3)
        {
            options.Add(LevelUpOption.PassiveDefence);
        }

        if(Managers.GameManager.PassiveFireTier<3)
        {
            options.Add(LevelUpOption.PassiveFire);
        }

        if(Managers.GameManager.PassiveThunderTier<3)
        {
            options.Add(LevelUpOption.PassiveThunder);
        }

        if(Managers.GameManager.PassiveAndIceTier<3)
        {
            options.Add(LevelUpOption.PassiveAndIce);
        }

        if(Managers.GameManager.SkillAndGreenBallTier<3)
        {
            options.Add(LevelUpOption.SkillAndGreenBall);
        }

        if(Managers.GameManager.TouchAndAutoTouchTier<3)
        {
            options.Add(LevelUpOption.TouchAndAutoTouch);
        }

        if(Managers.GameManager.PartnerAndMeteorTier<3)
        {
            options.Add(LevelUpOption.PartnerAndMeteor);
        }

        if(Managers.GameManager.PassiveGoldUpTier<3)
        {
            options.Add(LevelUpOption.GoldUp);
        }

        #endregion

        #region Synergy

        if (Managers.GameManager.TouchDamageTier > 1 && Managers.GameManager.TouchSpeedTier > 1 && Managers.GameManager.SynergySpeedGameTier < 1)
        {
            options.Add(LevelUpOption.SpeedGame);
        }

        if(Managers.GameManager.SkillOnePointTier>2 && Managers.GameManager.SkillBuffTier>2 && Managers.GameManager.SynergyPowerSkillAttackTier<1)
        {
            options.Add(LevelUpOption.PowerSkillAttack);
        }

        if(Managers.GameManager.PassiveExpTier>1 && Managers.GameManager.PassiveThunderTier>0 && Managers.GameManager.SynergyThunderArrowTier<1)
        {
            options.Add(LevelUpOption.ThunderArrow);
        }

        if(Managers.GameManager.StaminaTier>0 && Managers.GameManager.PartnerDragonTier>1 && Managers.GameManager.SynergyWaringDragonTier<1)
        {
            options.Add(LevelUpOption.WaringDragon);
        }

        if(Managers.GameManager.PassiveDefenceTier>2 && Managers.GameManager.PassiveFireTier>0 && Managers.GameManager.SynergyDefenceFireTier<1)
        {
            options.Add(LevelUpOption.DefenceFire);
        }

        if(Managers.GameManager.ExpUpTier>1 && Managers.GameManager.PassiveGoldUpTier>2 && Managers.GameManager.SynergyFixedUpTier<1)
        {
            options.Add(LevelUpOption.SynergyFixedUp);
        }

        if(Managers.GameManager.TouchBuffTier>1 && Managers.GameManager.SkillBuffTier>1 && Managers.GameManager.PartnerBuffTier>1 && Managers.GameManager.SynergyTouchSkillPartnerUpTier<1)
        {
            options.Add(LevelUpOption.TouchSkillPartnerUp);
        }

        if(Managers.GameManager.PassiveAndIceTier>2 && Managers.GameManager.SkillAndGreenBallTier>2 && Managers.GameManager.TouchAndAutoTouchTier>2 && Managers.GameManager.SynergyRandomProjectileTier<1)
        {
            options.Add(LevelUpOption.RandomProjectile);
        }


        #endregion

        for (int i=options.Count-1; i>-1; i--)
        {
            int randIndex = Random.Range(0, i + 1);

            (options[randIndex], options[i]) = (options[i], options[randIndex]);

        }

        for(int i=0; i<options.Count; i++)
        {
            if(i==0)
            {
                _left.Option = options[i];
            }

            if(i==1)
            {
                _Middle.Option = options[i];
            }

            if (i==2)
            {
                _right.Option = options[i];
            }
        }

    }



    public void Close()
    {
        if (Managers.GameManager.LevelUpStack > 0)
        {
            RandomOption();
        }
        else
        {
            if (Managers.GameManager.BossRewardStack < 1)
            {
                Managers.GameManager.State = GameState.Nomal;
            }
            
            gameObject.SetActive(false);
        }
    }
}
