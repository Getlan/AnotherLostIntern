using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Phone : Observable
{
    private bool activated = false;
    private AudioSource audioSource;

    [SerializeField] AudioClip[] mumDialogClips;
    [SerializeField] string[] mumDialogLines;

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
            StartCoroutine(PlayVoice());
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
        while (this.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        StopInteract();
        activated = true;
    }

    IEnumerator PlayVoice()
    {
        for(int i = 0; i < mumDialogClips.Length; i++)
        {
            UIManager.instance.PrintSubtitles(mumDialogLines[i]);
            audioSource.PlayOneShot(mumDialogClips[i]);
            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }
        UIManager.instance.PrintSubtitles("");
    }
}
