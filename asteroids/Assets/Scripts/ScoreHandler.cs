using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text ScoreText;
    public Text Hi_scoreText;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hiscore UI
        Hi_scoreText.text = PlayerPrefs.GetInt("savedScore").ToString(); ;

        //score UI
        ScoreText.text = Player.GetComponent<PlayerBeh>().score.ToString();

    }
}
