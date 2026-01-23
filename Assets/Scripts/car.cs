using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight = true;
    
    public AudioSource sonido_carro_choque;

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
            // Sonido del carro al chocar
            if (sonido_carro_choque != null)
            {
                sonido_carro_choque.Play();
            }

            // GRITO 
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Scream();
            }
            
            // Empujon
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 hitDir = moveRight ? Vector2.right : Vector2.left;

                    playerRb.linearVelocity = Vector2.zero;
                    playerRb.angularVelocity = 0f;

                    playerRb.AddForce(hitDir * 8f, ForceMode2D.Impulse);
                    playerRb.AddTorque(-hitDir.x * 500f, ForceMode2D.Impulse);
                }
            
            // Busca el GameManager y activa el Game Over
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

}