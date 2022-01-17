using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
    public float MovementSpeed = 10f;
    private float Movement;
    private Rigidbody2D rb;
    public float JumpForce = 1;
    private bool isGrounded;
    public float CheckRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float DashForce;
    public float StartDashTimer;


    float CurrentDashTimer;
    float DashDirection;
    bool isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
     
    }

  
    void Update()
    {
        Movement = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);
        if (isGrounded==true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * JumpForce;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !isGrounded && Movement !=0)
        {
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            rb.velocity = Vector2.zero;
            DashDirection = (int)Movement;
        }

        if (isDashing)
        {
            rb.velocity = transform.right * DashDirection * DashDirection;
            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <-0)
            {
                isDashing = false;
            }
        }
       
    }

    private void FixedUpdate()
    {
          Movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Movement * MovementSpeed, rb.velocity.y);

    }
}
