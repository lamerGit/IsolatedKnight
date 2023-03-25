using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitSound : MonoBehaviour
{
    AudioSource _myAudio;
    private static EnemyHitSound instance = null;
    public static EnemyHitSound Instance
    {
        get
        {

            return instance;
        }
    }

    private void Awake()
    {
        _myAudio = GetComponent<AudioSource>();
        
        instance = this;
    }


    public void HitPlay()
    {
        _myAudio.Play();
    }
}
