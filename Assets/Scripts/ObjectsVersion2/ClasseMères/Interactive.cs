using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactive : MonoBehaviour
{

    protected bool isLooking = false;
    protected bool isInteracting =false;
    [SerializeField] protected GameObject interactCaption;

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
            interactCaption.SetActive(true);
        }
        isLooking = true;
    }

    public void StopLooking()
    {
        isLooking = false;
        interactCaption.SetActive(false);
    }

    protected virtual void Interact()
    {
        isInteracting = true;
        interactCaption.SetActive(false);
    }

    protected virtual void StopInteract()
    {
        isInteracting = false;
    }
}
