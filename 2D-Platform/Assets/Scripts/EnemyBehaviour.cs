using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPatrol;
    Rigidbody2D rb;
    public Collider2D bodycollider;
    private bool mustTurn;
    public Transform groundCheckpos;
    public LayerMask groundLayer;
    public Animator animator;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;
    

    // void Start()
    // {
    //     mustPatrol = true;
    //     rb = GetComponent<Rigidbody2D>();
        

    // }

    // void Update()
    // {
    //     if (mustPatrol)
    //     {
    //         Patrol();
            
    //     }

    // }
    //  void FixedUpdate()
    // {
    //     if (mustPatrol)
    //     {
    //         mustTurn = !Physics2D.OverlapCircle(groundCheckpos.position, 0.1f, groundLayer);
    //     }
    // }
    // void Patrol(){
        
    //     if (mustTurn || bodycollider.IsTouchingLayers(groundLayer))
    //     {
    //         Flip();
    //     }
    //     rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    //     animator.SetFloat("Speed",Mathf.Abs(walkSpeed));
        
    // }
   
    // void Flip()
    // {
    //     mustPatrol = false;
    //     transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
       
    //     walkSpeed *= -1;
    //     mustPatrol = true;
        
    // }

    void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    void Update() {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
            
        }else{

            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {   
        animator.SetFloat("Speed",Mathf.Abs(walkSpeed));
            if(transform.position.x < player.position.x)
            {
                rb.velocity = new Vector2(walkSpeed,0);
                transform.localScale = new Vector2(0.135049f,0.1411495f);
            }
            else if(transform.position.x > player.position.x)
            {
                rb.velocity = new Vector2(-walkSpeed,0);
                transform.localScale = new Vector2(-0.135049f,0.1411495f);
                
            }

    }

    private void StopChasingPlayer()
    {
        animator.SetFloat("Speed",Mathf.Abs(walkSpeed));
        rb.velocity = Vector2.zero;
    }
}


