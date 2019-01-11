using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ObjectWithPause : NoStateObject
{

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
        GameManager.Gm.canMove = false;
        GameManager.Gm.canRotate = false;
        GameManager.Gm.cursorIsLocked = false;
        GameManager.Gm.DeactivateCursorIcon();
    }

    protected override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.canMove = true;
        GameManager.Gm.canRotate = true;
        GameManager.Gm.cursorIsLocked = true;
        GameManager.Gm.ActivateCursorIcon();
    }
}
