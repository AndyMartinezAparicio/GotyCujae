using UnityEngine;

// Enumeración que define las direcciones de movimiento posibles
public enum MoveDirection { Up, Down, Left, Right }

// Clase singleton que gestiona la entrada del usuario para el movimiento
public class InputManager : MonoBehaviour
{
    // Instancia única del InputManager (patrón singleton)
    public static InputManager Instance;

    // Posición inicial del toque en dispositivos táctiles
    private Vector2 touchStart;

    // Método llamado al inicializar el objeto para asegurar el patrón singleton
    void Awake()
    {
        // Si no hay instancia, esta es la instancia; de lo contrario, destruye este objeto
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Método que devuelve la dirección de movimiento basada en la entrada del usuario
    public MoveDirection? GetMoveInput()
    {
        // En el editor o en plataformas de escritorio, usa las teclas WASD
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.W)) return MoveDirection.Up;
        if (Input.GetKeyDown(KeyCode.S)) return MoveDirection.Down;
        if (Input.GetKeyDown(KeyCode.A)) return MoveDirection.Left;
        if (Input.GetKeyDown(KeyCode.D)) return MoveDirection.Right;
#endif

        // En Android, usa toques para determinar la dirección
#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            // Registra la posición inicial del toque
            if (t.phase == TouchPhase.Began)
                touchStart = t.position;

            // Al finalizar el toque, calcula la dirección basada en el desplazamiento
            if (t.phase == TouchPhase.Ended)
            {
                Vector2 delta = t.position - touchStart;

                // Determina si el movimiento es horizontal o vertical basado en la mayor diferencia
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    return delta.x > 0 ? MoveDirection.Right : MoveDirection.Left;
                else
                    return delta.y > 0 ? MoveDirection.Up : MoveDirection.Down;
            }
        }
#endif
        // Si no hay entrada, devuelve null
        return null;
    }
}
