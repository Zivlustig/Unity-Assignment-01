using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public int targetScore = 1000;
    private int score = 0;
    private static string EnemyTag = "Enemy";
    private static string CoinTag = "Coin";
    private Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        
        var dValue = Keyboard.current.dKey.value;
        var aValue = Keyboard.current.aKey.value;
        var wValue = Keyboard.current.wKey.value;
        var sValue = Keyboard.current.sKey.value;
        
        movement += dValue * Vector2.right;
        movement += aValue * Vector2.left;
        movement += wValue * Vector2.up;
        movement += sValue * Vector2.down;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Time.fixedDeltaTime * speed * movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnemyTag))
        {
            Debug.Log("you lose");
            score = 0;
        }

        if (other.CompareTag(CoinTag))
        {
            score += other.GetComponent<Coin>().value;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);

            if (score >= targetScore)
                Debug.Log("you won");
        }
    }
}
