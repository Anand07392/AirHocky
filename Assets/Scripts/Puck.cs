using UnityEngine;

public class Puck : MonoBehaviour
{
    public float initialSpeed = 8f;
    public float maxSpeed = 15f;
    public float slowdownFactor = 1f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetAndServe(true);
    }

    public void ResetAndServe(bool toRight)
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        // small random angle
        float angle = Random.Range(-20f, 20f);
        Vector2 dir = (toRight ? Vector2.right : Vector2.left);
        dir = Quaternion.Euler(0, 0, angle) * dir;
        rb.AddForce(dir.normalized * initialSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
