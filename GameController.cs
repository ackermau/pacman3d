using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // score value as int
    public static int score;
    // number of lives as int
    public static int lives;
    // score as text
    private Text scoreText;
    // number of lives as text
    private Text livesText;
    // boolean value of if Pac can eat ghosts
    public static bool op;
    // timer for pac eating ghosts
    private float opTimer = 30.0f;
    // timer as text
    private Text opText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
        op = false;
        scoreText = GameObject.Find("ScoreLabel").GetComponent<Text>();
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        opText = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            opTimer -= Time.deltaTime;
            opText.text = "Timer: " + opTimer.ToString();
            if (opTimer < 0)
            {
                op = false;
                opTimer = 30.0f;
            }
        }
        scoreText.text = "Score: " + score.ToString();
        if (lives > 0)
        {
            livesText.text = "Lives: " + lives.ToString();
        }
        else
        {
            livesText.text = "GAME OVER";
        }
    }
}
