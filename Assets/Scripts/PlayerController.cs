using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public PlayerAnimationController controller;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jumping();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            controller.Attacking();
        }
        MovePlayerRelativeToCamera();
    }

    void MovePlayerRelativeToCamera()
    {
        //Get player input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        //Get camera directions
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //Make a direction relative to input
        Vector3 forwardRelativeVerticleInput = playerVerticalInput * forward;
        Vector3 rightRelativeHorizontalInput = playerHorizontalInput * right;

        //Create the movement and apply
        Vector3 cameraRelativeMovement = forwardRelativeVerticleInput + rightRelativeHorizontalInput;
        if(cameraRelativeMovement == Vector3.zero)
        {
            controller.StopMoving();
            return;
        }

        controller.Walking();
        this.transform.Translate(cameraRelativeMovement, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(cameraRelativeMovement);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * 40);
    }
}
