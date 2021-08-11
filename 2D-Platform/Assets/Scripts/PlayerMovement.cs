using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    float horzMove = 0;
    public float runSpeed= 40;
    bool jump = false;
    
    public Animator animator;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        horzMove = Input.GetAxisRaw("Horizontal")* runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horzMove));
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJump", true);
            
        }
        
 
    }

    public void OnLanding()
    {
        animator.SetBool("isJump", false);
        
    }

    void FixedUpdate()
    {
        controller.Move(horzMove * Time.fixedDeltaTime,false,jump);
        jump = false;    

    }

    
}
