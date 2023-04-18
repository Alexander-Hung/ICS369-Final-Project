using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Canvas canvas;

    public Transform enemyPosition;
    public Vector3 offset;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // get the current active camera
        cam = Camera.main;
        canvas = GameObject.Find("HealthBarCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the camera was changed, update camera
        if (SwitchCam.cameraSwitched)
        {
            cam = Camera.main;
            SwitchCam.cameraSwitched = false;
        }

        // get the enemy position and translate to screen coords
        Vector3 worldPos = enemyPosition.TransformPoint(offset);
        Debug.Log(worldPos);

        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);

        if (transform.position != screenPos)
        {
            transform.position = screenPos;
        }
    }
}
