using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class STATS : MonoBehaviour
{
    //audio
    public AudioSource _audSource;
    public AudioClip lvl_sound;
    //LVL
    public GameObject lvl_UP_Effect;
    public Transform PlayerPos;
    public int LVL;
    //EXP
    public TextMeshProUGUI textMesh;
    public int exp = 100;
    public float maxEXP;
    public Image expBar;
    //HP    
    public int hp = 100;
    public float maxHP;
    public Image hpBar;
    //MP    
    public int mp = 100;
    public float maxMP;
    public Image mpBar;
    //Damage
    public float SkillDamage = 30;
    public float Damage = 15f;
    public Respawn respawn;
    public ComboMele comboMele;
    public Berserker berserker;
    //Potions
    public TextMeshProUGUI HP_PotText;
    public TextMeshProUGUI MP_PotText;    
    public int mpPotion = 1;    
    public int hpPotion = 1;
    //ORO
    public int oro = 10;
    public TextMeshProUGUI Cant_oro;


    void Start()
    {
        respawn = gameObject.GetComponent<Respawn>();
        comboMele = gameObject.GetComponent<ComboMele>();
        berserker = gameObject.GetComponent<Berserker>();
    }
    void Update()
    {
        expBar.fillAmount = maxEXP / exp;
        mpBar.fillAmount = maxMP / mp;
        hpBar.fillAmount = maxHP / hp;
        Regeneration();
        PotionUse();
        Death();
        lvlUp();
        textMesh.text = LVL.ToString("0");
        HP_PotText.text = hpPotion.ToString("0");
        MP_PotText.text = mpPotion.ToString("0");
        Cant_oro.text = oro.ToString("0");
    }

    void Regeneration()//Recuperacion Automatica por segundo HP/MP.
    {
        if (maxHP <= 100 && maxHP >= 0)
        {
            maxHP += 0.005f;
        }
        if (maxMP <= 100)
        {
            maxMP += 0.03f;
        }
    }
    
    void Death()//Logica Muerte del personaje.
    {
        if (maxHP <=0)
        {
            Debug.Log("HAS MUERTO");
            respawn.Respawnear();
            maxHP = hp;
        }
    }
    private void lvlUp()//Logica aumento de nivel y estadisticas.
    {             
        if (maxEXP >= 100)
        {
            AudioSound(lvl_sound);
            LVL += 1;
            Instantiate(lvl_UP_Effect, PlayerPos.transform.position,PlayerPos.transform.rotation);
            maxEXP = 0;
            hp += 10;
            mp += 10;
            Damage += 5;
            Debug.Log("Has subido al nivel:" + LVL);           
        }
    }

    private  void OnTriggerEnter(Collider other)//Daño del enemigo y efectos.
    {
        if (other.gameObject.CompareTag("daño"))
        {            
            maxHP -= 1;
            
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
        if (other.gameObject.CompareTag("dañoAlfa"))
        {           
            maxHP -= 10;
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
        //DROP DE OBJETOS
        if (other.gameObject.CompareTag("mpPot"))
        {
            mpPotion += 1;
        }
        if (other.gameObject.CompareTag("hpPot"))
        {
            hpPotion += 1;
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            oro += 5;
        }
    }
        //USO DE POCIONES
    public void PotionUse()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hpPotion > 0 && maxHP <= 90)
        {
            hpPotion -= 1;
            maxHP += 10;
        }
        if (Input.GetKeyDown(KeyCode.E) && mpPotion > 0 && maxMP <= 90)
        {
            mpPotion -= 1;
            maxMP += 10;
        }
    }
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
    
   
}
