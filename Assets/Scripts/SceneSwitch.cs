using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1"))
        {
            SceneManager.LoadScene(1);
        }

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene2"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
