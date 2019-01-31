using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : StateObject
{
    [SerializeField]bool locked = true;
    [SerializeField] AudioClip slamDoorClip;
    [SerializeField] AudioClip lockedClip;
    [SerializeField] Animator handleAnimator;


    public override void Interact()
    {
        if (!locked)
        {
            base.Interact();
            if (isState2)
            {
                handleAnimator.SetTrigger("handleAnimation");
            }
        }
        else
        {
            this.GetComponent<AudioSource>().PlayOneShot(lockedClip);
            handleAnimator.SetTrigger("handleAnimation");
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
