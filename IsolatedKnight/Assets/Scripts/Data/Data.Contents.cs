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
        public int fixedDamage;
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

    #region SkelDefence
    [Serializable]
    public class SkelDefence
    {
        public int level;
        public int maxHp;
        public float speed;
        public float exp;
    }

    [Serializable]
    public class SkelDefenceLoader : ILoader<int, SkelDefence>
    {
        public List<SkelDefence> skelDefences = new List<SkelDefence>();

        public Dictionary<int, SkelDefence> MakeDict()
        {
            Dictionary<int, SkelDefence> dict = new Dictionary<int, SkelDefence>();
            foreach (SkelDefence skelDefence in skelDefences)
            {
                dict.Add(skelDefence.level, skelDefence);
            }
            return dict;

        }
    }
    #endregion

    #region SkelSpeed
    [Serializable]
    public class SkelSpeed
    {
        public int level;
        public int maxHp;
        public float speed;
        public float exp;
    }

    [Serializable]
    public class SkelSpeedLoader : ILoader<int, SkelSpeed>
    {
        public List<SkelSpeed> skelSpeeds = new List<SkelSpeed>();

        public Dictionary<int, SkelSpeed> MakeDict()
        {
            Dictionary<int, SkelSpeed> dict = new Dictionary<int, SkelSpeed>();
            foreach (SkelSpeed skelSpeed in skelSpeeds)
            {
                dict.Add(skelSpeed.level, skelSpeed);
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

    #region Skill
    [Serializable]
    public class Skill
    {
        public int type;
        public float skillColTime;
        public int skillDamage;
    }

    [Serializable]
    public class SkillLoader : ILoader<int, Skill>
    {
        public List<Skill> skills = new List<Skill>();

        public Dictionary<int, Skill> MakeDict()
        {
            Dictionary<int, Skill> dict = new Dictionary<int, Skill>();
            foreach (Skill skill in skills)
            {
                dict.Add(skill.type, skill);
            }
            return dict;

        }
    }
    #endregion

    #region Fixed
    [Serializable]
    public class Fixed
    {
        public int type;
        public int arrow;
        public int defence;
        public int fire;
        public int thunder;
    }

    [Serializable]
    public class FixedLoader : ILoader<int, Fixed>
    {
        public List<Fixed> fixeds = new List<Fixed>();

        public Dictionary<int, Fixed> MakeDict()
        {
            Dictionary<int, Fixed> dict = new Dictionary<int, Fixed>();
            foreach (Fixed f in fixeds)
            {
                dict.Add(f.type, f);
            }
            return dict;

        }
    }
    #endregion

    #region Boss
    [Serializable]
    public class Boss
    {
        public int type;
        public int maxHp;
        public float speed;
        public float skillCoolTime;
        public float skillRecovery;
        public float exp;
    }

    [Serializable]
    public class BossLoader : ILoader<int, Boss>
    {
        public List<Boss> bosss = new List<Boss>();

        public Dictionary<int, Boss> MakeDict()
        {
            Dictionary<int, Boss> dict = new Dictionary<int, Boss>();
            foreach (Boss boss in bosss)
            {
                dict.Add(boss.type, boss);
            }
            return dict;

        }
    }
    #endregion
}