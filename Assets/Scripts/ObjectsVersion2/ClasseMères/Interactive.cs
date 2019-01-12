using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactive : MonoBehaviour
{

    protected bool isLooking = false;
    protected bool isInteracting =false;

    public virtual void IsLooking()
    {
        if (!isInteracting)
        {
            UIManager.instance.ShowInteractCaption();
        }
        isLooking = true;
    }

    public void StopLooking()
    {
        isLooking = false;
        UIManager.instance.HideInteractCaption();
    }

    public virtual void Interact()
    {
        isInteracting = true;
        UIManager.instance.HideInteractCaption();
    }

    public virtual void StopInteract()
    {   
        isInteracting = false;
    }

    public bool GetIsInteracting()
    {
        return isInteracting;
    }
}
