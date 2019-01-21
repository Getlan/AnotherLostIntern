using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portable : Observable
{
    private bool activated = false;
    
    public override void Interact()
    {
        base.Interact();
        if(!activated)
        {
            StepManager.instance.End();
            StartCoroutine(CannotInteract()); 
        }

    }

    public override void ClickWhileInteracting()
    {
        if (activated)
        {
            base.ClickWhileInteracting();
        }
    }

    IEnumerator CannotInteract()
    {
        while(AudioManager.instance.sources[0].isPlaying && AudioManager.instance.sources[1].isPlaying && AudioManager.instance.sources[2].isPlaying && AudioManager.instance.sources[3].isPlaying)
        {
            yield return null; 
        }
        StopInteract();
        activated = true; 

    }
}
