using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;

    [Header("Player Reference")]
    public GameObject player;

    private bool isGameOver = false;
    private ScoreManager scoreManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicializar UI
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Buscar el ScoreManager
        scoreManager = FindObjectOfType<ScoreManager>();

        // Configurar botón de reinicio
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        // Desactivar el control del jugador
        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                Destroy(playerScript); // O puedes desactivarlo de otra forma
            }
        }

        // Mostrar panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            // Obtener puntuaciones
            if (scoreManager != null)
            {
                int currentScore = Mathf.FloorToInt(player.transform.position.y);
                int highScore = PlayerPrefs.GetInt("HighScore", 0);

                finalScoreText.text = "Score: " + currentScore;
                highScoreText.text = "Best: " + highScore;
            }
        }

        // Detener el tiempo del juego (opcional)
        // Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reiniciar el tiempo si lo detuviste
        // Time.timeScale = 1f;

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}