using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : NoStateObject
{
    public void Start()
    {
        interactCaptionText = "Ecouter le message";
    }


    public override void Interact()
    {
        base.Interact();
        AudioManager.instance.Play("Phone");
        StopInteract();
    }

    public override void ClickWhileInteracting()
    {
    }
}
