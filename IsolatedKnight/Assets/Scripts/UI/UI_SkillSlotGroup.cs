using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillSlotGroup : MonoBehaviour
{
    List<UI_SkillSlot> _slotList= new List<UI_SkillSlot>();

    int _slotCount = 0;

    public List<UI_SkillSlot> SlotList
    {
        get { return _slotList; }
        private set { _slotList = value; } 
    } 



    int SlotCount
    {
        get { return _slotCount; }
        set { _slotCount = Mathf.Clamp(value, 0, 4); }

    }

    private void Awake()
    {
        _slotList.Add(transform.Find("SkillSlot_0").GetComponent<UI_SkillSlot>());
        _slotList.Add(transform.Find("SkillSlot_1").GetComponent<UI_SkillSlot>());
        _slotList.Add(transform.Find("SkillSlot_2").GetComponent<UI_SkillSlot>());
        _slotList.Add(transform.Find("SkillSlot_3").GetComponent<UI_SkillSlot>());

        for(int i=0; i< _slotList.Count; i++)
        {
            _slotList[i].gameObject.SetActive(false);
        }
    }

    public void AddSkill(SkillType type)
    {
        for(int i=0; i< _slotList.Count; i++)
        {
            if (_slotList[i].SkillType == type)
                return;
        }

        _slotList[_slotCount].SkillType = type;
        _slotList[_slotCount].Open();

        SlotCount++;



    }

    public void AllCoolTimeReset()
    {
        for (int i = 0; i < _slotList.Count; i++)
        {
            _slotList[i].CurrentSkillColTime = _slotList[i].SkillColTime;
        }
    }
}
