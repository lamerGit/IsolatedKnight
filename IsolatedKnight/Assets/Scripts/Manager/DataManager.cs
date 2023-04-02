using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager 
{
   public Dictionary<int, Data.Stat> StatDict { get;private set; }=new Dictionary<int, Data.Stat>();
   public Dictionary<int, Data.Weapon> WeaponDict { get;private set; }=new Dictionary<int, Data.Weapon>();
   public Dictionary<int, Data.Skel> SkelDict { get;private set; }=new Dictionary<int, Data.Skel>();
   public Dictionary<int, Data.SkelDefence> SkelDefenceDict { get;private set; }=new Dictionary<int, Data.SkelDefence>();
   public Dictionary<int, Data.SkelSpeed> SkelSpeedDict { get;private set; }=new Dictionary<int, Data.SkelSpeed>();
   public Dictionary<int, Data.SkelKnight> SkelKnightDict { get;private set; }=new Dictionary<int, Data.SkelKnight>();

   public Dictionary<int, Data.Partner> PartnerDict { get;private set; }=new Dictionary<int, Data.Partner>();
   public Dictionary<int, Data.Skill> SkillDict { get;private set; }=new Dictionary<int, Data.Skill>();
   public Dictionary<int, Data.Fixed> FixedDict { get;private set; }=new Dictionary<int, Data.Fixed>();
   public Dictionary<int, Data.ExtraAttack> ExtraAttackDict { get;private set; }=new Dictionary<int, Data.ExtraAttack>();
   public Dictionary<int, Data.Boss> BossDict { get;private set; }=new Dictionary<int, Data.Boss>();
   public Dictionary<int, Data.PowerUp> PowerUpDict { get;private set; }=new Dictionary<int, Data.PowerUp>();


    public void Init()
    {
        StatDict = LoadJson<Data.StatLoader, int, Data.Stat>("StatData").MakeDict(); 
        WeaponDict = LoadJson<Data.WeaponLoader, int, Data.Weapon>("WeaponData").MakeDict(); 
        SkelDict = LoadJson<Data.SkelLoader, int, Data.Skel>("SkelData").MakeDict();
        SkelDefenceDict = LoadJson<Data.SkelDefenceLoader, int, Data.SkelDefence>("SkelDefenceData").MakeDict();
        SkelSpeedDict = LoadJson<Data.SkelSpeedLoader, int, Data.SkelSpeed>("SkelSpeedData").MakeDict();
        SkelKnightDict = LoadJson<Data.SkelKnightLoader, int, Data.SkelKnight>("SkelKnightData").MakeDict(); 
        PartnerDict = LoadJson<Data.PartnerLoader, int, Data.Partner>("PartnerData").MakeDict();
        SkillDict = LoadJson<Data.SkillLoader, int, Data.Skill>("SkillData").MakeDict(); 
        FixedDict = LoadJson<Data.FixedLoader, int, Data.Fixed>("FixedData").MakeDict();
        ExtraAttackDict = LoadJson<Data.ExtraAttackLoader, int, Data.ExtraAttack>("ExtraAttackData").MakeDict();
        BossDict = LoadJson<Data.BossLoader, int, Data.Boss>("BossData").MakeDict();
        PowerUpDict = LoadJson<Data.PowerUpLoader, int, Data.PowerUp>("PowerUpData").MakeDict(); 
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

}
