using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : StateObject
{
    bool locked = true;

    public override void Interact()
    {
        if (!locked)
        {
            base.Interact();
        }
        base.Interact();
    }

    public void UnlockDoor()
    {
        locked = false;
    }

    public void SlamDoor()
    {
        this.Interact();
        //[AUDIO]Play slam door sound
        locked = true;
    }
}
