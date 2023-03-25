using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ClickSound : Singleton<UI_ClickSound>
{
    AudioSource _myAudio;
    

    protected override void Awake()
    {
        base.Awake();
        _myAudio = GetComponent<AudioSource>();


    }

    public void ClickPlay()
    {
        _myAudio.Play();
    }


}
