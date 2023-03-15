using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ObjectManager
{
    public Player MyPlayer { get; private set; }

    public GameObject Skel { get; private set; }

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
    public void Init()
    {
        GameObject p = Resources.Load<GameObject>($"Prefabs/Player");
        GameObject go = Object.Instantiate(p);
        go.name = p.name;
        
        MyPlayer=go.GetComponent<Player>();

        Skel = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Slave");
        DamageText=Resources.Load<GameObject>($"Prefabs/DamageText");
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

    }
}
