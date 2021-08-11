using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01 : MonoBehaviour
{
    private void OnEnable() {
        SceneManager.LoadScene("Level01",LoadSceneMode.Single);
    }
}

