using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : NoStateObject
{
    public void Start()
    {
        interactCaptionText = "Décrocher";
    }


    public override void Interact()
    {
        base.Interact();
        this.GetComponent<AudioSource>().Play();
        StopInteract();
    }

    public override void ClickWhileInteracting()
    {
    }
}
