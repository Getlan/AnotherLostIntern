using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ObjectWithPause : NoStateObject
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Gm.CanMove = false;
        GameManager.Gm.CanRotate = false;
        GameManager.Gm.CursorIsLocked = false;
        GameManager.Gm.DeactivateCursorIcon();
    }

    public override void StopInteract()
    {
        base.StopInteract();
        GameManager.Gm.CanMove = true;
        GameManager.Gm.CanRotate = true;
        GameManager.Gm.CursorIsLocked = true;
        GameManager.Gm.ActivateCursorIcon();
    }
}
