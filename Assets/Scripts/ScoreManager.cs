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

// Propiedades para acceder a las puntuaciones desde otros scripts
    public int CurrentScore => maxY;
    public int HighScore => highScore;

    void Start()
    {
        //  DESCOMENTA ESTA LÍNEA Y EJECUTA PARA REINICIAR EL HIGH SCORE
        //PlayerPrefs.DeleteKey("HighScore");
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

        // Ctrl + R → resetea High Score
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
            Debug.Log("High Score reseteado manualmente");
        }
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}