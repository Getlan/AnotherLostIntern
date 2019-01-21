using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : StateObject
{
    [SerializeField]bool locked = true;

    public override void Interact()
    {
        if (!locked)
        {
            base.Interact();
        }
    }

    public void UnlockDoor()
    {
        locked = false;
    }

    public void SlamDoor()
    {
        this.Interact();
        locked = true;
    }
}
