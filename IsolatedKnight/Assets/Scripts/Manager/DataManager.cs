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
   public Dictionary<int, Data.Partner> PartnerDict { get;private set; }=new Dictionary<int, Data.Partner>();
   public Dictionary<int, Data.Skill> SkillDict { get;private set; }=new Dictionary<int, Data.Skill>();
   public Dictionary<int, Data.Fixed> FixedDict { get;private set; }=new Dictionary<int, Data.Fixed>();


    public void Init()
    {
        StatDict = LoadJson<Data.StatLoader, int, Data.Stat>("StatData").MakeDict(); 
        WeaponDict = LoadJson<Data.WeaponLoader, int, Data.Weapon>("WeaponData").MakeDict(); 
        SkelDict = LoadJson<Data.SkelLoader, int, Data.Skel>("SkelData").MakeDict(); 
        PartnerDict = LoadJson<Data.PartnerLoader, int, Data.Partner>("PartnerData").MakeDict();
        SkillDict = LoadJson<Data.SkillLoader, int, Data.Skill>("SkillData").MakeDict(); 
        FixedDict = LoadJson<Data.FixedLoader, int, Data.Fixed>("FixedData").MakeDict(); 
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return Newtonsoft.Json.JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }

}
