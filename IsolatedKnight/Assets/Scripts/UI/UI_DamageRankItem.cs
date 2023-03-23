using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DamageRankItem : MonoBehaviour
{
    Image _icon;
    TextMeshProUGUI _damageText;
    Image _gauge;

    float _startPoint = 0.0f;

    WaitForSeconds _timer = new WaitForSeconds(0.001f);

    private void Awake()
    {
        _icon = transform.Find("Icon").GetComponent<Image>();
        _damageText = transform.Find("DamageText").GetComponent<TextMeshProUGUI>();
        _gauge = transform.Find("Value").GetComponent<Image>();
    }

    public void SetDamageItemUI(Sprite icon, float damage,float maxDamage)
    {
        _icon.sprite = icon;
        _damageText.text = $"{damage}";
        StartCoroutine(SlowUp(damage, maxDamage));
    }

    IEnumerator SlowUp(float damage,float maxDamage)
    {
        while(_startPoint< damage)
        {
            _gauge.fillAmount = _startPoint / maxDamage;
            _startPoint += Time.deltaTime * 1000.0f;

            yield return _timer;
        }
    }
}
