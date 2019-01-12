using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ObjectWithPause
{
    protected void Start()
    {
        interactCaptionText = "Utiliser";
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

    public void ShowNewsAntoine()
    {
        UIManager.instance.ShowNewsAntoine();
    }

    public void ShowMailsAntoine()
    {
        UIManager.instance.ShowMailsAntoine();
    }

    public override void ClickWhileInteracting()
    {
    }
}
