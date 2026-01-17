using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int maxY = 0;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Record: " + highScore;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        int playerY = Mathf.FloorToInt(player.position.y);

        if (playerY > maxY)
        {
            maxY = playerY;
            scoreText.text = "Score: " + maxY;

            if (maxY > highScore)
            {
                highScore = maxY;
                highScoreText.text = "Record: " + highScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }
}