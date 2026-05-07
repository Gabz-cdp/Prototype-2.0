using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 800;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    private float x;
    private float y;

    private Vector2 input;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        Animate();
    }

    // FixedUpdate is called 50 times per frame
    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;

        //====OLD CODE LOGIC====
        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); */

        if (x > 0 && transform.localScale.x < 0 || x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        //====OLD CODE LOGIC====
        /* anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;*/
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if(moving) ///if moving is true
        {
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
        }

        anim.SetBool("Moving", moving);
    }

    //===OLD CODE LOGIC===
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
    //the player's movement in all directions
    /* A: x = -1 
       D: x = 1
       W: y = 1
       S: y = -1 */
