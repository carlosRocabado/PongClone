using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public bool isPlayer1 = true;
    private float verticalInput;
    private Rigidbody2D rb;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        // Controles diferentes para cada jugador
        if (isPlayer1)
        {
            verticalInput = Input.GetAxis("Vertical1"); // W/S
        }
        else
        {
            verticalInput = Input.GetAxis("Vertical2"); // Flechas ↑/↓
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, verticalInput * speed);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
    }
}