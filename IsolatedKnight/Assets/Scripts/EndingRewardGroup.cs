using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRewardGroup : MonoBehaviour
{
    GameObject _sword;
    GameObject _axe;
    GameObject _hammer;
    GameObject _stick;
    GameObject _statue;

    private void Awake()
    {
        _sword = transform.Find("Sword").gameObject;
        _axe = transform.Find("Axe").gameObject;
        _hammer = transform.Find("Hammer").gameObject;
        _stick = transform.Find("Staff").gameObject;
        _statue = transform.Find("Statue").gameObject;
    }
    void Start()
    {
       _sword.SetActive(GameDataManager.Instance.SwordClear);
        _axe.SetActive(GameDataManager.Instance.AxeClear);
        _hammer.SetActive(GameDataManager.Instance.HammerClear);
        _stick.SetActive(GameDataManager.Instance.StickClear);
        _statue.SetActive(GameDataManager.Instance.HandClear);
    }

    
}
