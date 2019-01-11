using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ObjectWithPause
{
    protected void Start()
    {
        interactCaptionText = "Inspecter";
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Interact()
    {
        base.Interact();
        UIManager.instance.ShowUIAntoine();
        GameManager.Gm.isInteractingWithComputer = true;
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        UIManager.instance.HideUIAntoine();
        GameManager.Gm.isInteractingWithComputer = false;
    }
}
