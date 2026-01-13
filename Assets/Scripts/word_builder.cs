using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject grassRowPrefab;
    public GameObject roadRowPrefab;

    public Transform player;          // para saber hasta dónde generar
    public float rowHeight = 1f;

    public int initialRows = 8;
    public int maxActiveRows = 20;

    private int lastGeneratedRowY = 0;
    private int consecutiveGrass = 0;

    private Queue<GameObject> activeRows = new Queue<GameObject>();


    // Definir el patrón: 0 = pasto, 1 = carretera
    // Ej: [0, 1,1,1,1, 0] → pasto + 4 carreteras + pasto

    void Start()
    {
        int[] initialPattern = { 0, 1, 1, 0, 0, 1, 1, 0 };
        for (int i = 0; i < initialPattern.Length; i++)
        {
            SpawnRow(initialPattern[i], i);
            lastGeneratedRowY = i;
        }
    }

    void Update()
    {
                // Generar nuevas filas por delante del jugador
        int playerRow = Mathf.FloorToInt(player.position.y);

        while (lastGeneratedRowY < playerRow + 10)
        {
            GenerateRandomRow();
        }

        // Destruir filas viejas
        while (activeRows.Count > maxActiveRows)
        {
            GameObject oldRow = activeRows.Dequeue();
            Destroy(oldRow);
        }
    }

    void GenerateRandomRow()
    {
        int rowType;

        if (consecutiveGrass >= 2)
        {
            rowType = 1; // fuerza carretera
        }
        else
        {
            rowType = Random.value < 0.7f ? 1 : 0;
        }

        if (rowType == 0)
            consecutiveGrass++;
        else
            consecutiveGrass = 0;

        lastGeneratedRowY++;
        SpawnRow(rowType, lastGeneratedRowY);
    }

    void SpawnRow(int type, int yIndex)
    {
        GameObject prefab = type == 0 ? grassRowPrefab : roadRowPrefab;
        Vector3 position = new Vector3(0, yIndex * rowHeight, 0);

        GameObject row = Instantiate(prefab, position, Quaternion.identity);
        activeRows.Enqueue(row);
    }
}