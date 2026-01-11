using UnityEngine;

// Clase singleton que gestiona el estado general del juego, como la puntuación y el fin del juego
public class GameManager : MonoBehaviour
{
    // Instancia única del GameManager (patrón singleton)
    public static GameManager Instance;

    // Puntuación actual del jugador
    public int score;
    // Máxima fila alcanzada por el jugador
    private int maxRowReached;

    // Método llamado al inicializar el objeto para asegurar el patrón singleton
    void Awake()
    {
        // Si no hay instancia, esta es la instancia; de lo contrario, destruye este objeto
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Método para actualizar la puntuación basada en la fila alcanzada
    public void UpdateScore(int row)
    {
        // Si la fila actual es mayor que la máxima alcanzada, actualiza la máxima y la puntuación
        if (row > maxRowReached)
        {
            maxRowReached = row;
            score = row;
        }
    }

    // Método para manejar el fin del juego
    public void GameOver()
    {
        // Pausa el tiempo del juego
        Time.timeScale = 0f;
        // Registra en la consola que el juego ha terminado
        Debug.Log("GAME OVER");
    }
}
