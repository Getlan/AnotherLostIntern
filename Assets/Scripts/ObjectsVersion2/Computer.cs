using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ObjectWithPause
{
    protected void Start()
    {
        interactCaptionText = "Inspecter";
    }

    public override void Interact()
    {
        base.Interact();
        UIManager.instance.ShowUIAntoine();
        GameManager.Gm.isInteractingWithComputer = true;
    }

    public override void StopInteract()
    {
        base.StopInteract();
        UIManager.instance.HideUIAntoine();
        GameManager.Gm.isInteractingWithComputer = false;
    }

    public override void ClickWhileInteracting()
    {
        StopInteract();
    }
}
