using UnityEngine;

// Clase que representa un coche obstáculo en el juego
public class Car : MonoBehaviour
{
    // Velocidad a la que se mueve el coche
    public float speed = 5f;
    // Dirección en la que se mueve el coche (por defecto hacia la derecha)
    public Vector2 direction = Vector2.right;

    // Método llamado cada frame para mover el coche
    void Update()
    {
        // Mueve el coche en la dirección especificada a la velocidad dada
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el coche se sale de la pantalla (posición X mayor a 15 en valor absoluto), lo destruye
        if (Mathf.Abs(transform.position.x) > 15f)
            Destroy(gameObject);
    }
}
