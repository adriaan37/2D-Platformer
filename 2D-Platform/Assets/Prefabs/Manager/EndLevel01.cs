using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel01 : MonoBehaviour
{
    // [SerializeField] private string nextLevel;

    SceneLoader nextscene;
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D other) 
    {   
          if(other.tag == "Player")
          {
            SceneManager.LoadScene(nextLevel);
          }
    
          
    }
 
    
}
