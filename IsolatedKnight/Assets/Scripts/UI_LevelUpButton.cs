using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_LevelUpButton : MonoBehaviour
{
    LevelUpOption _option;
    Button _button;

    UI_LevelUpButtonGroup _group;

    TextMeshProUGUI _tierText;
    public LevelUpOption Option
    {
        get { return _option; }
        set
        {
            _option = value;
            switch (_option)
            {
                case LevelUpOption.None:
                    _button.image.sprite = _group._levelIcon[0];
                    break;
                case LevelUpOption.TouchDamage:
                    _button.image.sprite = _group._levelIcon[1];
                    TierCheck(Managers.GameManager.TouchDamageTier);
                    break;
                case LevelUpOption.TouchSpeed:
                    _button.image.sprite = _group._levelIcon[2];
                    TierCheck(Managers.GameManager.TouchSpeedTier);
                    break;
                case LevelUpOption.Stamina:
                    _button.image.sprite = _group._levelIcon[3];
                    TierCheck(Managers.GameManager.StaminaTier);
                    break;
                case LevelUpOption.TouchBuff:
                    _button.image.sprite = _group._levelIcon[4];
                    TierCheck(Managers.GameManager.TouchBuffTier);
                    break;
            }


        }
    }

    private void Awake()
    {  
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButton);

        _group=GetComponentInParent<UI_LevelUpButtonGroup>();
        _tierText=GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnButton()
    {
        switch (Option)
        {
            case LevelUpOption.None:
                break;
            case LevelUpOption.TouchDamage:
                TouchDamageTierSelected();
                break;
            case LevelUpOption.TouchSpeed:
                break;
            case LevelUpOption.Stamina:
                break;
            case LevelUpOption.TouchBuff:
                break;
        }


        Managers.GameManager.State = GameState.Nomal;

        _group.Close();
    }

    void TierCheck(int tier)
    {
        _tierText.text = $"T {tier + 1}";
    }

    void TouchDamageTierSelected()
    {
        switch (Managers.GameManager.TouchDamageTier)
        {
            case 0:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.5f);
                break;
            case 1:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 0.7f);
                Managers.GameManager.TouchTier2SpeedDown = true;
                break;
            case 2:
                Managers.GameManager.ExtraTouchDamage += (int)(Managers.Object.MyPlayer.TouchDamage * 1.0f);
                Managers.GameManager.TouchTier2MultiHit = true;
                break;

        }

       

        Managers.GameManager.TouchDamageTier++;
    }
}
