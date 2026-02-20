using TMPro;
using UnityEngine;

public class Mallet : MonoBehaviour
{
    public float speed = 8f;
    public bool isPlayerOne;

    public float boundaryX = 7f; 
    public float boundaryY = 7f;
    public Transform puck;
    private Vector3 targetPosition;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 move = Vector2.zero;

        if (isPlayerOne)
        {
            // Mouse position in screen
            Vector3 mouseScreenPos = Input.mousePosition;

            // Convert screen position to world position
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = transform.position.z; // keep same Z

            // Direction from player to mouse
            Vector2 direction = (mouseWorldPos - transform.position);

            // Normalize so speed is constant
            move = direction.normalized;

        }
        else
        {
            if (puck == null) return;

            // Follow puck's Y position
            targetPosition = new Vector3(transform.position.x, puck.position.y, transform.position.z);

            // Move smoothly toward puck
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Keep AI inside boundaries
            float clampedY = Mathf.Clamp(transform.position.y, -boundaryY, boundaryY);
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }

        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
    }
}
