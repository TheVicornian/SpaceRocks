using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFObulletBeh : MonoBehaviour
{
    public float bulletSpeed = 5f;

 

    // Update is called once per frame
    void Update()
    {
        //destroy object
        transform.Translate(0, -0.25f ,0);
        Destroy(this.gameObject, 3);

    }

    private void OnCollisionEnter(Collision other)
    {
        //destroy player
        if  (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
