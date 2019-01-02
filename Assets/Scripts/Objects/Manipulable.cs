using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulable : Interactible {

    private Vector3 originalPosition;
    [SerializeField] float distance;
    [SerializeField] Vector3 fixedRotation;

    protected override void Update()
    {
        base.Update();
    }

    protected void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    protected override void Interact()
    {
        base.Interact();
        GameManager.Gm.isInteractingWithManipulableObject = true;
        gameObject.transform.position = GameManager.Gm.GetCameraPosition() + GameManager.Gm.GetCameraForward()* distance;
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.isInteractingWithManipulableObject = false;
        gameObject.transform.position = originalPosition;
    }
}
