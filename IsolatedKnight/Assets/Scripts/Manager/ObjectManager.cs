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
    public void Init()
    {
        GameObject p = Resources.Load<GameObject>($"Prefabs/Player");
        GameObject go = Object.Instantiate(p);
        go.name = p.name;
        
        MyPlayer=go.GetComponent<Player>();

        Skel = Resources.Load<GameObject>($"Prefabs/Enemy_Skel_Slave");
        DamageText=Resources.Load<GameObject>($"Prefabs/DamageText");
    }
}
