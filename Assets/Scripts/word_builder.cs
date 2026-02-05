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

    [Header("Obstacles")]
    public GameObject bache;
    public GameObject arbol;
    
    public int maxTreesPerGrass = 5;
    public float grassObstacleChance = 1f; // 100%
    public float roadObstacleChance = 0.5f;  // 70%

    private float minX = -8f;
    private float maxX = 8f;


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

        if (consecutiveGrass >= 1)
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
        
        // Si es carretera, asignar dirección random
        if (type == 1)
        {
            RoadRowSpawner spawner = row.GetComponent<RoadRowSpawner>();
            if (spawner != null)
            {
                spawner.moveRight = Random.value > 0.5f;
            }
        }

        
        activeRows.Enqueue(row);

        if (type == 0)
        {
            SpawnGrassObstacles(row.transform);
        }
        else
        {
            SpawnRoadObstacle(row.transform);
        }

    }

    void SpawnGrassObstacles(Transform row)
    {
        if (Random.value > grassObstacleChance)
            return;

        int treeCount = Random.Range(2, maxTreesPerGrass + 1);

        for (int i = 0; i < treeCount; i++)
        {
            int x = Random.Range((int)minX, (int)maxX + 1);
            Vector3 pos = new Vector3(x, row.position.y, 0);

            Instantiate(arbol, pos, Quaternion.identity, row);
        }
    }

    void SpawnRoadObstacle(Transform row)
    {
        if (Random.value > roadObstacleChance)
            return;

        int bacheCount = Random.Range(1, 3);
        for (int i = 0; i < bacheCount; i++)
        {
            int x = Random.Range((int)minX, (int)maxX + 1);
            Vector3 pos = new Vector3(x, row.position.y, 0);

            Instantiate(bache, pos, Quaternion.identity, row);
        }
    }



    
}