using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingSword : MonoBehaviour
{
    [HideInInspector]
    public MoveToClick toClick;
    [HideInInspector]
    public STATS stats;
    [HideInInspector]
    public ComboMele ComboMele;

    public int time = 1;
    public float currentTime;
    public GameObject skillEffect;
    public Animator anim;
    public Image CoolDown;
    public Rigidbody rb;
    public float inpuseStr = 10f;
    //audio
    public AudioSource _audSource;
    public AudioClip fallen_Hit;

    void Start()
    {
        toClick = gameObject.GetComponent<MoveToClick>();
        stats = gameObject.GetComponent<STATS>();
        ComboMele = gameObject.GetComponent<ComboMele>();
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
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentTime >= time && stats.maxMP>=30 && toClick.Running == false)
        {
            ComboMele.Focus();
            AudioSound(fallen_Hit);
            stats.maxMP -= 20f;
            currentTime = 0f;
            anim.SetTrigger("FallingSword");
        }
    }
    public void FallingEffectStart()
    {
        ComboMele.onAttack = true;
        skillEffect.SetActive(true);
    }
    public void FallingEffectEnd()
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
