using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Observable
{
    private bool activated = false;
    public AudioSource phoneRingtone; 

    protected override void Start()
    {
        base.Start();
        interactCaptionText = "Décrocher";
    }


    public override void Interact()
    {
        base.Interact();
        if (!activated)
        {
            phoneRingtone.Stop();
            this.GetComponent<AudioSource>().Play();
            activated = true;
            StartCoroutine(WaitForSoundToFinish());
        }
    }

    public override void ClickWhileInteracting()
    {
    }

    IEnumerator WaitForSoundToFinish()
    {
        //Wait Until Sound has finished playing
        while (this.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        StopInteract();
    }
}
