using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    public AudioClip _horrorSimple;

    AudioSource _myAudio;
    private static BackGroundSound instance = null;
    public static BackGroundSound Instance
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


    public void BackGroundStop()
    {
        _myAudio.Stop();
    }

    public void SoundChange()
    {
        _myAudio.clip = _horrorSimple;
    }
}
