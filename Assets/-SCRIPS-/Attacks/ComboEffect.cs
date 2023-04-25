using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ComboEffect : MonoBehaviour
{
    public GameObject effect;
    public GameObject Slasheffect;
    public ComboMele comboMele;
    void Start()
    {
        comboMele = gameObject.GetComponent<ComboMele>();

    }
    public void ActivePower()
    {
        comboMele.onAttack = true;
        effect.SetActive(true);
    }
    public void desactivePower()
    {
        comboMele.onAttack = false;
        effect.SetActive(false);
    }
    //SlashSword Effect
    public void activeEffect()
    {
        Slasheffect.SetActive(true);
    }
    public void desactiveEffect()
    {
        Slasheffect.SetActive(false);
    }
}
