using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   
    public  GameObject grave;
    
    
  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.tag == "Player")
      {
        Debug.Log("Triggered");
        StartCoroutine(ShowAndHide(grave, 2.0f)); // 1 second
      }
      
  }
  IEnumerator ShowAndHide( GameObject go, float delay )
  {                                                    
    go.SetActive(true);
    yield return new WaitForSeconds(delay);
    go.SetActive(false);
  }
}
