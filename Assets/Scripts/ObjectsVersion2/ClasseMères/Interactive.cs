using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactive : MonoBehaviour
{

    protected bool isLooking = false;
    protected bool isInteracting =false;

    protected virtual void Update()
    {
        if (isLooking && !isInteracting && Input.GetKeyDown("space"))
        {
            Interact();
        }
    }

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

    protected virtual void Interact()
    {
        isInteracting = true;
        UIManager.instance.HideInteractCaption();
    }

    protected virtual void StopInteract()
    {
        isInteracting = false;
    }
}
