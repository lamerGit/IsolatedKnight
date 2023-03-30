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


    #region SkelKnight
    [Serializable]
    public class SkelKnight
    {
        public int level;
        public int maxHp;
        public float speed;
        public float exp;
    }

    [Serializable]
    public class SkelKnightLoader : ILoader<int, SkelKnight>
    {
        public List<SkelKnight> skelKnights = new List<SkelKnight>();

        public Dictionary<int, SkelKnight> MakeDict()
        {
            Dictionary<int, SkelKnight> dict = new Dictionary<int, SkelKnight>();
            foreach (SkelKnight skelKnight in skelKnights)
            {
                dict.Add(skelKnight.level, skelKnight);
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

    #region PowerUp
    [Serializable]
    public class PowerUp
    {
        public int type;
        public int touchDamageIncrement;
        public float touchSpeedIncrement;
        public int maxStaminaIncrement;
        public int skillDamageIncrement;
        public float skillCooltimeRecoveryIncrement;
        public int partnerDamageIncrement;
        public int fixedDamageIncrement;
        public float expIncrement;
        public float goldIncrement;

    }

    [Serializable]
    public class PowerUpLoader : ILoader<int, PowerUp>
    {
        public List<PowerUp> powerUps = new List<PowerUp>();

        public Dictionary<int, PowerUp> MakeDict()
        {
            Dictionary<int, PowerUp> dict = new Dictionary<int, PowerUp>();
            foreach (PowerUp powerUp in powerUps)
            {
                dict.Add(powerUp.type, powerUp);
            }
            return dict;

        }
    }
    #endregion

    #region ExtraAttack
    [Serializable]
    public class ExtraAttack
    {
        public int type;
        public int ice;
        public int greenBall;
        public int meteor;
    }

    [Serializable]
    public class ExtraAttackLoader : ILoader<int, ExtraAttack>
    {
        public List<ExtraAttack> extraAttacks = new List<ExtraAttack>();

        public Dictionary<int, ExtraAttack> MakeDict()
        {
            Dictionary<int, ExtraAttack> dict = new Dictionary<int, ExtraAttack>();
            foreach (ExtraAttack extra in extraAttacks)
            {
                dict.Add(extra.type, extra);
            }
            return dict;

        }
    }
    #endregion

    #region Language
    [Serializable]
    public class Language
    {
        public int type;
        public string None;
        public string CFX;
        public string BGM;
        public string Weapon;
        public string PowerUp;
        public string Start;
        public string Swordwindwhentouch;
        public string Staminarecoverywhentouch;
        public string Arrowwhentouch;
        public string Fixeddamagewhentouch;
        public string Chancetonotskillcooltime;
        public string Summonandskilldamageupwhenoveload;
        public string Maxstaminaup;
        public string Autotouchupgrade;
        public string Autotouchget;
        public string Chancetonotstaminaconsum;
        public string Staminaconsumdown;
        public string Multiattackwhentouch;
        public string Slowwhentouch;
        public string SummonattackSpeedup;
        public string Dragonattackmultishot;
        public string Dragonattackpiercing;
        public string SummonDragon;
        public string Summonsdealextradamage;
        public string GhostSlowUp;
        public string Ghostdodamage;
        public string Summonghost;
        public string Golemattackexplosion;
        public string Golemattackbounce;
        public string Summongolem;
        public string skillresetskillget;
        public string StaminaRecoveryupwhenusingskill;
        public string Touchspeedupwhenusingskill;
        public string Touchabilityupskillget;
        public string HolyshockslowUp;
        public string Slowwhenholyshockattack;
        public string Holyshockskillget;
        public string Enemymaximumhp10persentdamage;
        public string LightningBallskillget;
        public string Arrowcountby3;
        public string Arrowattackwhenexpget;
        public string ExpUp;
        public string ShieldattackSpeedUp;
        public string ShielddamageUp;
        public string Slowwhenshieldattack;
        public string Fixeddamageshield;
        public string BurnRateUp;
        public string Burnsstackby2stacks;
        public string Chancetoburnwhenattacking;
        public string skillrecoveryafterlightninghit;
        public string lightningCountUp;
        public string Fixeddamagelightning;
        public string GoldUp;
        public string Burntransferafterburnenemydie;
        public string Dragonattackspeedupafteroverload;
        public string Arrowsbounce;
        public string Skillrecoveryspeedup;
        public string Enemyspeedup;
        public string Touchspeedup;
        public string Fixeddamageup;
        public string Summondamageup;
        public string Skilldamageup;
        public string Touchdamageup;
        public string Randomprojectileafterattacking10touch;
        public string IceArrowafter30fixeddamage;
        public string icearrowcountup;
        public string IceArrowafter50fixeddamage;
        public string DeathBalldurationup;
        public string DeathBallspeedup;
        public string DeathBallafterusing10skill;
        public string WhirlWindCountUp;
        public string WhirlWindafterattacking25touch;
        public string BurnonMeterorHit;
        public string SlowonMeteorHit;
        public string Meteorafterattacking30summons;
        public string Skillrecoveryspeeddown;
        public string Maxstaminadown;
        public string Touchdamagedown;
        public string Summondamagedown;
        public string Skilldamagedown;
        public string DragonattackSpeedUp;
        public string DragonattackSpeedDown;
        public string overload;
        public string lonelyKnight;
        public string option;
        public string quit;
        public string level;
        public string gameover;
        public string win;
        public string lobby;
        public string tryagein;
        public string equip;
        public string restart;
        public string giveup;
        public string getgold;
        public string staminaRecoveryUp;
        public string overloadend;
        public string touchspeeddown;
        public string staminaRecoveryDown;


    }

    [Serializable]
    public class LanguageLoader : ILoader<int, Language>
    {
        public List<Language> languages = new List<Language>();

        public Dictionary<int, Language> MakeDict()
        {
            Dictionary<int, Language> dict = new Dictionary<int, Language>();
            foreach (Language language in languages)
            {
                dict.Add(language.type, language);
            }
            return dict;

        }
    }
    #endregion
}