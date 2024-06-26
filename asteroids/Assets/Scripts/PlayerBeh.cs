using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class PlayerBeh : MonoBehaviour
{
    //score
    public int score = 0;
    
    //player
    public float speed = 1.0f;
    public GameObject bullet;
    public float jetSpeed = 0.025f;

    //lives
    public Text livesText;
    public int lives = 3;



    //respawn
    public bool isDead;
    bool respawning = false;
    public GameObject respawnPoint;
   
    
    //Gameover
    public GameObject gameoverScreen;
    public GameObject mesh;

    //barrier wrap
    public bool hitBarrier = false;


    public bool isActive;

   
    // Update is called once per frame
    void Update()
    {

        // shoot
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, transform.rotation);

            if (isActive == true)
                Instantiate(bullet [3], transform.position, transform.rotation);



        }


        //move player
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0,1.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -1.5f);
        }
                     
    }

       //destory player
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            //playerDeath
            if (lives > 0)
            {
                lives = lives - 1;
                this.gameObject.transform.position = respawnPoint.gameObject.transform.position;
            }
            //starts repawn sequence
            else { StartCoroutine(RespawnSequence()); } 
            
        }

        if (other.gameObject.tag == "UFOBullet")
        {

            if (lives > 0)
            {
                lives = lives - 1;
                this.gameObject.transform.position = respawnPoint.gameObject.transform.position;
            }

           else { StartCoroutine(RespawnSequence()); }

        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag = "PowerUp1")
        {
            isActive.SetActive(true);
        }

    }
   

    //Respawning Player
    IEnumerator RespawnSequence()
    {
        if (respawning)
            yield break;

        respawning = true;

        yield return new WaitForSeconds(1);

        if (lives == 0) //no lives do this.
        {
            mesh.SetActive(false);
            gameoverScreen.SetActive(true);
        }

        isDead = true;
        jetSpeed = 0;
        yield return new WaitForSeconds(1);

        while (!Input.GetKey(KeyCode.Space))
            yield return null;  // waits for player to press space to continue.

        respawning = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        

    }

   
}