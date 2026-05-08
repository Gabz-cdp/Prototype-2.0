using UnityEngine;

public class CobwebDeerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
