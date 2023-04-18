using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        StartCoroutine(SceneLoader.instance.LoadLevel("Scene2"));
    }

}
