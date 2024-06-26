using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeh : MonoBehaviour
{
    public float speed = 0.025f;
    public GameObject smallerAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (smallerAsteroid != null)
            {
                //spawn smaller asteroid
                Instantiate(smallerAsteroid, this.transform.position, this.transform.rotation);
                Instantiate(smallerAsteroid, this.transform.position, this.transform.rotation);
                Instantiate(smallerAsteroid, this.transform.position, this.transform.rotation);
            }     
                 //destory object
            Destroy(this.gameObject);
        }

    }  
       
    
}
