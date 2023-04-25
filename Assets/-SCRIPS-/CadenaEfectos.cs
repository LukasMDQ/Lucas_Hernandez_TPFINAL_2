using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CadenaEfectos : MonoBehaviour
{
    public GameObject Rain;    
    public GameObject rayos;
    public GameObject sonido;   


    public void Lluvia()
    {
        Instantiate(Rain);       
    }
    public void SonidoLluvia()
    {
        Instantiate(sonido);
    }

    public void InstaRayos()
    {
        Instantiate(rayos);        
    }
   






}
