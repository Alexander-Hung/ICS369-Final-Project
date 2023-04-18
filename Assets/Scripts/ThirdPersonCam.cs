using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public Transform aim;

    public GameObject thirdPersonCam;
    public GameObject topDownCam;

    public float rotationSpeed;

    public CameraStyle currStyle;

    public enum CameraStyle
    {
        Combat,
        Topdown
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;

        topDownCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6) && thirdPersonCam.activeSelf)
        {
            thirdPersonCam.SetActive(false);
            topDownCam.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.F6) && topDownCam.activeSelf)
        {
            thirdPersonCam.SetActive(true);
            topDownCam.SetActive(false);
        }

        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //Vector3 inputDir = -orientation.forward * verticalInput + -orientation.right * horizontalInput;

        //if (inputDir != Vector3.zero)
        //{
        //    playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        //}

        Vector3 viewDirAim = aim.position - new Vector3(transform.position.x, aim.position.y, transform.position.z);
        orientation.forward = viewDirAim.normalized;

        playerObj.forward = -viewDirAim.normalized;
    }
}
