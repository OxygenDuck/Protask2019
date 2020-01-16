using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//BattleHUD UI
public class BattleHUD : MonoBehaviour
{
    //Text in the HUD
    public Text HUDText;
    //HP Slider
    public Slider HpSlider;

    //Set the HUD according to the given unit
    public void SetHUD(Unit unit)
    {
        HUDText.text = unit.unitName + " LV: " + unit.unitLevel;
        HpSlider.maxValue = unit.maxHp;
        HpSlider.value = unit.currentHp;
    }

    //Set the hp value in the slider
    public void SetHP(int HP)
    {
        HpSlider.value = HP;
    }
}
