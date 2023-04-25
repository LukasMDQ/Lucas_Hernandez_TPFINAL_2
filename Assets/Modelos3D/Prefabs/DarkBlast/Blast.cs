using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float Speed;
    public float Destruccion;
    private Rigidbody rb;
    public GameObject BlastExplosion;
    public Transform blastPos;    
       
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, Destruccion);
        rb.velocity= transform.forward*Speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemi"))
        {
            Instantiate(BlastExplosion,blastPos.transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("EnemiAlfa"))
        {
            Instantiate(BlastExplosion, blastPos.transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }



}
