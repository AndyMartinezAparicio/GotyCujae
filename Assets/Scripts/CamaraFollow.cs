using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
        // Referencia al transform del jugador para seguirlo
    public Transform player;

    // Método llamado después de Update para ajustar la posición de la cámara
    void LateUpdate()
    {
        // Si la posición Y del jugador es mayor que la de la cámara, actualiza la posición de la cámara
        if (player.position.y + 0.46f > transform.position.y)
        {
            // Mantiene la posición X y Z de la cámara, solo actualiza Y para seguir al jugador hacia arriba
            transform.position = new Vector3(
                transform.position.x,
                player.position.y + 0.46f,  // Ajuste para centrar mejor al jugador en la pantalla
                transform.position.z
            );
        }
    }
}
