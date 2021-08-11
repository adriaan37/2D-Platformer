using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private enum State
     {
         Walking,
         Attack,
         Hurt,
         Dead

     }
    private State currentState;
    private GameObject alive;
    private Rigidbody2D aliveRb;
    private Animator animator;

    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private float wallCheckDistance;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private Transform groundcheck;
    
    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private LayerMask whatisGround;

    private int facingDirection;
    private float currentHealth;
    private int damageDirection;
  

    private Vector2 movement;

    private bool groundDetected;
    private bool wallDetected;

    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        animator = alive.GetComponent<Animator>();
        facingDirection = 1;
    }
    private void Update()
    {
        switch(currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Attack:
                UpdateAttackState();
                break;
            case State.Hurt:
                UpdateHurtState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    private void EnterWalkingState()
    {
         //animator.SetFloat("Speed", Mathf.Abs(horzMove));
    }
     private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundcheck.position,Vector2.down,groundCheckDistance,whatisGround);
        wallDetected = Physics2D.Raycast(wallCheck.position,transform.right,wallCheckDistance,whatisGround);
        if(!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed*facingDirection,aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }

    private void ExitWalkingState()
    {

    }

    
    private void EnterAttackState()
    {
        animator.SetTrigger("isAttack");
    }

    private void UpdateAttackState()
    {

    }

    private void ExitAttackState()
    {
        
    }

    
    private void EnterHurtState()
    {
        animator.SetTrigger("Hurt");
    }

    private void UpdateHurtState()
    {
        
    }

    private void ExitHurtState()
    {
        
    }
    
    private void EnterDeadState()
    {
        animator.SetBool("isDead",true);
        Destroy(gameObject);
    }
    private void UpdateDeadState()
    {
        
    }

    private void ExitDeadState()
    {
       
    }

    private void Damage(float attackDetails)
    {
             //Hit particle

        if(currentHealth < 0.0f)
        {
            SwitchState(State.Hurt);

        }
        else if (currentHealth <= 0.0f)
        {
            SwitchState(State.Dead);
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f,180.0f,0.0f);
    }
    private void SwitchState(State state)
    {
        switch(currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Attack:
                ExitAttackState();
                break;           
            case State.Hurt:
                ExitHurtState();
                break;        
            case State.Dead:
                ExitDeadState();
                break;
        }
     switch(state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Attack:
                EnterAttackState();
                break;           
            case State.Hurt:
                EnterHurtState();
                break;        
            case State.Dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(groundcheck.position, new Vector2(groundcheck.position.x,groundcheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position,new Vector2(wallCheck.position.x + wallCheckDistance,wallCheck.position.y));
    }
}
