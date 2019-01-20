using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateObject : Interactive
{
    [SerializeField] private string interactCaptionTextState1, interactCaptionTextState2;
    [SerializeField]private Vector3 state1, state2;
    [SerializeField] private float animationTime;
    [SerializeField] private MovementType movementType;
    [SerializeField] private AudioClip state1Clip;
    [SerializeField] private AudioClip state2Clip;
    private AudioSource audioSource;
    bool hasAudioSource = false;

    private bool isState2 = false;
    private string textToDisplay;

    private Hashtable iTweenArgs;
    private enum MovementType { Slide, Rotate };

    protected void Start()
    {
        textToDisplay = interactCaptionTextState1;
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", state2);
        iTweenArgs.Add("rotation", state2);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("isLocal", true);
        if (GetComponent<AudioSource>() != null)
        {
            audioSource = GetComponent<AudioSource>();
            hasAudioSource = true;
        }
    }

    public override void IsLooking()
    {
        base.IsLooking();
        if (!IsInteracting)
        {
            UIManager.instance.ChangeTextInteractCaption(textToDisplay);
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (!isState2)
        {
            if (hasAudioSource)
            {
                audioSource.PlayOneShot(state2Clip);
            }
            iTweenArgs["position"] = state2;
            iTweenArgs["rotation"] = state2;
            textToDisplay = interactCaptionTextState2;
        }
        else
        {
            if (hasAudioSource)
            {
                audioSource.PlayOneShot(state1Clip);
            }
            iTweenArgs["position"] = state1;
            iTweenArgs["rotation"] = state1;
            textToDisplay = interactCaptionTextState1;
        }

        switch (movementType)
        {
            case MovementType.Slide:
                iTween.MoveTo(this.gameObject, iTweenArgs);
                break;
            case MovementType.Rotate:
                iTween.RotateTo(this.gameObject, iTweenArgs);

                break;
        }
        isState2 = !isState2;
        StopInteract();
    }

    public override void StopInteract()
    {
        base.StopInteract();
    }
}
