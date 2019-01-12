using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ObjectWithPause : NoStateObject
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Gm.canMove = false;
        GameManager.Gm.canRotate = false;
        GameManager.Gm.cursorIsLocked = false;
        GameManager.Gm.DeactivateCursorIcon();
    }

    public override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.canMove = true;
        GameManager.Gm.canRotate = true;
        GameManager.Gm.cursorIsLocked = true;
        GameManager.Gm.ActivateCursorIcon();
    }
}
