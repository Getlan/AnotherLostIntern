using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Phone : Observable
{
    private bool activated = false;
    private AudioSource audioSource;

    [SerializeField] private GameObject redLight;

    [SerializeField] AudioClip[] mumDialogClips;
    [SerializeField] string[] mumDialogLines;

    protected override void Start()
    {
        base.Start();
        interactCaptionText = "Decrocher";
        audioSource = this.GetComponent<AudioSource>();
    }


    public override void Interact()
    {
        base.Interact();
        if (!activated)
        {
            AudioManager.instance.Stop("PhoneRingtone");
            StepManager.instance.PlayMumDialog(mumDialogClips, mumDialogLines, audioSource);
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
        yield return new WaitForSeconds(26f);
        StopInteract();
        activated = true;
        redLight.SetActive(false);
    }
}
