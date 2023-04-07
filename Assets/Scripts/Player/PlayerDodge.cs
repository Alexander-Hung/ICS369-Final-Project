using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;

    public float dodgeForce;
    public float dodgeUpwardForce;
    public float dodgeDuration;

    public float coolDown;
    private float dodgeCDTimer;

    public KeyCode dodgeKey = KeyCode.C;

    //public bool useCameraForward = true;
    public bool allowAllDirections = true;
    public bool disableGravity = false;
    public bool resetVel = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(dodgeKey))
        {
            Dodge();
        }

        if(dodgeCDTimer > 0)
            dodgeCDTimer -= Time.deltaTime;
    }

    private void Dodge()
    {
        if (dodgeCDTimer > 0) return;
        else dodgeCDTimer = coolDown;

        Transform forwardT;

        //if (useCameraForward)
        //    forwardT = playerCam;
        //else
            forwardT = orientation;

        Vector3 direction = GetDirection(forwardT);

        Vector3 forceToApply = direction * dodgeForce + orientation.up * dodgeUpwardForce;

        if(disableGravity)
        {
            rb.useGravity = false;
        }

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDodgeForce), 0.025f);

        Invoke(nameof(ResetDodge), dodgeDuration);
    }

    private Vector3 delayedForceToApply;

    private void DelayedDodgeForce()
    {
        if(resetVel)
            rb.velocity = Vector3.zero;

        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDodge()
    {
        if(disableGravity)
            rb.useGravity = true;
    }

    private Vector3 GetDirection(Transform forwardT)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3();

        if(allowAllDirections)
        {
            direction = forwardT.forward * verticalInput + forwardT.right * horizontalInput;
        }
        else
        {
            direction = forwardT.forward;
        }

        if(verticalInput == 0 && horizontalInput == 0)
        {
            direction = forwardT.forward;
        }

        return direction.normalized;
    }
}
