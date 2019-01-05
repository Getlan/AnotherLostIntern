using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithPause : Interactive
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (base.isInteracting && Input.GetMouseButtonDown(1))
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
