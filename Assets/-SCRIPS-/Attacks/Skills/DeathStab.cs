using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class DeathStab : MonoBehaviour
{
    [HideInInspector]
    public ComboMele ComboMele;
    [HideInInspector]
    public MoveToClick toClick;
    [HideInInspector]
    public STATS stats;

    public int time = 1;
    public float currentTime;
    public GameObject skillEffect;
    public Animator anim;
    public Image CoolDown;
    public Transform instancePos;
    //audio
    public AudioSource _audSource;
    public AudioClip Stab_Hit;

    void Start()
    {
        ComboMele = gameObject.GetComponent<ComboMele>();
        toClick = gameObject.GetComponent<MoveToClick>();
        stats = gameObject.GetComponent<STATS>();
        currentTime = time;
    }
        
    void Update()
    {
        SkillLaunch();
        CoolDown.fillAmount = currentTime / time;
        StartTemp();
    }
    public void StartTemp()
    {       
        currentTime += 5 * Time.deltaTime;
    }
   
    public void SkillLaunch()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentTime >= time && stats.maxMP >= 30 && toClick.Running == false) 
        {
            ComboMele.Focus();
            AudioSound(Stab_Hit);
            stats.maxMP -= 20f;
            currentTime = 0f;                       
            anim.SetTrigger("DarkStab");
        }
    }    
    public void StabEffectStart()
    {
        ComboMele.onAttack = true;
       // Instantiate(skillEffect, instancePos.position, transform.rotation);
       skillEffect.SetActive(true);
    }
    public void StabEffectEnd()
    {
        ComboMele.onAttack = false;
        skillEffect.SetActive(false);
    }
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
}
