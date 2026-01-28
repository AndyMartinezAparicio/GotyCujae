using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Game over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;

    [Header("In-Game UI")]
    public GameObject scoreUI;


    [Header("Player Reference")]
    public GameObject player;

    [Header("Diálogo Inicial")]
    public Dialogue initialDialogue;

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

        StartCoroutine(ShowInitialDialogue());
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
                playerScript.enabled = false; // O puedes desactivarlo de otra forma
            }
        }

        if (scoreUI != null)
            scoreUI.SetActive(false);

        // Mostrar panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            // Obtener puntuaciones
            if (scoreManager != null)
            {
                finalScoreText.text = "Score: " + scoreManager.CurrentScore;;
                highScoreText.text = "Best: " + scoreManager.HighScore;
            }
        }

        // Detener el tiempo del juego (opcional)
        // Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reiniciar el tiempo si lo detuviste
        // Time.timeScale = 1f;

        if (GameSessionManager.Instance != null)
        {
            GameSessionManager.Instance.StartedFromMainMenu = false;
        }

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    IEnumerator ShowInitialDialogue()
    {
        // Esperar un momento
        yield return new WaitForSeconds(0.1f);

        bool shouldShowDialogue = false;
        
        if (GameSessionManager.Instance != null)
        {
            shouldShowDialogue = GameSessionManager.Instance.StartedFromMainMenu;
            
            // Una vez verificado, resetear la bandera para futuros retry
            GameSessionManager.Instance.StartedFromMainMenu = false;
        }

        // Verificar si es primera vez (high score = 0)
       
            // Verificar que hay diálogo configurado
        if (shouldShowDialogue && initialDialogue != null && initialDialogue.lines.Length > 0)
        {
            // Mostrar diálogo
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(initialDialogue);
            }
        }
    }
}