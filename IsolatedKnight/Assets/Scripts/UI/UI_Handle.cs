using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Handle : MonoBehaviour, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("¼Õ¶«");
        GameDataManager.Instance.SaveData();
    }
}
