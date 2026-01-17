using UnityEngine;

public class Player : MonoBehaviour
{
    // Tiempo que tarda en moverse de una casilla a otra (animación)
    public float moveTime = 0.15f;

    // Tiempo mínimo entre movimientos (cooldown)
    public float moveInterval = 0.25f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private float lastMoveTime = 0f; // Último momento en que se inició un movimiento

    [Header("Sprites por dirección")]
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        targetPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Verificar si el juego terminó
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null && gameManager.IsGameOver())
            return;

        // Si ya está en movimiento, no hacer nada aún
        if (isMoving)
            return;

        // Ver cuánto tiempo ha pasado desde el último movimiento
        float timeSinceLastMove = Time.time - lastMoveTime;

        // Solo permitir un nuevo movimiento si ha pasado suficiente tiempo
        if (timeSinceLastMove < moveInterval)
            return;

        // Detectar la dirección actual (permitimos mantener la tecla)
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = Vector2.down;
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;

        // Si hay una dirección válida...
        if (direction != Vector2.zero)
        {
            // Guardar el momento en que se inicia este movimiento
            lastMoveTime = Time.time;

            // Cambiar el sprite según la dirección
            UpdateSprite(direction);

            // Calcular la nueva posición objetivo (una casilla en esa dirección)
            targetPosition = transform.position + new Vector3(direction.x, direction.y, 0);

            // Iniciar el movimiento suave
            StartCoroutine(MoveTo(targetPosition));
        }
    }


    void UpdateSprite(Vector2 direction)
    {
        if (direction == Vector2.up)
            spriteRenderer.sprite = spriteUp;
        else if (direction == Vector2.down)
            spriteRenderer.sprite = spriteDown;
        else if (direction == Vector2.left)
            spriteRenderer.sprite = spriteLeft;
        else if (direction == Vector2.right)
            spriteRenderer.sprite = spriteRight;
    }

    // Mover suavemente al jugador de una casilla a la siguiente, durante un tiempo controlado (moveTime), sin teletransportarlo.
    System.Collections.IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startPosition, destination, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }
}