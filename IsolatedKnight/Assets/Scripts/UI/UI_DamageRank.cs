using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DamageRank : MonoBehaviour
{
    UI_DamageRankItem[] _items;

    public Sprite[] _icons;

    private void Awake()
    {
        _items=transform.Find("Viewport/Content").GetComponentsInChildren<UI_DamageRankItem>();
    }

    public void Open()
    {
        Dictionary<DamageType,int> temp=new Dictionary<DamageType,int>();
        temp = Managers.GameManager.DamageCheck.OrderByDescending(item => item.Value).ToDictionary(x => x.Key, x => x.Value);

        int index = 0;
        float maxDamage = temp.First().Value;
        foreach(var d in temp)
        {
            if (d.Value == 0)
            {
                _items[index].gameObject.SetActive(false);
            }else
            {
                _items[index].SetDamageItemUI(_icons[(int)d.Key],d.Value,maxDamage);
                
            }
            index++;

        }
    }
}
