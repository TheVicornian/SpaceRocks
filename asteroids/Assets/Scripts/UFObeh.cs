using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFObeh : MonoBehaviour
{
    // UFO properties 
    public float ufoSpeed = 7f;
    public float timer = 2f;
    public float shootTimer = 10f;
    public GameObject UFObullet;
    public GameObject respawnPoint;

    private Vector3 initialPosition;
    private bool isMovingRight = false; // Flag to track UFO's movement direction

    private void Start()
    {
        initialPosition = transform.position;
        Invoke("Flip", timer); // Start with a delay to move left initially
        Shoot();
    }

    private void Update()
    {
        float movement = ufoSpeed * Time.deltaTime * (isMovingRight ? 1 : -1);
        transform.Translate(movement, 0, 0);
    }

    private void Flip()
    {
        isMovingRight = !isMovingRight;
        Invoke("Flip", timer); // Invoke again to flip movement direction after 'timer' seconds
    }

    private void Shoot()
    {
        Instantiate(UFObullet, transform.position, transform.rotation);
        Invoke("Shoot", shootTimer);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Cancel any pending Invoke calls
            CancelInvoke();

            // Respawn UFO at the respawn point
            RespawnUFO();
        }
    }

    private void RespawnUFO()
    {
        transform.position = respawnPoint.transform.position;

        // Restart timers after respawn
        Invoke("Flip", timer); // Start with a delay to move left initially
        Shoot();
    }
}