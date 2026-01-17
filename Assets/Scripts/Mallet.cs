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
            if (Input.GetKey(KeyCode.W)) move.y = 1;
            if (Input.GetKey(KeyCode.S)) move.y = -1;
            if (Input.GetKey(KeyCode.A)) move.x = -1;
            if (Input.GetKey(KeyCode.D)) move.x = 1;
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
