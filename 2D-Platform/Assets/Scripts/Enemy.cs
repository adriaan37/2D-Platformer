using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public Animator animator;

    public int maxHealth = 10;
    public int currentHealth = 1;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Dies");
        animator.SetBool("isDead", true);

        Destroy(gameObject,2f);
        
    }
    

}
