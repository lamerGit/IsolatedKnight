using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillSlot : MonoBehaviour
{
    public Button _button;
    public Image _backGroundImage;

    SkillType _skillType;
    public SkillType SkillType
    {
        get { return _skillType; }
        set { _skillType = value;

            switch (_skillType)
            {
                case SkillType.None:
                    break;
                case SkillType.OnePoint:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillOnePoint];
                    _backGroundImage.sprite= Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillOnePoint];
                    break;
                case SkillType.MultiPoint:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillMultiPoint];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillMultiPoint];
                    break;
                case SkillType.TouchBuff:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillTouchBuff];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillTouchBuff];
                    break;
                case SkillType.Buff:
                    _button.image.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillBuff];
                    _backGroundImage.sprite = Managers.UIManager.LevelUpButtonGroup._levelIcon[(int)LevelUpOption.SkillBuff];
                    break;
            }


        }
    }


    private void Awake()
    {
        _button = transform.Find("Button").GetComponent<Button>();
        _backGroundImage = transform.Find("Background").GetComponent<Image>();

        _button.onClick.AddListener(OnSkill);
    }

    void OnSkill()
    {
        switch (SkillType)
        {
            case SkillType.None:
                break;
            case SkillType.OnePoint:
                break;
            case SkillType.MultiPoint:
                break;
            case SkillType.TouchBuff:
                break;
            case SkillType.Buff:
                break;
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}
