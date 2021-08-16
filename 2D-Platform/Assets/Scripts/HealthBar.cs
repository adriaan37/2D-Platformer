using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public int health;
    public int numofhearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator animator;
    public AudioSource hurtSound;

void Update()
{
        if(health > numofhearts){
            health = numofhearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i <health)
            {
                hearts[i].sprite = fullHeart;
            }else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numofhearts)
            {
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }

        }
}
void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(health > 0)
            {
               health-= 1;
                animator.SetTrigger("Hurt");
                hurtSound.Play(); 
            }
            else if( health <= 0)
            {
                hurtSound.Play();
                SceneManager.LoadScene("GameOver");
            }
            
        }
        if(other.gameObject.tag == "HealthUp")
        {
            if(health == numofhearts)
            {
                numofhearts = numofhearts+1;
                Destroy(other.gameObject);
            }
            if(health < numofhearts)
            {
                health+=1;
                Destroy(other.gameObject);
            
            }
        }
    }

    
 
}
