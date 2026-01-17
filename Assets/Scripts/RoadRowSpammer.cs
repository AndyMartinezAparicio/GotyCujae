using UnityEngine;

public class RoadRowSpawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject carPrefab;
    public float minSpawnDelay = 13;
    public float maxSpawnDelay = 20f;

    [Header("Movement")]
    public bool moveRight = true;  // Dirección de los autos en esta fila
    public float minSpeed = 3f;
    public float maxSpeed = 7f; 
    

    [Header("Despawn")]
    private float despawnDistance = 8f;
    private float nextSpawnTime;


    void Start()
    {
        // Programar primera aparición
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCar();
            ScheduleNextSpawn();
        }
    }

    void SpawnCar()
    {
        if (carPrefab == null)
        {
            Debug.LogError("Car prefab no asignado en " + gameObject.name);
            return;
        }
        
        // Posición de aparición: fuera de la pantalla, en el lado correcto
        float spawnX = moveRight ? -despawnDistance : despawnDistance;
        Vector3 spawnPos = new Vector3(spawnX, transform.position.y, 0);

        GameObject carObj = Instantiate(carPrefab, spawnPos, Quaternion.identity);
        Car car = carObj.GetComponent<Car>();
        if (car != null)
        {
            car.moveRight = moveRight;
            car.speed = Random.Range(minSpeed, maxSpeed);
            car.despawnDistance = despawnDistance;
        }
    }

        void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}