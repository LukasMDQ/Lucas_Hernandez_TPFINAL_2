
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{     
    public void Jugar()
    {             
          SceneManager.LoadScene(1);       
    }
    public void Menu()
    {        
          SceneManager.LoadScene(0);       
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void ReproducirAudio()
    {       
         TestSound.PlayAudio();      
    }
    public void PausarAudio()
    {  
         TestSound.PausarAudio();
    }
}
