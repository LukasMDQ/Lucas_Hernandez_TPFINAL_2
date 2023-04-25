using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{  
    public Camera playerCam;
    public float launchPos = -50f;
    void Update()
    {
        FocusAttack();
    }
    public void FocusAttack()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 positionOnScreen = playerCam.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)playerCam.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - launchPos;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
      
    }

}
