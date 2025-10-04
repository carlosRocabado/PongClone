using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Aumentar velocidad gradualmente
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity *= 1.05f;
        }

        // Efecto de sonido (agregar después)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Sonido de rebote en raqueta
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        Invoke("LaunchBall", 1f);
    }
}