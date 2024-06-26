using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry_beh : MonoBehaviour
{
    
    public GameObject target;
    



   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerBeh>().hitBarrier == false)
        {
          //teleport player on y axis
            float currentY = other.gameObject.transform.position.y;
            other.gameObject.transform.position = target.gameObject.transform.position +new Vector3(0,currentY,0);
            target.SetActive(false);
            Invoke("Spawn", 0.3f);  
        }
    }

    void  Spawn()
    {
        //respawn barrier
        target.SetActive(true);
    }


  
    
}
