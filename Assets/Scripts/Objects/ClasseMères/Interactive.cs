using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactive : MonoBehaviour
{
    protected string interactCaptionText;
    protected bool isLooking = false;
    private bool isInteracting = false;

    public bool IsInteracting
    {
        get
        {
            return isInteracting;
        }

        set
        {
            isInteracting = value;
        }
    }

    public virtual void IsLooking()
    {
        if (!IsInteracting)
        {
            UIManager.instance.ShowInteractCaption();
            isLooking = true;
        }

    }

    public void StopLooking()
    {
        isLooking = false;
        UIManager.instance.HideInteractCaption();
    }

    public virtual void Interact()
    {
        GameManager.Gm.IsInteracting=true;
        IsInteracting = true;
        UIManager.instance.HideInteractCaption();
    }

    public virtual void StopInteract()
    {
        GameManager.Gm.IsInteracting=false;
        IsInteracting = false;
    }
}
