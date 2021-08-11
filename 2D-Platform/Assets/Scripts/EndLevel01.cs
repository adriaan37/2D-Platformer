using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel01 : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    private void OnTriggerEnter2D(Collider2D other) 
    {
          if(other.CompareTag("Player"))
          {
              
            SceneManager.LoadScene(nextLevel);
          }
    
          
    }
 
    
}
