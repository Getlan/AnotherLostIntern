using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Phone : Observable
{
    private bool activated = false;
    private AudioSource audioSource;
    /*[SerializeField] AudioClip MumDialogClip_1;
    [SerializeField] AudioClip MumDialogClip_2;
    [SerializeField] AudioClip MumDialogClip_3;
    [SerializeField] AudioClip MumDialogClip_4;
    [SerializeField] AudioClip MumDialogClip_5;
    [SerializeField] AudioClip MumDialogClip_6;
    [SerializeField] AudioClip MumDialogClip_7;
    [SerializeField] AudioClip MumDialogClip_8;*/

    [SerializeField] AudioClip[] MumDialogClips;
    public Text subtitles;
    public GameObject subtitles_canvas;

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
            //audioSource.PlayOneShot(MumDialogClip);
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
        //Wait Until Sound has finished playing
        while (this.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        StopInteract();
        activated = true;
    }

    IEnumerator PlayVoice()
    {
        subtitles_canvas.SetActive(true);
        audioSource.PlayOneShot(MumDialogClips[0]);

        while(audioSource.isPlaying)
        {
            subtitles.text = "Oui bonsoir je suis la mère d'Antoine.";
            yield return null; 
        }

        audioSource.PlayOneShot(MumDialogClips[1]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Désolée de vous déranger j'arrive pas à le joindre.";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[2]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Il devrait être rentré depuis longtemps heu... (soupir)";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[3]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Je me demandais s'il était encore au travail.";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[4]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Allô ?";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[5]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Allô ?";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[6]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Vous m'entendez ?";
            yield return null;
        }

        audioSource.PlayOneShot(MumDialogClips[7]);

        while (audioSource.isPlaying)
        {
            subtitles.text = "Bon s'il est là dites-lui de me rappeler et que je m'inquiète, merci.";
            yield return null;
        }

        subtitles_canvas.SetActive(false);
    }
}
