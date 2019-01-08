using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : ObjectWithPause
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private float distance = 0.7f;
    [SerializeField] Vector3 scale;
    private bool canRotate;
    float rotationSpeed = 10f;


    protected void Start()
    {
        this.canRotate = false;
        interactCaptionText = "Inspecter";
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
        originalScale = gameObject.transform.localScale;
    }

    protected override void Interact()
    {
        base.Interact();
        if (GameManager.Gm.IsPlayerStandingStill())
        {
            GameManager.Gm.isInteractingWithManipulableObject = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().isTrigger = true;
            this.gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward() * distance;
            this.gameObject.transform.localScale = scale;
            if (GameManager.Gm.GetFixRotation())
            {
                transform.LookAt(GameManager.Gm.GetCamera().transform);
            }
            this.canRotate = true;
        }
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.isInteractingWithManipulableObject = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.gameObject.transform.position = originalPosition;
        this.gameObject.transform.rotation = originalRotation;
        this.gameObject.transform.localScale = originalScale;
        this.canRotate = false;
    }


    void OnMouseDrag()
    {
        if (canRotate)
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            // select the axis by which you want to rotate the GameObject
            this.transform.Rotate(Vector3.down, XaxisRotation);
            this.transform.Rotate(Vector3.right, -YaxisRotation);
        }
    }
}
