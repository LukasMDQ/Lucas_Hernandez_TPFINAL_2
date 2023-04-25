
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class Eventos : MonoBehaviour
{
    [SerializeField] private UnityEvent TriggerEvent;
   
    public int rotSpeed=5;
    public CadenaEfectos cadenaEfectos;
    public GameObject[] efectos;
   
    void Update()
    {
        transform.Rotate(rotSpeed * Time.deltaTime, 0,0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("piso"))
        {
            Debug.Log("EVENT");
            TriggerEvent.Invoke();
        }
    }
   /* private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("piso"))
        {

            Destroy(efectos[2]);
            //Destroy(cadenaEfectos.rayos);
            //Destroy(cadenaEfectos.sonido);

            Debug.Log("FinEvent");           
        }
    }*/
}
