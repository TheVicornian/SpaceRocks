using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class LivesManagement : MonoBehaviour
{
    public Text livesText;

    public GameObject player;

    static public int totalLives;
    public int Lives;

    private void Start()
    {
        
    }

    void Update()
    {
        //display lives counter in UI
        livesText.text= player.GetComponent<PlayerBeh>().lives.ToString();
        
    }

}
