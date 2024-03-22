using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

 

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Animation")]
    public Animator catAnim;
    

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
       //idle
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        
    }

    private void Update()
    {
    

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        MyInput();
        SpeedControl();

     
       
 switch (state)
        {
            case MovementState.walking:
           
            
                break;
            case MovementState.sprinting:
                
                break;
            default:
          
              
                break;
        }

         if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }
       else if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        else if (grounded)
        {
           
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
       
    }

    private void MovePlayer()
    {
       
        moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;
        Vector3 targetVelocity = moveDirection * moveSpeed;

     // Calculate the velocity change needed
        Vector3 velocityChange = targetVelocity - rb.velocity;

        // Apply the velocity change to the Rigidbody
        velocityChange.y = 0; // Ensure vertical velocity remains unchanged
      rb.AddForce(velocityChange, ForceMode.VelocityChange);
 
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }


     private void SpeedControl()
  {
      Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


 if(flatVel.magnitude > moveSpeed)
      {
          Vector3 limitedVel = flatVel* moveSpeed;
          rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
      }
}

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}