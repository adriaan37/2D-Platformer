using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public AudioSource attackSound;
    Enemy enemy;
    public Transform Attackpoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private float attackDetails;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetButtonDown("Attack"))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f/attackRate;
                }
        }

        
    }

    void Attack()
    {
        animator.SetTrigger("isAttack");
        attackSound.Play();

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(Attackpoint.position,AttackRange,enemyLayers);
        attackDetails = attackDamage;
        
        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

        void OnDrawGizmosSelected() {

            if(Attackpoint == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(Attackpoint.position,AttackRange);
        }
            
     
    
}
