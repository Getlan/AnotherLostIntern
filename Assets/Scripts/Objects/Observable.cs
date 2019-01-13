using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : ObjectWithPause
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float distance = 0.7f;
    [SerializeField] float scaleMultiplier;
    private bool canRotate;
    float rotationSpeed = 10f;


    protected void Start()
    {
        this.canRotate = false;
        interactCaptionText = "Inspecter";
    }


    public override void Interact()
    {
        base.Interact();
        if (GameManager.Gm.IsPlayerStandingStill())
        {
            originalPosition = gameObject.transform.position;
            originalRotation = gameObject.transform.rotation;
            GameManager.Gm.IsInteractingWithManipulableObject = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().isTrigger = true;
            this.gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward() * distance;
            this.gameObject.transform.localScale = this.gameObject.transform.localScale* scaleMultiplier;
            if (GameManager.Gm.FixRotation)
            {
                transform.LookAt(GameManager.Gm.PlayerCamera.transform);
            }
            this.canRotate = true;
        }
    }

    public override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.IsInteractingWithManipulableObject = false;
        this.gameObject.transform.position = originalPosition;
        this.gameObject.transform.rotation = originalRotation;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale/scaleMultiplier;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.canRotate = false;
    }

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.transform == null || hit.transform.gameObject != this.gameObject)
            {
                StopInteract();
            }
        }
        else
        {
            StopInteract();
        }
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
