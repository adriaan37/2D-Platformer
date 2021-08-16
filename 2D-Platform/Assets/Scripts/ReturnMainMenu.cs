using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public string levelname;
   public void ReturnMenu()
   {    
       SceneManager.LoadScene("StartScreen");
   }

   public void ReturnLevelSelector(string levelname)
       {
           
           SceneManager.LoadScene(levelname);
       }
   
}
