using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : NoStateObject
{

    [SerializeField] float scaleMultiplier;
    [SerializeField] GameObject zone;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    private float distance = 0.7f;
    private bool isInZone = false;


    protected void Start()
    {
        interactCaptionText = "Prendre";
        originalParent = this.transform.parent.gameObject.transform;
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
    }

    public override void Interact()
    {
        base.Interact();
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        this.gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward() * distance;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale * scaleMultiplier;
        this.transform.position = GameManager.Gm.GetHoldPosition().position;
        this.transform.parent = GameManager.Gm.GetCamera().transform;
        this.transform.LookAt(GameManager.Gm.GetCamera().transform);
    }

    public override void StopInteract()
    {
        base.StopInteract();
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale / scaleMultiplier;
        this.transform.parent = originalParent;
        if (isInZone)
        {
            this.gameObject.transform.position = originalPosition;
            this.gameObject.transform.rotation = originalRotation;
        }
    }

    public override void ClickWhileInteracting()
    {
        StopInteract();
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

