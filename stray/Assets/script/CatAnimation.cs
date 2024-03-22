using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    Animator animator;
    private CatController catController;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
         catController = GetComponent<CatController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isJumping = animator.GetBool("isJumping");
        bool isGrounded = catController.grounded;
        float jumpTimer = 0f;
        float jumpCd = 0.5f;

       bool forwardPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");
       bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

       if(!isWalking && forwardPressed){
        animator.SetBool("isWalking",true);
       }

       if(isWalking && !forwardPressed){
        animator.SetBool("isWalking",false);
       }

       if(!isrunning && (forwardPressed && runPressed)){
        animator.SetBool("isRunning", true);
       }

       if(isrunning && (!forwardPressed || !runPressed)){
        animator.SetBool("isRunning", false);
       }
        if (!isJumping && jumpPressed && isGrounded && jumpTimer <= 0)
        {
            animator.SetBool("isJumping", true);
            isGrounded = false;
            jumpTimer = jumpCd;
        }

        if (!isGrounded && isJumping)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0)
            {
                animator.SetBool("isJumping", false);
            }
        }
     isGrounded = catController.grounded;
        animator.SetBool("isGrounded", isGrounded);

    }
}
