using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkBlast : MonoBehaviour
{

    [HideInInspector]
    public MoveToClick toClick;
    [HideInInspector]
    public STATS stats;
    [HideInInspector]
    public ComboMele ComboMele;
    public Transform launchPos;

    public int time = 1;
    public float currentTime;
    public GameObject Blast;
    public GameObject BlastLauncher;

    public Animator anim;
    public Image CoolDown;
    public Rigidbody rb;
    //audio
    public AudioSource _audSource;
    public AudioClip Blast_;
    void Start()
    {
        toClick = gameObject.GetComponent<MoveToClick>();
        stats = gameObject.GetComponent<STATS>();
        ComboMele = gameObject.GetComponent<ComboMele>();
        currentTime = time;

    }

    
    void Update()
    {
        CoolDown.fillAmount = currentTime / time;
        StartTemp();
        SkillLaunch();
       
    }
    public void SkillLaunch()
    {
        if (Input.GetMouseButtonDown(1) && currentTime >= time && stats.maxMP >= 15 && toClick.Running == false)
        {
            ComboMele.onAttack = true;
            anim.SetTrigger("DarkBlast");          
           
            ComboMele.Focus();
            stats.maxMP -= 20f;
            currentTime = 0f;
            
        }       
    }
    public void SpellLaunch()
    {
        Instantiate(Blast, launchPos.transform.position, launchPos.transform.rotation);//Instancia un gameobject.
        //BlastLauncher.SetActive(true);
        //AudioSound(Blast_);
    }
    public void StopLaunch()
    {
        
        ComboMele.onAttack = false;
       // BlastLauncher.SetActive(false);

    }
    public void StartTemp()
    {
        currentTime += 1 * Time.deltaTime;
    }
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
}
