using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject FirstPersonCam;
    public GameObject ThirdPersonCam;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPersonCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (FirstPersonCam.activeSelf)
            {
                FirstPersonCam.SetActive(false);
                ThirdPersonCam.SetActive(true);
            }
            else
            {
                FirstPersonCam.SetActive(true);
                ThirdPersonCam.SetActive(false);
            }
        }
    }
}
