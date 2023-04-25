using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMele : MonoBehaviour
{
    public MoveToClick toClick;
    public Camera playerCam;
    
    Animator anima;
    int clickCount;
    bool moreClick;
    public bool onAttack;
    public float focusPosition = -50f;
    //audio
    public AudioSource audio_com;
    public AudioClip combo_1;
    public AudioClip combo_2;
    public AudioClip combo_3;
    public AudioClip combo_4;


    void Start()
    {
        audio_com = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        clickCount = 0;
        moreClick = true;
        onAttack = false;
    }


    void Update()
    {
       
        if ((Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift)) && toClick.Running == false )
        {
            Focus();
            onAttack = true;
            StartCombo(); 
        }             
    }
    public void Focus()
    {      
            Vector3 positionOnScreen = playerCam.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)playerCam.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - focusPosition;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));      

    }
    void StartCombo()
    {      
        if (moreClick)
        {
            clickCount++;
        }
        if(clickCount == 1) 
        {
            AudioSound(combo_1);
            anima.SetInteger("Combo", 1);
        }
    }
    void ComboScan()
    {
        moreClick = false;
        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && clickCount == 1 && toClick.Running == false)
        {
           onAttack= false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && clickCount >= 2 && toClick.Running == false)
        {
            AudioSound(combo_2);
            anima.SetInteger("Combo", 2);
            moreClick = true;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && clickCount == 2 && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && clickCount >= 3 && toClick.Running == false)
        {
            AudioSound(combo_3);
            anima.SetInteger("Combo", 3);
            moreClick = true;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo3") && clickCount == 3 && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo3") && clickCount >= 4 && toClick.Running == false)
        {
            AudioSound(combo_4);
            anima.SetInteger("Combo", 4);
            moreClick = true;
            
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo4") && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
       

    }
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        audio_com.clip = _Clip_Test;
        audio_com.Play();
    }
}
