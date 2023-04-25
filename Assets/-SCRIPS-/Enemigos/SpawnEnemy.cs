using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{   
    public GameObject[] Enemys;      
    public float currentTime;
    public int time = 20;
    public Transform SpawnPos;
    public int EnemiNum=0;
    void Start()
    {
        currentTime = time;       
    }    
    void Update()
    {
        StartTemp();
        EnemySpawn();        
    }
    public void EnemySpawn()
    {
        if (currentTime >= time && EnemiNum<=10)
        {
            EnemiNum += 1;
            currentTime = 0f;
            int n = Random.Range(0, Enemys.Length);
            Instantiate(Enemys[n], SpawnPos.position,Enemys[n].transform.rotation);
        }         
    }
    public void StartTemp()
    {
        if(currentTime <=10)
        {
            currentTime += 1 * Time.deltaTime;
        }
       
    }
}
