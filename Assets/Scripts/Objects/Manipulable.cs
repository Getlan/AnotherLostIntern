using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulable : Interactible {

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    [SerializeField] float distance;
    private bool canRotate;

    private float sensitivity;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;
    private bool isRotating;

    //Max and min vertical rotation values
    [SerializeField] private float minimumX = -45f;
    [SerializeField] private float maximumX = 90f;

    protected void Start()
    {
        sensitivity = 1f;
        rotation = Vector3.zero;
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
        this.canRotate = false;
        isRotating = false;
    }

    protected override void Update()
    {
        base.Update();
        if (canRotate && Input.GetMouseButtonUp(0))
        {
            // rotating flag
            this.isRotating = false;
        }
        else if (canRotate && Input.GetMouseButtonDown(0))
        {
            // rotating flag
            this.isRotating = true;

            // store mouse
            this.mouseReference = Input.mousePosition;
        }
        if (isRotating)
        {
            RotateObject();
        }
    }

    protected override void Interact()
    {
        if (GameManager.Gm.IsPlayerStandingStill())
        {
            base.Interact();
            GameManager.Gm.isInteractingWithManipulableObject = true;
            this.gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward() * distance;
            if (GameManager.Gm.GetFixRotation())
            {
                transform.LookAt(GameManager.Gm.GetCamera().transform);
            }
            GameManager.Gm.cursorIsLocked = false;
            this.canRotate = true;
        }
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.isInteractingWithManipulableObject = false;
        this.gameObject.transform.position = originalPosition;
        this.gameObject.transform.rotation = originalRotation;
        GameManager.Gm.cursorIsLocked = true;
        this.canRotate = false;
    }

    void RotateObject()
    {
        // offset
        mouseOffset = (Input.mousePosition - mouseReference);
        // apply rotation
        rotation.y = -(mouseOffset.x) * sensitivity;
        rotation.x = -(mouseOffset.y) * sensitivity;
        Debug.Log(rotation.y);
        // rotate
        this.transform.eulerAngles += rotation;
        // store mouse
        mouseReference = Input.mousePosition;
    }
}
