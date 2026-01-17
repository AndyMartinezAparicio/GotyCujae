using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight = true;
    public float despawnDistance = 8f;

    void Update()
    {
        float dir = moveRight ? 1f : -1f;
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

}