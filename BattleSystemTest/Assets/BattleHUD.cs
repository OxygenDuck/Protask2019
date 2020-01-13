using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text HUDText;
    public Slider HpSlider;

    public void SetHUD(Unit unit)
    {
        HUDText.text = unit.unitName + " LV: " + unit.unitLevel;
        HpSlider.maxValue = unit.maxHp;
        HpSlider.value = unit.currentHp;
    }

    public void SetHP(int HP)
    {
        HpSlider.value = HP;
    }
}
