using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

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

    public bool SwordClear { get; set; }
    public bool AxeClear { get; set; }
    public bool HammerClear { get; set; }
    public bool StickClear { get; set; }
    public bool HandClear { get; set; }

    public static int maxGold = 99999999;

    public static int maxTouchDamageTier = 5;
    public static int maxTouchSpeedTier = 2;
    public static int maxMaxStaminaTier = 5;
    public static int maxSkillDamageTier = 5;
    public static int maxSkillCollTimeRecoveryTier = 2;
    public static int maxPartnerDamageTier = 5;
    public static int maxFixedDamageTier = 2;
    public static int maxExpUpTier = 5;
    public static int maxGoldUpTier = 5;

    public Action ChangeGold { get; set; }

    LanguageType _languageType = LanguageType.us;
    public LanguageType LanguageType
    {
        get { return _languageType; }
        set { _languageType = value;
            ChangeLanguage?.Invoke();
        }

    }

    public Action ChangeLanguage { get; set; }

    public Dictionary<LanguageType, Data.Language> LanguageData { get; private set; } = new Dictionary<LanguageType, Data.Language>();

    [SerializeField]
    AudioMixer _audioMixer;
    float _bgmVolume = 0.5f;
    float _cfsVolume = 0.5f;

    public float BgmVolume
    {
        get { return _bgmVolume; }
        set { _bgmVolume = value; 
        _audioMixer.SetFloat("BGM", Mathf.Log10(_bgmVolume) * 20);
        }
    }

    public float CfxVolume
    {
        get { return _cfsVolume; }
        set { _cfsVolume = value;
            _audioMixer.SetFloat("CFX", Mathf.Log10(_cfsVolume) * 20);

        }
    }

    protected override void Awake()
    {
        base.Awake();
        LanguageInit();
        LanguageSet();
    }

    protected override void Initialize()
    {
       LoadData();
       //Cursor.visible = false;
    }

    void LoadData()
    {
        string path=$"{Application.persistentDataPath}/Save/";
        string fullPath = $"{path}Save.json";

        if(Directory.Exists(path) && File.Exists(fullPath))
        {
            //Debug.Log("데이터 있음");
            string json=File.ReadAllText(fullPath);
            SaveData saveData=JsonUtility.FromJson<SaveData>(json);

            PlayerGold = Mathf.Clamp( saveData.PlayerGold,0,maxGold);
            Power_TouchDamageTier = Mathf.Clamp(saveData.Power_TouchDamageTier,0,maxTouchDamageTier);
            Power_TouchSpeedTier = Mathf.Clamp(saveData.Power_TouchSpeedTier,0,maxTouchSpeedTier);
            Power_MaxStaminaTier = Mathf.Clamp(saveData.Power_MaxStaminaTier,0,maxMaxStaminaTier);
            Power_SkillDamageTier = Mathf.Clamp(saveData.Power_SkillDamageTier,0,maxSkillDamageTier);
            Power_SkillCoolTimeRecoveryTier = Mathf.Clamp(saveData.Power_SkillCoolTimeRecoveryTier,0,maxSkillCollTimeRecoveryTier);
            Power_PartnerDamageTier = Mathf.Clamp(saveData.Power_PartnerDamageTier,0,maxPartnerDamageTier);
            Power_FixedDamageTier = Mathf.Clamp(saveData.Power_FixedDamageTier,0,maxFixedDamageTier);
            Power_ExpUpTier = Mathf.Clamp(saveData.Power_ExpUpTier,0,maxExpUpTier);
            Power_GoldUpTier = Mathf.Clamp(saveData.Power_GoldUpTier,0,maxGoldUpTier);
            EquipWeapon = (WeaponType)saveData.EquipWeapon;
            SwordOpen = saveData.SwordOpen;
            AxeOpen = saveData.AxeOpen;
            HammerOpen = saveData.HammerOpen;
            StickOpen = saveData.StickOpen;
            HandOpen = saveData.HandOpen;

            BgmVolume = saveData.BgmValue;
            CfxVolume = saveData.CfxValue;

            LanguageType = (LanguageType)saveData.Language;

            SwordClear = saveData.SwordClear;
            AxeClear = saveData.AxeClear;
            HammerClear = saveData.HammerClear;
            StickClear = saveData.StickClear;
            HandClear = saveData.HandClear;


        }else
        {
            //Debug.Log("데이터 없음");
            // 없으면 새로 만든다~

            PlayerGold = 0;
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

            BgmVolume = 0.5f;
            CfxVolume = 0.5f;

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

            saveData.BgmValue = BgmVolume;
            saveData.CfxValue = CfxVolume;

            saveData.Language = (int)LanguageType;

            saveData.SwordClear= SwordClear;
            saveData.AxeClear= AxeClear;
            saveData.HammerClear= HammerClear;
            saveData.StickClear= StickClear;
            saveData.HandClear= HandClear;

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
        string path = $"{Application.persistentDataPath}/Save/";
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

        saveData.BgmValue = BgmVolume;
        saveData.CfxValue = CfxVolume;

        saveData.Language = (int)LanguageType;

        saveData.SwordClear = SwordClear;
        saveData.AxeClear = AxeClear;
        saveData.HammerClear = HammerClear;
        saveData.StickClear = StickClear;
        saveData.HandClear = HandClear;

        string json = JsonUtility.ToJson(saveData);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.WriteAllText(fullPath, json);
    }

    public Dictionary<int, Data.Language> LanguageDict { get; private set; } = new Dictionary<int, Data.Language>();


    void LanguageInit()
    {
        LanguageDict = LoadJson<Data.LanguageLoader, int, Data.Language>("LanguageData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return Newtonsoft.Json.JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }


    void LanguageSet()
    {
        Data.Language us = null;
        LanguageDict.TryGetValue((int)LanguageType.us,out us);

        Data.Language kr = null;
        LanguageDict.TryGetValue((int)LanguageType.kr, out kr);

        LanguageData[LanguageType.us] = us;
        LanguageData[LanguageType.kr] = kr;

    }
}
