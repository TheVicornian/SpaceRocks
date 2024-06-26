using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;

    // Update is called once per frame

    void Start()
    {
        paused = false;
    }
    void Update()
    {
        //toggle pause
       if (Input.GetKeyDown(KeyCode.Escape))
        TogglePause();
    }

    public void TogglePause()
    {
        //activate pause screen
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pauseMenu.SetActive(paused);
    }

   
}