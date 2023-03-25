using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{

    int _playerGold;
    public int PlayerGold { get { return _playerGold; } set { _playerGold = value; ChangeGold?.Invoke(); } }


    public int Power_TouchDamageTier { get; set; }
    public int Power_TouchSpeedTier { get; set; }
    public int Power_MaxStaminaTier { get; set; }
    public int Power_SkillDamageTier { get; set; }
    public int Power_SkillCoolTimeRecoveryTier { get; set; }
    public int Power_PartnerDamageTier { get; set; }
    public int Power_FixedDamageTier { get; set; }
    public int Power_ExpUpTier { get; set; }
    public int Power_GoldUpTier { get; set; }

    public WeaponType EquipWeapon { get; set; }

    public bool SwordOpen { get; set; }
    public bool AxeOpen { get; set; }
    public bool HammerOpen { get; set; }
    public bool StickOpen { get; set; }

    public bool HandOpen { get; set; }

    public static int maxTouchDamageTier = 5;
    public static int maxTouchSpeedTier = 2;
    public static int maxMaxStaminaTier = 5;
    public static int maxSkillDamageTier = 5;
    public static int maxSkillCollTimeRecoveryTier = 2;
    public static int maxPartnerDamageTier = 5;
    public static int maxFixedDamageTier = 3;
    public static int maxExpUpTier = 5;
    public static int maxGoldUpTier = 5;

    public Action ChangeGold { get; set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Initialize()
    {
       LoadData();
    }

    void LoadData()
    {
        string path=$"{Application.dataPath}/Save/";
        string fullPath = $"{path}Save.json";

        if(Directory.Exists(path) && File.Exists(fullPath))
        {
            Debug.Log("데이터 있음");
            string json=File.ReadAllText(fullPath);
            SaveData saveData=JsonUtility.FromJson<SaveData>(json);

            PlayerGold = saveData.PlayerGold;
            Power_TouchDamageTier = saveData.Power_TouchDamageTier;
            Power_TouchSpeedTier = saveData.Power_TouchSpeedTier;
            Power_MaxStaminaTier = saveData.Power_MaxStaminaTier;
            Power_SkillDamageTier = saveData.Power_SkillDamageTier;
            Power_SkillCoolTimeRecoveryTier = saveData.Power_SkillCoolTimeRecoveryTier;
            Power_PartnerDamageTier = saveData.Power_PartnerDamageTier;
            Power_FixedDamageTier = saveData.Power_FixedDamageTier;
            Power_ExpUpTier = saveData.Power_ExpUpTier;
            Power_GoldUpTier = saveData.Power_GoldUpTier;
            EquipWeapon = (WeaponType)saveData.EquipWeapon;
            SwordOpen = saveData.SwordOpen;
            AxeOpen = saveData.AxeOpen;
            HammerOpen = saveData.HammerOpen;
            StickOpen = saveData.StickOpen;
            HandOpen = saveData.HandOpen;


        }else
        {
            Debug.Log("데이터 없음");
            // 없으면 새로 만든다~

            PlayerGold = 500000;
            Power_TouchDamageTier = 0;
            Power_TouchSpeedTier = 0;
            Power_MaxStaminaTier = 0;
            Power_SkillDamageTier = 0;
            Power_SkillCoolTimeRecoveryTier = 0;
            Power_PartnerDamageTier = 0;
            Power_FixedDamageTier = 0;
            Power_ExpUpTier = 0;
            Power_GoldUpTier = 0;
            EquipWeapon = WeaponType.Sword;
            SwordOpen = true;
            AxeOpen = false;
            HammerOpen = false;
            StickOpen = false;
            HandOpen = false;

            SaveData saveData = new();

            saveData.PlayerGold = PlayerGold;
            saveData.Power_TouchDamageTier= Power_TouchDamageTier;
            saveData.Power_TouchSpeedTier= Power_TouchSpeedTier;
            saveData.Power_MaxStaminaTier= Power_MaxStaminaTier;
            saveData.Power_SkillDamageTier= Power_SkillDamageTier;
            saveData.Power_SkillCoolTimeRecoveryTier= Power_SkillCoolTimeRecoveryTier;
            saveData.Power_PartnerDamageTier= Power_PartnerDamageTier;
            saveData.Power_FixedDamageTier= Power_FixedDamageTier;
            saveData.Power_ExpUpTier= Power_ExpUpTier;
            saveData.Power_GoldUpTier= Power_GoldUpTier;
            saveData.EquipWeapon= (int)EquipWeapon;
            saveData.SwordOpen= SwordOpen;
            saveData.AxeOpen= AxeOpen;
            saveData.HammerOpen= HammerOpen;
            saveData.StickOpen= StickOpen;
            saveData.HandOpen= HandOpen;

            string json =JsonUtility.ToJson(saveData);

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(fullPath, json);
            

        }

    }

    public void SaveData()
    {
        string path = $"{Application.dataPath}/Save/";
        string fullPath = $"{path}Save.json";

        SaveData saveData = new();

        saveData.PlayerGold = PlayerGold;
        saveData.Power_TouchDamageTier = Power_TouchDamageTier;
        saveData.Power_TouchSpeedTier = Power_TouchSpeedTier;
        saveData.Power_MaxStaminaTier = Power_MaxStaminaTier;
        saveData.Power_SkillDamageTier = Power_SkillDamageTier;
        saveData.Power_SkillCoolTimeRecoveryTier = Power_SkillCoolTimeRecoveryTier;
        saveData.Power_PartnerDamageTier = Power_PartnerDamageTier;
        saveData.Power_FixedDamageTier = Power_FixedDamageTier;
        saveData.Power_ExpUpTier = Power_ExpUpTier;
        saveData.Power_GoldUpTier = Power_GoldUpTier;
        saveData.EquipWeapon = (int)EquipWeapon;
        saveData.SwordOpen = SwordOpen;
        saveData.AxeOpen = AxeOpen;
        saveData.HammerOpen = HammerOpen;
        saveData.StickOpen = StickOpen;
        saveData.HandOpen = HandOpen;

        string json = JsonUtility.ToJson(saveData);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.WriteAllText(fullPath, json);
    }
}
