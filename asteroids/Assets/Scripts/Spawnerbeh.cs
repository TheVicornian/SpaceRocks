using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerbeh : MonoBehaviour
{
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        //spawn asteroid
        Instantiate(items[Random.Range(0, 3)], this.transform.position + new Vector3(0, 0.5f, 0), this.transform.rotation);
        Invoke("Spawn", 10);

    }
}
