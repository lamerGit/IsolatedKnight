using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameSet : MonoBehaviour
{
    UI_DamageRank _damageRank;

    private void Awake()
    {
        _damageRank = transform.Find("Scroll View").GetComponent<UI_DamageRank>();

    }

    public void Open()
    {
        gameObject.SetActive(true);
        _damageRank.Open();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
