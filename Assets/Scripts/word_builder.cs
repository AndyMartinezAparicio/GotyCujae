using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject grassRowPrefab;
    public GameObject roadRowPrefab;

    // Definir el patrón: 0 = pasto, 1 = carretera
    // Ej: [0, 1,1,1,1, 0] → pasto + 4 carreteras + pasto
    private int[] worldPattern = { 0, 1, 1, 1, 1, 1, 1, 0 };

    void Start()
    {
        BuildWorld();
    }

    void BuildWorld()
    {
        for (int y = 0; y < worldPattern.Length; y++)
        {
            GameObject prefab = worldPattern[y] == 0 ? grassRowPrefab : roadRowPrefab;
            Vector3 position = new Vector3(0, y, 0); // Centrado en X=0
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}