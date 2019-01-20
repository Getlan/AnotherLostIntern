using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Observable
{
    private bool activated = false;
    private AudioSource audioSource;
    [SerializeField] AudioClip MumDialogClip;

    protected override void Start()
    {
        base.Start();
        interactCaptionText = "Decrocher";
        audioSource=this.GetComponent<AudioSource>();
    }


    public override void Interact()
    {
        base.Interact();
        if (!activated)
        {
            AudioManager.instance.Stop("PhoneRingtone");
            audioSource.PlayOneShot(MumDialogClip);
            StartCoroutine(WaitForSoundToFinish());
        }
    }

    public override void ClickWhileInteracting()
    {
        if (activated)
        {
            base.ClickWhileInteracting();
        }
    }

    IEnumerator WaitForSoundToFinish()
    {
        //Wait Until Sound has finished playing
        while (this.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        StopInteract();
        activated = true;
    }
}
