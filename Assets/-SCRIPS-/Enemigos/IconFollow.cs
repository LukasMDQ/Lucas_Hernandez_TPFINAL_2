using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Animations;

public class IconFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject BarraHP;
    private void Start()
    {
        target = GameObject.Find("MiniMapCam");

                                          // target = GetComponent<GameObject>();
                                           // target = GetComponent<GameObject>();
    }
    void Update()
    {
       transform.forward = target.transform.forward;
    }
}
