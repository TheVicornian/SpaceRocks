using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    public float bulletSpeed = 7f;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.25f, 0);
        Destroy(this.gameObject, 2);
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Asteroid")

        {
            //destroy asteroid & add points to player
            player.gameObject.GetComponent<PlayerBeh>().score += 10;
            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "Ufo")
        {
            //destroy ufo & add points to player 
            player.gameObject.GetComponent<PlayerBeh>().score += 100;
            Destroy(this.gameObject);
        }

    }
}
