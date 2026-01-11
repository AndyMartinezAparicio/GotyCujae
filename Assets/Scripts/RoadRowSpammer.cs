using UnityEngine;

public class RoadRowSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    public bool moveRight = true; // Dirección de los autos en esta fila
    public float spawnXOffset = 10f; // Desde dónde entran (ej. -10 o +10)

    private float nextSpawnTime = 0f;

    void Start()
    {
        // Programar primera aparición
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCar();
            nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    void SpawnCar()
    {
        // Posición de aparición: fuera de la pantalla, en el lado correcto
        float spawnX = moveRight ? -spawnXOffset : spawnXOffset;
        Vector3 spawnPos = new Vector3(spawnX, transform.position.y, 0);

        GameObject carObj = Instantiate(carPrefab, spawnPos, Quaternion.identity);
        Car car = carObj.GetComponent<Car>();
        if (car != null)
        {
            car.moveRight = moveRight;
            // Puedes ajustar velocidad por fila si quieres:
            // car.speed = Random.Range(2f, 5f);
        }
    }
}