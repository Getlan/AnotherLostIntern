using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactive
{
    public void Start()
    {
        interactCaptionText = "Réécouter";
    }


    public override void Interact()
    {
        base.Interact();
        AudioManager.instance.Play("Phone");
        StopInteract();
    }
}
