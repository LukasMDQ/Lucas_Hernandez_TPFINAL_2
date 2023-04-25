using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float destroyTime = 3f;
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Personaje"))
        {
            Destroy(this.gameObject);
        }
    }
}
