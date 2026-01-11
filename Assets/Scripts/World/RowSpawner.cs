using UnityEngine;
using System.Collections.Generic;

// Clase responsable de generar filas del mundo (hierba o carretera) basadas en la posición del jugador
public class RowSpawner : MonoBehaviour
{
    // Prefab para la fila de hierba
    public GameObject grassRowPrefab;
    // Prefab para la fila de carretera
    public GameObject roadRowPrefab;
    // Referencia al transform del jugador para determinar qué filas generar
    public Transform player;

    // Índice de la última fila generada
    private int lastSpawnedRow = 0;
    // Diccionario que almacena las filas generadas por índice de fila
    private Dictionary<int, GameObject> spawnedRows = new();

    // Método llamado cada frame para verificar si se necesitan generar nuevas filas
    void Update()
    {
        // Calcula la fila actual del jugador redondeando su posición Y
        int playerRow = Mathf.RoundToInt(player.position.y);

        // Genera filas por delante del jugador (10 filas adelante)
        for (int i = playerRow; i < playerRow + 10; i++)
        {
            // Si la fila no ha sido generada aún, la crea
            if (!spawnedRows.ContainsKey(i))
                SpawnRow(i);
        }
    }

    // Método para generar una fila específica en el índice dado
    void SpawnRow(int rowIndex)
    {
        // Decide aleatoriamente el tipo de fila (60% hierba, 40% carretera)
        RowType type = Random.value > 0.6f ? RowType.Road : RowType.Grass;

        // Selecciona el prefab correspondiente al tipo
        GameObject prefab = type == RowType.Road
            ? roadRowPrefab
            : grassRowPrefab;

        // Instancia la fila en la posición correspondiente
        GameObject row = Instantiate(
            prefab,
            new Vector3(0, rowIndex, 0),
            Quaternion.identity
        );

        // Agrega la fila generada al diccionario
        spawnedRows.Add(rowIndex, row);
    }
}
