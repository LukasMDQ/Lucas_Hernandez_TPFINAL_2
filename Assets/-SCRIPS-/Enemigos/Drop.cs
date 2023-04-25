using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Transform itemPos;
    public GameObject[] itemDrop;
   
    public void RandomDrop()
    {
        int n = Random.Range(0, itemDrop.Length);
        Instantiate(itemDrop[n], itemPos.position, itemDrop[n].transform.rotation);

    }



}
