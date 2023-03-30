using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_LevelUpButton : MonoBehaviour
{
    LevelUpOption _option;
    Button _button;

    UI_LevelUpButtonGroup _group;

    TextMeshProUGUI _tierText;
    public LevelUpOption Option
    {
        get { return _option; }
        set
        {
            _option = value;
            switch (_option)
            {
                case LevelUpOption.None:
                    _button.image.sprite = _group._levelIcon[0];
                    TierCheck(0);
                    break;
                case LevelUpOption.TouchDamage:
                    _button.image.sprite = _group._levelIcon[1];
                    TierCheck(Managers.GameManager.TouchDamageTier);
                    break;
                case LevelUpOption.TouchSpeed:
                    _button.image.sprite = _group._levelIcon[2];
                    TierCheck(Managers.GameManager.TouchSpeedTier);
                    break;
                case LevelUpOption.Stamina:
                    _button.image.sprite = _group._levelIcon[3];
                    TierCheck(Managers.GameManager.StaminaTier);
                    break;
                case LevelUpOption.TouchBuff:
                    _button.image.sprite = _group._levelIcon[4];
                    TierCheck(Managers.GameManager.TouchBuffTier);
                    break;
                case LevelUpOption.PartnerDragon:
                    _button.image.sprite = _group._levelIcon[5];
                    TierCheck(Managers.GameManager.PartnerDragonTier);
                    break;
                case LevelUpOption.PartnerGolem:
                    _button.image.sprite = _group._levelIcon[6];
                    TierCheck(Managers.GameManager.PartnerGolemTier);
                    break;
                case LevelUpOption.PartnerGost:
                    _button.image.sprite = _group._levelIcon[7];
                    TierCheck(Managers.GameManager.PartnerGostTier);
                    break;
                case LevelUpOption.PartnerBuff:
                    _button.image.sprite = _group._levelIcon[8];
                    TierCheck(Managers.GameManager.PartnerBuffTier);
                    break;
                case LevelUpOption.SkillOnePoint:
                    _button.image.sprite = _group._levelIcon[9];
                    TierCheck(Managers.GameManager.SkillOnePointTier);
                    break;
                case LevelUpOption.SkillMultiPoint:
                    _button.image.sprite = _group._levelIcon[10];
                    TierCheck(Managers.GameManager.SkillMultiPointTier);
                    break;
                case LevelUpOption.SkillTouchBuff:
                    _button.image.sprite = _group._levelIcon[11];
                    TierCheck(Managers.GameManager.SkillTouchBuffTier);
                    break;
                case LevelUpOption.SkillBuff:
                    _button.image.sprite = _group._levelIcon[12];
                    TierCheck(Managers.GameManager.SkillBuffTier);
                    break;
                case LevelUpOption.PassiveExp:
                    _button.image.sprite = _group._levelIcon[13];
                    TierCheck(Managers.GameManager.PassiveExpTier);
                    break;
                case LevelUpOption.PassiveDefence:
                    _button.image.sprite = _group._levelIcon[14];
                    TierCheck(Managers.GameManager.PassiveDefenceTier);
                    break;
                case LevelUpOption.PassiveFire:
                    _button.image.sprite = _group._levelIcon[15];
                    TierCheck(Managers.GameManager.PassiveFireTier);
                    break;
                case LevelUpOption.PassiveThunder:
                    _button.image.sprite = _group._levelIcon[16];
                    TierCheck(Managers.GameManager.PassiveThunderTier);
                    break;
                case LevelUpOption.SpeedGame:
                    _button.image.sprite = _group._levelIcon[17];
                    TierCheck(Managers.GameManager.SynergySpeedGameTier);
                    break;
                case LevelUpOption.PowerSkillAttack:
                    _button.image.sprite = _group._levelIcon[18];
                    TierCheck(Managers.GameManager.SynergyPowerSkillAttackTier);
                    break;
                case LevelUpOption.ThunderArrow:
                    _button.image.sprite = _group._levelIcon[19];
                    TierCheck(Managers.GameManager.SynergyThunderArrowTier);
                    break;
                case LevelUpOption.WaringDragon:
                    _button.image.sprite = _group._levelIcon[20];
                    TierCheck(Managers.GameManager.SynergyWaringDragonTier);
                    break;
                case LevelUpOption.DefenceFire:
                    _button.image.sprite = _group._levelIcon[21];
                    TierCheck(Managers.GameManager.SynergyDefenceFireTier);
                    break;
                case LevelUpOption.PassiveAndIce:
                    _button.image.sprite = _group._levelIcon[22];
                    TierCheck(Managers.GameManager.PassiveAndIceTier);
                    break;
                case LevelUpOption.SkillAndGreenBall:
                    _button.image.sprite = _group._levelIcon[23];
                    TierCheck(Managers.GameManager.SkillAndGreenBallTier);
                    break;
                case LevelUpOption.TouchAndAutoTouch:
                    _button.image.sprite = _group._levelIcon[24];
                    TierCheck(Managers.GameManager.TouchAndAutoTouchTier);
                    break;
                case LevelUpOption.PartnerAndMeteor:
                    _button.image.sprite = _group._levelIcon[25];
                    TierCheck(Managers.GameManager.PartnerAndMeteorTier);
                    break;
                case LevelUpOption.GoldUp:
                    _button.image.sprite = _group._levelIcon[26];
                    TierCheck(Managers.GameManager.PassiveGoldUpTier);
                    break;
                case LevelUpOption.SynergyFixedUp:
                    _button.image.sprite = _group._levelIcon[27];
                    TierCheck(Managers.GameManager.SynergyFixedUpTier);
                    break;
                case LevelUpOption.TouchSkillPartnerUp:
                    _button.image.sprite = _group._levelIcon[28];
                    TierCheck(Managers.GameManager.SynergyTouchSkillPartnerUpTier);
                    break;
                case LevelUpOption.RandomProjectile:
                    _button.image.sprite = _group._levelIcon[29];
                    TierCheck(Managers.GameManager.SynergyRandomProjectileTier);
                    break;
            }


        }
    }

    private void Awake()
    {  
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButton);

        _group=GetComponentInParent<UI_LevelUpButtonGroup>();
        _tierText=GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnButton()
    {
        UI_ClickSound.Instance.ClickPlay();
        switch (Option)
        {
            case LevelUpOption.None:
                Managers.Object.MyPlayer.GoldUp(50);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].getgold);
                break;
            case LevelUpOption.TouchDamage:
                TouchDamageTierSelected();
                break;
            case LevelUpOption.TouchSpeed:
                TouchSpeedTierSelected();
                break;
            case LevelUpOption.Stamina:
                StaminaTierSelected();
                break;
            case LevelUpOption.TouchBuff:
                TouchBuffTierSelected();
                break;
            case LevelUpOption.PartnerDragon:
                PartnerDragonTierSelected();
                break;
            case LevelUpOption.PartnerGolem:
                PartnerGolemTierSelected();
                break;
            case LevelUpOption.PartnerGost:
                PartnerGostTierSelected();
                break;
            case LevelUpOption.PartnerBuff:
                PartnerBuffTierSelected();
                break;
            case LevelUpOption.SkillOnePoint:
                SkillOnePointTierSelected();
                break;
            case LevelUpOption.SkillMultiPoint:
                SkillMultitTierSelected();
                break;
            case LevelUpOption.SkillTouchBuff:
                SkillTouchBuffTierSelected();
                break;
            case LevelUpOption.SkillBuff:
                SkillBuffTierSelected();
                break;
            case LevelUpOption.PassiveExp:
                PassiveExpTierSelected();
                break;
            case LevelUpOption.PassiveDefence:
                PassiveDefenceTierSelected();
                break;
            case LevelUpOption.PassiveFire:
                PassiveFireTierSelected();
                break;
            case LevelUpOption.PassiveThunder:
                PassiveThunderTierSelected();
                break;
            case LevelUpOption.SpeedGame:
                SynergySpeedGameTierSelected();
                break;
            case LevelUpOption.PowerSkillAttack:
                SynergyPowerSkillAttackTierSelected();
                break;
            case LevelUpOption.ThunderArrow:
                SynergyThunderArrowTierSelected();
                break;
            case LevelUpOption.WaringDragon:
                SynergyWaringDragonTierSelected();
                break;
            case LevelUpOption.DefenceFire:
                SynergyDefenceFireTierSelected();
                break;
            case LevelUpOption.PassiveAndIce:
                PassiveAndIceTierSelected();
                break;
            case LevelUpOption.SkillAndGreenBall:
                SkillAndGreenBallTierSelected();
                break;
            case LevelUpOption.TouchAndAutoTouch:
                TouchAndAutoTouchTierSelected();
                break;
            case LevelUpOption.PartnerAndMeteor:
                PartnerAndMeteorTierSelected();
                break;
            case LevelUpOption.GoldUp:
                GoldUpTierSelected();
                break;
            case LevelUpOption.SynergyFixedUp:
                SynergyFixedUpTierSelected();
                break;
            case LevelUpOption.TouchSkillPartnerUp:
                TouchSkillPartnerUpTierSelected();
                break;
            case LevelUpOption.RandomProjectile:
                RandomProjectileTierSelected();
                break;
        }

        Managers.GameManager.LevelUpStack--;
        
        _group.Close();
    }





    #region ExtraAttack

    private void PartnerAndMeteorTierSelected()
    {
        switch (Managers.GameManager.PartnerAndMeteorTier)
        {
            case 0:
                Managers.GameManager.PartnerAndMeteorTier1MeteorOn = true;
                Managers.Object.PartnerMeteor.Spawn();
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Meteorafterattacking30summons);
                break;
            case 1:
                Managers.GameManager.PartnerAndMeteorTier2MeteorSlow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].SlowonMeteorHit);
                break;
            case 2:
                Managers.GameManager.PartnerAndMeteorTier3MeteorFire = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].BurnonMeterorHit);
                break;

        }
        Managers.GameManager.PartnerAndMeteorTier++;
    }

    private void TouchAndAutoTouchTierSelected()
    {
        switch (Managers.GameManager.TouchAndAutoTouchTier)
        {
            case 0:
                Managers.GameManager.TouchAndAutoTouchTier1TouchCountOn = true;
                Managers.Object.MyPlayer.TouchCount += 25;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].WhirlWindafterattacking25touch);
                break;
            case 1:
                Managers.GameManager.TouchAndAutoTouchTier2TouchCountUp = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].WhirlWindCountUp);
                break;
            case 2:
                Managers.GameManager.TouchAndAutoTouchTier3TouchCountUp = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].WhirlWindCountUp);
                break;

        }
        Managers.GameManager.TouchAndAutoTouchTier++;
    }

    private void SkillAndGreenBallTierSelected()
    {
        switch (Managers.GameManager.SkillAndGreenBallTier)
        {
            case 0:
                Managers.GameManager.SkillAndGreenBallTier1GreenBallOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].DeathBallafterusing10skill);
                Managers.Object.MyPlayer.GreenBallAttack();
                break;
            case 1:
                Managers.GameManager.SkillAndGreenBallTier2GreenBallSpeedUp = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].DeathBallspeedup);
                break;
            case 2:
                Managers.GameManager.SkillAndGreenBallTier3DurationUp = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].DeathBalldurationup);
                break;

        }
        Managers.GameManager.SkillAndGreenBallTier++;
    }

    private void PassiveAndIceTierSelected()
    {
        switch (Managers.GameManager.PassiveAndIceTier)
        {
            case 0:
                Managers.GameManager.PassiveAndIceTier1IceOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].IceArrowafter50fixeddamage);
                Managers.Object.MyPlayer.IceAttack();
                break;
            case 1:
                Managers.GameManager.PassiveAndIceTier2MoreIce = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].icearrowcountup);
                break;
            case 2:
                Managers.Object.MyPlayer.MaxIceCount = 30;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].IceArrowafter30fixeddamage);
                break;

        }
        Managers.GameManager.PassiveAndIceTier++;
    }

    #endregion

    #region Synergy


    private void RandomProjectileTierSelected()
    {
        switch (Managers.GameManager.SynergyRandomProjectileTier)
        {
            case 0:
                Managers.GameManager.SynergyRandomProjectileTier1RandomOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Randomprojectileafterattacking10touch);
                break;

        }
        Managers.GameManager.SynergyRandomProjectileTier++;
    }

    private void TouchSkillPartnerUpTierSelected()
    {
        switch (Managers.GameManager.SynergyTouchSkillPartnerUpTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);
                break;

        }
        Managers.GameManager.SynergyTouchSkillPartnerUpTier++;
    }

    private void SynergyFixedUpTierSelected()
    {
        switch (Managers.GameManager.SynergyFixedUpTier)
        {
            case 0:
                Managers.GameManager.ExtraFixedDamage += 2;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Fixeddamageup);
                break;

        }
        Managers.GameManager.SynergyFixedUpTier++;
    }

    private void SynergySpeedGameTierSelected()
    {
        switch (Managers.GameManager.SynergySpeedGameTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchspeedup);
                Managers.GameManager.ExtraEnemySpeed += 0.5f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Enemyspeedup);
                break;

        }
        Managers.GameManager.SynergySpeedGameTier++;
    }

    private void SynergyPowerSkillAttackTierSelected()
    {
        switch (Managers.GameManager.SynergyPowerSkillAttackTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 2.0f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                Managers.GameManager.ExtraSkillRecovery -= Managers.Object.MyPlayer.SkillRecoverySpeed * 0.5f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skillrecoveryspeeddown);
                break;

        }
        Managers.GameManager.SynergyPowerSkillAttackTier++;
    }

    private void SynergyThunderArrowTierSelected()
    {
        switch (Managers.GameManager.SynergyThunderArrowTier)
        {
            case 0:
                Managers.GameManager.SynergyThunderArrowTier1billia = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Arrowsbounce);
                break;

        }
        Managers.GameManager.SynergyThunderArrowTier++;
    }

    private void SynergyWaringDragonTierSelected()
    {
        switch (Managers.GameManager.SynergyWaringDragonTier)
        {
            case 0:
                Managers.GameManager.SynergyWaringDragonTier1WaningOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Dragonattackspeedupafteroverload);
                break;

        }
        Managers.GameManager.SynergyWaringDragonTier++;
    }

    private void SynergyDefenceFireTierSelected()
    {
        switch (Managers.GameManager.SynergyDefenceFireTier)
        {
            case 0:
                Managers.GameManager.SynergyDefenceFireTier1FireTrans = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Burntransferafterburnenemydie);
                break;
            
        }
        Managers.GameManager.SynergyDefenceFireTier++;
    }

    #endregion

    #region PassiveSelected

    private void GoldUpTierSelected()
    {
        switch (Managers.GameManager.PassiveGoldUpTier)
        {
            case 0:
                Managers.GameManager.ExtraGoldPersent += 0.5f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].GoldUp);
                break;
            case 1:
                Managers.GameManager.ExtraGoldPersent += 0.5f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].GoldUp);
                break;
            case 2:
                Managers.GameManager.ExtraGoldPersent += 1.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].GoldUp);
                break;

        }
        Managers.GameManager.PassiveGoldUpTier++;
    }


    private void PassiveThunderTierSelected()
    {
        switch (Managers.GameManager.PassiveThunderTier)
        {
            case 0:
                Managers.GameManager.PassiveThunderTier1ThunderOn = true;
                Managers.GameManager.PassiveThunderCount = 1;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Fixeddamagelightning);
                break;
            case 1:
                Managers.GameManager.PassiveThunderCount = 5;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].lightningCountUp);
                break;
            case 2:
                Managers.GameManager.PassiveThunderTier3CoolTimeRecovery = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].skillrecoveryafterlightninghit);
                Managers.GameManager.PassiveThunderCount = 15;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].lightningCountUp);
                break;

        }
        Managers.GameManager.PassiveThunderTier++;
    }

    private void PassiveFireTierSelected()
    {
        switch (Managers.GameManager.PassiveFireTier)
        {
            case 0:
                Managers.GameManager.PassiveFireTire1FireOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Chancetoburnwhenattacking);
                break;
            case 1:
                Managers.GameManager.PassiveFireTire2DoubleFire = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Burnsstackby2stacks);
                break;
            case 2:
                Managers.GameManager.PassiveFireTire3FireOn = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].BurnRateUp);
                break;

        }
        Managers.GameManager.PassiveFireTier++;
    }

    private void PassiveDefenceTierSelected()
    {
        switch (Managers.GameManager.PassiveDefenceTier)
        {
            case 0:
                Managers.Object.PassiveDefence.Spawn();
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Fixeddamageshield);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Slowwhenshieldattack);
                break;
            case 1:
                Managers.GameManager.ExtraPassiveDefenceDamage += 5;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ShielddamageUp);
                break;
            case 2:
                Managers.Object.PassiveDefence.AttackSpeed = 1.0f;
                Managers.Object.PassiveDefence.CurrentAttackTimer = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ShieldattackSpeedUp);
                break;

        }
        Managers.GameManager.PassiveDefenceTier++;
    }

    private void PassiveExpTierSelected()
    {
        switch (Managers.GameManager.PassiveExpTier)
        {
            case 0:
                Managers.GameManager.ExtraExpPersent += 0.5f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                break;
            case 1:
                Managers.GameManager.ExtraExpPersent += 0.6f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                Managers.GameManager.PassiveExpTier2Arrow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Arrowattackwhenexpget);
                break;
            case 2:
                Managers.GameManager.ExtraExpPersent += 0.7f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                Managers.GameManager.PassiveExpTier3Arrow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Arrowcountby3);
                break;

        }
        Managers.GameManager.PassiveExpTier++;
    }

    #endregion


    #region SkillSelected
    private void SkillOnePointTierSelected()
    {
        switch (Managers.GameManager.SkillOnePointTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.OnePoint);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].LightningBallskillget);
                break;
            case 1:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 1.0f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                break;
            case 2:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 1.0f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                Managers.GameManager.OnePointSkillTier3HpAttack = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Enemymaximumhp10persentdamage);
                break;

        }
        Managers.GameManager.SkillOnePointTier++;
    }

    private void SkillMultitTierSelected()
    {
        switch (Managers.GameManager.SkillMultiPointTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.MultiPoint);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Holyshockskillget);
                break;
            case 1:
                Managers.GameManager.SkillMutiPointTier2Slow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Slowwhenholyshockattack);
                break;
            case 2:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                Managers.GameManager.SkillMutiPointTier3Slow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].HolyshockslowUp);
                break;

        }
        Managers.GameManager.SkillMultiPointTier++;
    }

    private void SkillTouchBuffTierSelected()
    {
        switch (Managers.GameManager.SkillTouchBuffTier)
        {
            case 0:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.TouchBuff);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchabilityupskillget);
                break;
            case 1:
                Managers.GameManager.SkillTouchBuffTier2SpeedUp = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchspeedupwhenusingskill);
                break;
            case 2:
                Managers.GameManager.SkillTouchBuffTier3StaminaRecovery = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].StaminaRecoveryupwhenusingskill);
                break;

        }
        Managers.GameManager.SkillTouchBuffTier++;
    }

    private void SkillBuffTierSelected()
    {
        switch (Managers.GameManager.SkillBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraSkillDamage += (int)(Managers.Object.MyPlayer.SkillDamage * 0.2f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skilldamageup);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                break;
            case 1:
                Managers.GameManager.ExtraSkillRecovery += Managers.Object.MyPlayer.SkillRecoverySpeed * 1.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Skillrecoveryspeedup);

                break;
            case 2:
                Managers.UIManager.SkillSlotGroup.AddSkill(SkillType.Buff);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].skillresetskillget);
                break;

        }
        Managers.GameManager.SkillBuffTier++;
    }
    #endregion

    #region PartnerSelected
    private void PartnerGolemTierSelected()
    {
        switch (Managers.GameManager.PartnerGolemTier)
        {
            case 0:
                Managers.Object.PartnerGolem.Spawn();
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summongolem);
                break;
            case 1:
                Managers.GameManager.PartnerGolemTier2Billia = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Golemattackbounce);
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);
                break;
            case 2:
                Managers.GameManager.PartnerGolemTier3Explosion = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Golemattackexplosion);
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);
                break;

        }
        Managers.GameManager.PartnerGolemTier++;
    }

    private void PartnerGostTierSelected()
    {
        switch (Managers.GameManager.PartnerGostTier)
        {
            case 0:
                Managers.Object.PartnerGost.Spawn();
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summonghost);
                break;
            case 1:
                Managers.GameManager.PartnerGostTier2Damage= true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Ghostdodamage);
                break;
            case 2:
                Managers.GameManager.PartnerGostTier3Slow = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].GhostSlowUp);
                break;

        }
        Managers.GameManager.PartnerGostTier++;
    }

    private void PartnerBuffTierSelected()
    {
        switch (Managers.GameManager.PartnerBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.2f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                break;
            case 1:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.3f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.ExtraPartnerDamage += (int)(Managers.Object.MyPlayer.PartnerDamage * 0.3f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summondamageup);
                break;
            case 2:
                Managers.GameManager.PartnerBuffTier3ExtraAttack = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summonsdealextradamage);
                break;

        }
        Managers.GameManager.PartnerBuffTier++;
    }

    private void PartnerDragonTierSelected()
    {
        switch (Managers.GameManager.PartnerDragonTier)
        {
            case 0:
                Managers.Object.PartnerDragon.Spawn();
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].SummonDragon);
                break;
            case 1:
                Managers.GameManager.ExtraPartnerAttackSpeedTick += 0.3f;
                Managers.Object.PartnerDragon.CurrentAttackTimer = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].SummonattackSpeedup);
                Managers.GameManager.PartnerDragonTier2SpearShot = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Dragonattackpiercing);
                break;
            case 2:
                Managers.GameManager.ExtraPartnerAttackSpeedTick += 0.5f;
                Managers.Object.PartnerDragon.CurrentAttackTimer = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].SummonattackSpeedup);
                Managers.GameManager.PartnerDragonTier3MultiShot = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Dragonattackmultishot);
                break;

        }
        Managers.GameManager.PartnerDragonTier++;
    }
    #endregion

    #region TouchSelected
    void TouchDamageTierSelected()
    {
        switch (Managers.GameManager.TouchDamageTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                break;
            case 1:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.7f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.TouchDamageTier2SpeedDown = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Slowwhentouch);
                break;
            case 2:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 1.0f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.TouchDamageTier3MultiHit = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Multiattackwhentouch);
                break;

        }

       

        Managers.GameManager.TouchDamageTier++;
    }

    void TouchSpeedTierSelected()
    {
        switch (Managers.GameManager.TouchSpeedTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.1f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchspeedup);

                break;
            case 1:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchspeedup);
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Staminaconsumdown);
                
                break;
            case 2:
                Managers.GameManager.ExtraTouchSpeed += Managers.Object.MyPlayer.TouchSpeed * 0.2f;
                Managers.Object.MyPlayer.CurrenTouchSpeed = 0.0f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchspeedup);
                Managers.GameManager.TouchSpeedTier3RandomConsum= true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Chancetonotstaminaconsum);
                break;

        }

        Managers.GameManager.TouchSpeedTier++;
    }

    void TouchBuffTierSelected()
    {
        switch (Managers.GameManager.TouchBuffTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.2f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                Managers.GameManager.ExtraExpPersent += 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].ExpUp);
                break;
            case 1:
                Managers.GameManager.TouchBuffTier2AutoAttack = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Autotouchget);
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.2f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                break;
            case 2:
                Managers.GameManager.TouchBuffTier3AutoAttackBuff = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Autotouchupgrade);
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.2f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Touchdamageup);
                break;

        }

        Managers.GameManager.TouchBuffTier++;


    }
    #endregion

    void StaminaTierSelected()
    {
        switch (Managers.GameManager.StaminaTier)
        {
            case 0:
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Staminaconsumdown);
                break;
            case 1:
                Managers.GameManager.ExtraStaminaconsum += Managers.Object.MyPlayer.StaminaConsum * 0.2f;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Staminaconsumdown);
                Managers.GameManager.ExtraMaxStamina += (int)(Managers.Object.MyPlayer.MaxStamina * 0.5f);
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Maxstaminaup);
                //Debug.Log(Managers.Object.MyPlayer.MaxStamina + Managers.GameManager.ExtraMaxStamina);
                break;
            case 2:
                Managers.GameManager.StaminaTier3Overload = true;
                SpawnText(GameDataManager.Instance.LanguageData[GameDataManager.Instance.LanguageType].Summonandskilldamageupwhenoveload);
                break;

        }
        Managers.GameManager.StaminaTier++;
    }



    void TierCheck(int tier)
    {
        _tierText.text = $"T {tier + 1}";
    }

    void SpawnText(string text)
    {
        Poolable p = Managers.Pool.Pop(Managers.Object.DamageText);
        p.ExTextSpawn(text, Managers.Object.MyPlayer.transform);
    }

}
