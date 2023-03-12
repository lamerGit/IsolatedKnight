using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Stat
    [Serializable]
    public class Stat
    {
        public int type;
        public int maxStamina;
        public float staminaRecoverySpeed;
        public float skillRecoverySpeed;
        public float partnerAttackSpeed;
        public float fixedDamage;
        public float expAmount;
        public float goldAmount;

    }

    [Serializable]
    public class StatLoader : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict=new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
            {
                dict.Add(stat.type, stat);
            }
            return dict;

        }
    }
    #endregion

    #region Weapon
    [Serializable]
    public class Weapon
    {
        public int type;
        public int touchDamage;
        public float touchSpeed;
        public float staminaconsum;
        public int partnerDamage;
        public int skillDamage;

    }

    [Serializable]
    public class WeaponLoader : ILoader<int, Weapon>
    {
        public List<Weapon> weapons = new List<Weapon>();

        public Dictionary<int, Weapon> MakeDict()
        {
            Dictionary<int, Weapon> dict = new Dictionary<int, Weapon>();
            foreach (Weapon weapon in weapons)
            {
                dict.Add(weapon.type, weapon);
            }
            return dict;

        }
    }
    #endregion

    #region Skel
    [Serializable]
    public class Skel
    {
        public int level;
        public int maxHp;
        public float speed;
        public float exp;
    }

    [Serializable]
    public class SkelLoader : ILoader<int, Skel>
    {
        public List<Skel> skels = new List<Skel>();

        public Dictionary<int, Skel> MakeDict()
        {
            Dictionary<int, Skel> dict = new Dictionary<int, Skel>();
            foreach (Skel skel in skels)
            {
                dict.Add(skel.level, skel);
            }
            return dict;

        }
    }
    #endregion

    #region Partner
    [Serializable]
    public class Partner
    {
        public int type;
        public float attackSpeed;
        public int attackDamage;
    }

    [Serializable]
    public class PartnerLoader : ILoader<int, Partner>
    {
        public List<Partner> partners = new List<Partner>();

        public Dictionary<int, Partner> MakeDict()
        {
            Dictionary<int, Partner> dict = new Dictionary<int, Partner>();
            foreach (Partner partner in partners)
            {
                dict.Add(partner.type, partner);
            }
            return dict;

        }
    }
    #endregion
}