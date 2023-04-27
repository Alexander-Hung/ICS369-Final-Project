using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public List<GameObject> Image;

    private float elapsedTime;

    public void Play()
    {
        foreach (var item in Image)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 1f)
            {
                elapsedTime = 0f;
                item.gameObject.SetActive(true);
            }
        }


        StartCoroutine(SceneLoader.instance.LoadLevel("MainScene"));
    }

}
