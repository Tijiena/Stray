using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");

       bool forwardPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");
       bool runPressed = Input.GetKey("left shift");

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

    }
}
