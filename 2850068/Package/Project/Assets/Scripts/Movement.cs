using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;// character controller
    public Transform camera;
    public float speed = 10; // player movement speed
    public float turnSmoothing = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -10f;
    public Transform groundCheck;
    public float groundDistance = 0.0f; //0.4f
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 4f;

    Animator animator;
    //

    public static bool CCswitcher = false;
    
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y <0)
        {
            //animator.SetBool("isJumping", false);
            velocity.y = -2f;
            Debug.Log("ISGROUNDED");
        }
        float horizontal = Input.GetAxisRaw("Horizontal"); // horizontal input [raw for no smoothing]
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // normalized so that the speed is nornmalized. if not here hold down 2 keys and go faster 
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
           // animator.SetBool("isJumping", true);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;// atan 2 mathematical function that returns the angle between the x axis and the vector starting at zero and terminating at x,y
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
            //animator.SetBool("isWalking", true);
        }
        if (direction.magnitude ==0f)
        {
            //animator.SetBool("isWalking", false);
        }
       

    }


    
    
}
