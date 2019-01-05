using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactive : MonoBehaviour
{

    protected bool isLooking = false;
    protected bool isInteracting;
    [SerializeField] private GameObject interactCaption;
    [SerializeField] private string interactCaptionText;

    protected virtual void Update()
    {
        if (isLooking && !isInteracting && Input.GetKeyDown("space"))
        {
            Interact();
        }
    }

    public void IsLooking()
    {
        isLooking = true;
        if (!isInteracting)
        {
            interactCaption.GetComponent<Text>().text = interactCaptionText;
            interactCaption.SetActive(true);
        }
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
