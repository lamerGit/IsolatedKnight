using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ObjectManager
{
    public Player MyPlayer { get; private set; }

    public GameObject Skel { get; private set; }
    public GameObject SkelDefence { get; private set; }
    public GameObject SkelSpeed { get; private set; }
    public GameObject SkelKnight { get; private set; }

    public GameObject DamageText { get;private set; }
    public GameObject TouchAttackFx { get; private set; }

    public PartnerDragon PartnerDragon { get; private set; }

    public GameObject DragonBreath { get; private set; }

    public PartnerGolem PartnerGolem { get; private set; }
    public GameObject GolemRock { get; private set; }

    public GameObject RockExplosion { get; private set; }

    public PartnerGost PartnerGost { get; private set; }

    public GameObject GostAttackFx { get;private set; }

    public GameObject OnePointSkillFx { get; private set; }
    
    public GameObject ExpAllow { get;private set; }

    public PassiveDefence PassiveDefence { get; private set; }
    
    public GameObject PassiveLightningFx { get; private set; }

    public GameObject BossSnake { get;private set; }

    public BossSpawner BossZone { get;private set; }

    public GameObject SnakePath { get; private set; }

    public GameObject SwordWind { get; private set; }

    public GameObject BossSnakeBuff { get; private set; }

    public GameObject BossWolf { get; private set; }

    public GameObject WolfPath { get; private set; }

    public GameObject BossWolfBuff { get; private set; }

    public GameObject BossZone2 { get; private set; }

    public GameObject BossBloom { get; private set; }

    public GameObject BloomBullet { get; private set; }

    public GameObject BossBloomBuff { get; private set; }

    public GameObject BossReaper { get; private set; }
    public GameObject ReaperPath { get; private set; }

    public EnemySpawnerGroup EnemySpawnerGroup { get; private set; }

    public void Init()
    {
        GameObject p = Resources.Load<GameObject>($"Prefabs/Player");
        GameObject go = Object.Instantiate(p);
        go.name = p.name;
        
        MyPlayer=go.GetComponent<Player>();

        Skel = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Slave");
        SkelDefence = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Soldier_Defence");
        SkelSpeed = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Soldier_Speed");
        SkelKnight = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Knight");

        DamageText = Resources.Load<GameObject>($"Prefabs/DamageText");
        TouchAttackFx=Resources.Load<GameObject>($"Prefabs/TouchHit");
        
        GameObject partnerD= Resources.Load<GameObject>($"Prefabs/Partner_Dragon");
        GameObject InstPartnerD=Object.Instantiate(partnerD);
        InstPartnerD.name=partnerD.name;

        PartnerDragon =InstPartnerD.GetComponent<PartnerDragon>();
        PartnerDragon.DeSpawn();

        GameObject partnerG= Resources.Load<GameObject>($"Prefabs/Partner_Golem");
        GameObject InstPartnerG=Object.Instantiate(partnerG);
        InstPartnerG.name=partnerG.name;

        PartnerGolem=InstPartnerG.GetComponent<PartnerGolem>();
        PartnerGolem.DeSpawn();

        DragonBreath = Resources.Load<GameObject>($"Prefabs/DragonBreath");
        GolemRock= Resources.Load<GameObject>($"Prefabs/GolemRock");

        RockExplosion= Resources.Load<GameObject>($"Prefabs/RockExplosion");

        GameObject partnerGost= Resources.Load<GameObject>($"Prefabs/Partner_Gost");
        GameObject InstPartnerGost = Object.Instantiate(partnerGost);
        InstPartnerGost.name = partnerGost.name;

        PartnerGost=InstPartnerGost.GetComponent<PartnerGost>();
        PartnerGost.DeSpawn();

        GostAttackFx = Resources.Load<GameObject>($"Prefabs/GostAttack");

        OnePointSkillFx = Resources.Load<GameObject>($"Prefabs/OnePointAttackFx");

        ExpAllow = Resources.Load<GameObject>($"Prefabs/PassiveExpArrow");

        GameObject passiveDefence= Resources.Load<GameObject>($"Prefabs/PassiveDefence");
        GameObject InstPassiveDefence= Object.Instantiate(passiveDefence);
        InstPassiveDefence.name=passiveDefence.name;

        PassiveDefence=InstPassiveDefence.GetComponent<PassiveDefence>();
        PassiveDefence.DeSpawn();

        PassiveLightningFx= Resources.Load<GameObject>($"Prefabs/PassiveLightningFx");

        BossSnake= Resources.Load<GameObject>($"Prefabs/Enemy_Boss_Snake");

        GameObject bossZone= Resources.Load<GameObject>($"Prefabs/BossZone");
        GameObject InstBossZone= Object.Instantiate(bossZone);
        InstBossZone.name=bossZone.name;

        BossZone=InstBossZone.GetComponent<BossSpawner>();

        GameObject snakePath= Resources.Load<GameObject>($"Prefabs/SnakePath");
        SnakePath=Object.Instantiate(snakePath);
        SnakePath.name=snakePath.name;

        SwordWind= Resources.Load<GameObject>($"Prefabs/SwordWind");

        BossSnakeBuff = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_SnakeBuff");

        BossWolf = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_Wolf");

        GameObject wolfPath= Resources.Load<GameObject>($"Prefabs/WolfPath");
        WolfPath = Object.Instantiate(wolfPath);
        WolfPath.name=wolfPath.name;

        BossWolfBuff = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_WolfBuff");

        GameObject bossZone2 = Resources.Load<GameObject>($"Prefabs/BossZone2");
        BossZone2= Object.Instantiate(bossZone2);
        BossZone2.name=bossZone2.name;

        BossBloom = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_Bloom");

        BloomBullet = Resources.Load<GameObject>($"Prefabs/BloomBullet");

        BossBloomBuff = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_BloomBuff");

        GameObject reaperPath= Resources.Load<GameObject>($"Prefabs/ReaperPath");
        ReaperPath=Object.Instantiate(reaperPath);
        ReaperPath.name=reaperPath.name;

        BossReaper = Resources.Load<GameObject>($"Prefabs/Enemy_Boss_Reaper");

        GameObject enemySpawnerGroup = Resources.Load<GameObject>($"Prefabs/SpawnerGroup");
        GameObject InstSpawnerGroup=Object.Instantiate(enemySpawnerGroup);
        InstSpawnerGroup.name=enemySpawnerGroup.name;

        EnemySpawnerGroup=InstSpawnerGroup.GetComponent<EnemySpawnerGroup>();
        EnemySpawnerGroup.SpawnerOff();

    }
}
