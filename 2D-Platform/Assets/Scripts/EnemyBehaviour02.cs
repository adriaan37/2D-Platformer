using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour02 : MonoBehaviour
{

     public Animator animator;

    Rigidbody2D rb;
    [SerializeField] float walkSpeed;
    [SerializeField] float stopSpeed;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;
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
        animator.SetFloat("Speed", Mathf.Abs(stopSpeed));
        rb.velocity = Vector2.zero;
    }
}
