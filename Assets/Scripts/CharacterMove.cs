using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    public Rigidbody2D rb;

    private float moveInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int availavbleJumps;
    public int jumpCount;

    private void Start()
    {
        availavbleJumps = jumpCount - 1;
    }

    private void Update()
    {
        if (isGrounded)
        {
            availavbleJumps = jumpCount - 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && availavbleJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            availavbleJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && availavbleJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}

