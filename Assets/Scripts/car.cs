using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight = true;

    void Update()
    {
        float dir = moveRight ? 1f : -1f;
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
    }

    // Opcional: destruir si sale muy lejos (evita acumulación)
    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}