using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight = true;
    public float despawnDistance = 9f;


    void Start()
    {
        // Flip del auto según dirección
        Vector3 scale = transform.localScale;
        scale.x = moveRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void Update()
    {
        float dir = moveRight ? 1f : -1f;
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta colisión con el jugador
        if (other.CompareTag("Player"))
        {
            // Busca el GameManager y activa el Game Over
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

}