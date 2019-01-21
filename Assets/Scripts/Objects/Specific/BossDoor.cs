using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : StateObject
{
    [SerializeField]bool locked = true;
    [SerializeField] AudioClip slamDoorClip;

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
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().PlayOneShot(slamDoorClip);
    }
}
