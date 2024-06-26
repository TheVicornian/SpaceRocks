using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{

    public int score = 0;
     int hiscore = 999;

    public Text Hi_Score;

    public GameObject playerscore;
    // Start is called before the first frame update
    void Start()
    {       
        loadGame();

        AutoSave();
    }

    // Update is called once per frame
    void Update()
    {
        //display Hiscore
        score = playerscore.GetComponent<PlayerBeh>().score;

        
        Hi_Score.text = hiscore.ToString();



    }

    void AutoSave()
    {
        //auto save Hiscore
        saveGame();
        Invoke("AutoSave", 1);

    }

    void saveGame()
    {
        //save hiscore for hiscore UI
        if (score > PlayerPrefs.GetInt("savedScore"))
        {
            hiscore = score;
            PlayerPrefs.SetInt("savedScore", hiscore);
        Debug.Log("savesuccessful");
            Debug.Log("Hi score should be:" + PlayerPrefs.GetInt("savedScore"));
         }
    }

    void EraseGame()
    {
        //erase old hiscore for new hiscore
      PlayerPrefs.SetInt("savedScore", score);
    }

    void loadGame()
    {
        //load new hiscore
        if (PlayerPrefs.HasKey("savedScore"))
        {
            hiscore = PlayerPrefs.GetInt("savedScore");
            Debug.Log("load successful");

        }
        else
        {
            Debug.Log("cannot load");
        }

    }
}
