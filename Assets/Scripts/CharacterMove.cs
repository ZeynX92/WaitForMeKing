using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject Musket;
    public float speed = 5f;
    public Rigidbody2D rb;

    [Header("Dash Settings")]
    public bool DashEnabled;
    public int DashImpulse = 10;
    public float DashCoolDown = 2f;
    public float DashTime = 0.75f;
    public int DashCount = 1;
    

    private float moveInput;
    private bool DashLock = false;
    private RigidbodyConstraints2D originalConstraints;
    private bool FacingRight = true;
    private Vector3 pos;
    private Camera main;

    [Header("Jump Settings")]
    public float jumpForce;
    [HideInInspector] public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    [HideInInspector] public int availavbleJumps;
    [HideInInspector] public int availavbleDashes;
    public int jumpCount;

    void Awake()
    {
        originalConstraints = rb.constraints;
    }
    
    void Start()
    {
        main = FindObjectOfType<Camera>();
        availavbleJumps = jumpCount - 1;
        availavbleDashes = DashCount;
    }

    public void Jump(float jumpForce)
    {
        if (isGrounded)
        {
            availavbleJumps = jumpCount - 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && availavbleJumps > 0)
        {
            rb.AddForce(rb.velocity * -1);
            rb.angularVelocity = 0f;

            rb.velocity = Vector2.up * jumpForce;
            availavbleJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && availavbleJumps == 0 && isGrounded)
        {
            rb.AddForce(rb.velocity * -1);
            rb.angularVelocity = 0f;

            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Update()
    {
        Jump(jumpForce);

        if (DashEnabled) {
            Dash();
        }


        if (FacingRight && Input.GetKeyDown("a"))
        {
            Flip();
            Musket.GetComponent<MusketRotation>().LocalScale.x = -1f;
           

        } else if (!FacingRight && Input.GetKeyDown("d"))
        {
            Flip();
            Musket.GetComponent<MusketRotation>().LocalScale.x = +1f;
           
        }

        pos = main.ScreenToWorldPoint(transform.position);

    }
    
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    /*void Flip()
    {

        if (Input.mousePosition.x < pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.mousePosition.x > pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }*/

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Dash()
    {
        if (isGrounded)
        {
            availavbleDashes = DashCount;
            Invoke("DashLocker", DashCoolDown);
        }

        if ((Input.GetKey("a") || Input.GetKey("left")) && Input.GetKeyDown(KeyCode.LeftShift) && !DashLock && availavbleDashes > 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            DashLock = true;
            Invoke("EndDash", DashTime);

            rb.velocity = new Vector2(0, 0);

            rb.AddForce(Vector2.left * DashImpulse, ForceMode2D.Impulse);

            availavbleDashes--;
        }
        else if ((Input.GetKey("d") || Input.GetKey("right")) && Input.GetKeyDown(KeyCode.LeftShift) && !DashLock && availavbleDashes > 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            DashLock = true;
            Invoke("EndDash", DashTime);

            rb.velocity = new Vector2(0, 0);

            rb.AddForce(Vector2.right * DashImpulse, ForceMode2D.Impulse);

            availavbleDashes--;
        }
    }

    void DashLocker()
    {
        DashLock = false;
    }

    void EndDash()
    {
        rb.constraints = originalConstraints;
    }
}