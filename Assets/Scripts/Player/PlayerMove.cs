using System;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CapsuleCollider))]

public class PlayerMove : MonoBehaviour
{

    //Movement variables
    [SerializeField]
    private float forwardSpeed; //speed when walking forward
    [SerializeField]
    private float backwardSpeed; //speed when walking backwards
    [SerializeField]
    private float strafeSpeed;  //speed when walking sideways
    [SerializeField]
    private float runMultiplier; //speed when sprinting
    [SerializeField]
    private float drag = 5f;
    [HideInInspector]
    private float targetSpeed; 

    //Other variables
    public Camera cam;
    public KeyCode runKey = KeyCode.LeftShift;
    public MouseLook mouseLook = new MouseLook();
    private Rigidbody playerBody;
    private float yRotation;
    private bool isRunning;

    private float stepCycle;
    private float nextStep;
    [SerializeField] private float stepInterval;
    [SerializeField] [Range(0f, 1f)] private float runstepLenghten;
    private bool leftFoot = true;

    public Vector3 Velocity
    {
        get { return playerBody.velocity; }
    }

    public bool Running
    {
        get { return isRunning; }
    }

    public bool canMove
    {
        get { return GameManager.Gm.canMove; }
    }

    public bool canRotate
    {
        get { return GameManager.Gm.canRotate; }
    }

    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        mouseLook.Init (transform, cam.transform);
        targetSpeed = forwardSpeed;
        playerBody.drag = drag;
    }

    private void Update()
    {
        if (canRotate)
        {
            //Rotate the play depending on the camera's aim
            RotateView();
        }
        mouseLook.UpdateLockCursor();
    }

    private void FixedUpdate()
    {
        //Handle player's inputs
        Vector2 input = HandleInputs();

        //If the player wants to move
        if (canMove && (Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon))
        {
            //Compute the desired move based on the inputs and the target speed
            Vector3 desiredMove = cam.transform.forward*input.y + cam.transform.right*input.x; //Always move along the camera forward as it is the direction that it being aimed at
            desiredMove = Vector3.ProjectOnPlane(desiredMove, Vector3.zero).normalized;

            desiredMove.x = desiredMove.x*targetSpeed;
            desiredMove.z = desiredMove.z*targetSpeed;
            desiredMove.y = desiredMove.y*targetSpeed;

            //If the player's speed is below the target speed, move the player
            if (playerBody.velocity.sqrMagnitude <(targetSpeed*targetSpeed))
            {
                playerBody.AddForce(desiredMove, ForceMode.Impulse);
            }
        }

        //If the rigidbody is not moving, put it to sleep (cease calculations)
        if (Mathf.Abs(input.x) < float.Epsilon && Mathf.Abs(input.y) < float.Epsilon && playerBody.velocity.magnitude < 1f)
        {
            playerBody.Sleep();
        }

        ProgressStepCycle(targetSpeed);
    }

    //Handle inputs
    private Vector2 HandleInputs()
    {
            
        Vector2 input = new Vector2
            {
                x = Input.GetAxis("Horizontal"),
                y = Input.GetAxis("Vertical")
            };
		ComputePlayerSpeed(input);
        return input;
    }

    //Compute the player's speed depending on the inputs
    private void ComputePlayerSpeed(Vector2 input)
    {
        //If no input, then exit
        if (input == Vector2.zero) return;

        //If the player is going sideways
        if (input.x > 0 || input.x < 0)
        {
            targetSpeed = strafeSpeed;
        }

        //If the player is going backwards
        if (input.y < 0)
        {
            targetSpeed = backwardSpeed;
        }

        //If the player is going forward
        if (input.y > 0)
        {
            targetSpeed = forwardSpeed;
        }

        //If the player is running
        if (Input.GetKey(runKey))
        {
            targetSpeed *= runMultiplier;
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    //Rotate the rigidbody depending on the camera's aim
    private void RotateView()
    {
        //Avoid the mouse looking if the game is effectively paused
        if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

        //Get the rotation before it's changed
        float oldYRotation = transform.eulerAngles.y;

        mouseLook.LookRotation(transform, cam.transform);

        //Rotate the rigidbody velocity to match the new direction that the character is looking
        Quaternion velRotation = Quaternion.AngleAxis(transform.eulerAngles.y - oldYRotation, Vector3.up);
        playerBody.velocity = velRotation * playerBody.velocity;
    }

    private void ProgressStepCycle(float speed)
    {
        if (playerBody.velocity.sqrMagnitude > 0)
        {
            stepCycle += (playerBody.velocity.magnitude + (speed * (isRunning ? runstepLenghten : 1f))) *
                             Time.fixedDeltaTime;
        }

        if (!(stepCycle > nextStep))
        {
            return;
        }

        nextStep = stepCycle + stepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (leftFoot)
        {
            AudioManager.instance.Play("LeftFoot");
        }
        else
        {
            AudioManager.instance.Play("RightFoot");
        }
        leftFoot = !leftFoot;
    }
}
