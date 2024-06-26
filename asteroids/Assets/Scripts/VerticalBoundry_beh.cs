using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VerticalBoundry_beh : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerBeh>().hitBarrier == false)
        {
            //teleports player on x axis
            float currentX = other.gameObject.transform.position.x;
            other.gameObject.transform.position = target.gameObject.transform.position + new Vector3(0, currentX, 0);
            target.SetActive(false);
            Invoke("Spawn", 0.3f);
        }
    }

    void Spawn()
    {
        //respawn barrier
        target.SetActive(true);
    }
}
