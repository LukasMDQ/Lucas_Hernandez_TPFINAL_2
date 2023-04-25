using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Animations;

public class BarraHpFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject BarraHP;
    private void Start()   
    {
        target = GameObject.Find("Camera");        
    }
    void Update()
    {
       transform.forward = target.transform.forward;
    }
}
