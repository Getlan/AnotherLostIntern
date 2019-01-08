using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer1 : ObjectWithPause1
{

    [SerializeField]
    private GameObject UIComputer;

    protected override void Update()
    {
        base.Update();
    }

    protected override void Interact()
    {
        base.Interact();
        UIComputer.SetActive(true);
        GameManager.Gm.isInteractingWithComputer = true;
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        UIComputer.SetActive(false);
        GameManager.Gm.isInteractingWithComputer = false;
    }
}
