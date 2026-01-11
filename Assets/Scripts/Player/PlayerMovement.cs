using System.Collections;
using UnityEngine;

// Clase que controla el movimiento del jugador
public class PlayerMovement : MonoBehaviour
{
    // Distancia que se mueve el jugador en cada paso
    public float moveDistance = 1f;
    // Velocidad de movimiento del jugador
    public float moveSpeed = 8f;

    // Indica si el jugador está actualmente en movimiento
    private bool isMoving;
    // Posición objetivo hacia la que se mueve el jugador
    private Vector3 targetPos;

    // Método llamado cada frame para procesar la entrada y mover al jugador
    void Update()
    {
        // Si ya está moviéndose, no hace nada
        if (isMoving) return;

        // Obtiene la dirección de movimiento desde el InputManager
        MoveDirection? input = InputManager.Instance.GetMoveInput();
        // Si no hay entrada, no hace nada
        if (input == null) return;

        // Convierte la dirección de movimiento en un vector 3D
        Vector3 dir = input switch
        {
            MoveDirection.Up => Vector3.up,
            MoveDirection.Down => Vector3.down,
            MoveDirection.Left => Vector3.left,
            MoveDirection.Right => Vector3.right,
            _ => Vector3.zero
        };

        // Calcula la posición objetivo sumando la dirección a la posición actual
        targetPos = transform.position + dir * moveDistance;
        // Inicia la rutina de movimiento
        StartCoroutine(MoveRoutine());
    }

    // Corrutina que maneja el movimiento suave hacia la posición objetivo
    IEnumerator MoveRoutine()
    {
        // Marca que el jugador está moviéndose
        isMoving = true;

        // Mientras no haya llegado a la posición objetivo
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            // Mueve el jugador hacia la posición objetivo a la velocidad especificada
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            // Espera al siguiente frame
            yield return null;
        }

        // Asegura que llegue exactamente a la posición objetivo
        transform.position = targetPos;
        // Actualiza la puntuación en el GameManager con la fila actual
        GameManager.Instance.UpdateScore(Mathf.RoundToInt(transform.position.y));
        // Marca que el movimiento ha terminado
        isMoving = false;
    }

    // Método llamado cuando el jugador colisiona con un trigger 2D
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Si colisiona con un objeto etiquetado como "Car", termina el juego
        if (col.CompareTag("Car"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
