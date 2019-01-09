using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : NoStateObject
{

    [SerializeField] Vector3 scale;
    [SerializeField] GameObject zone;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    private Vector3 originalScale;
    private float distance = 0.7f;
    private bool isInZone = false;


    protected void Start()
    {
        interactCaptionText = "Prendre";
        originalParent = this.transform.parent.gameObject.transform;
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
        originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isLooking && !isInteracting && Input.GetKeyDown("space"))
        {
            Interact();
        }
        else if (isInteracting && Input.GetKeyDown("space"))
        {
            StopInteract();
        }
    }

    protected override void Interact()
    {
        base.Interact();
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        this.gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward() * distance;
        this.gameObject.transform.localScale = scale;
        this.transform.position = GameManager.Gm.GetHoldPosition().position;
        this.transform.parent = GameManager.Gm.GetCamera().transform;
        this.transform.LookAt(GameManager.Gm.GetCamera().transform);
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.gameObject.transform.localScale = originalScale;
        this.transform.parent = originalParent;
        if (isInZone)
        {
            this.gameObject.transform.position = originalPosition;
            this.gameObject.transform.rotation = originalRotation;
        }
    }

    void OnTriggerEnter(Collider obj)
    { 
        if(obj.gameObject == zone)
        {
            isInZone = true;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject == zone)
        {
            isInZone = false;
        }
    }
}
