using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {

        public Animator animator;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {   
                animator.SetTrigger("Hurt");
                animator.SetBool("isDead", true);
                Invoke("RestartScene",2);
            }
        }
     

    private void RestartScene()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    }
}
