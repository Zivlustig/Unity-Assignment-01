using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform player;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, player.position, speed * Time.fixedDeltaTime));
    }
}
