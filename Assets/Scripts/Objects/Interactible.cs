using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Interactible : MonoBehaviour {

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
        else if (isInteracting && Input.GetMouseButtonDown(1))
        {
            StopInteract();
        }
    }

    public void IsLooking() {
        //Debug.Log("I look at " + gameObject.name);
        isLooking = true;
        if (!isInteracting)
        {
            interactCaption.GetComponent<Text>().text = interactCaptionText;
            interactCaption.SetActive(true);
        }
    }

    public void StopLooking()
    {
        //Debug.Log("I stopped looking at " + gameObject.name);
        isLooking = false;
        interactCaption.SetActive(false);
        StopInteract();
    }

    protected virtual void Interact()
    {
        //Debug.Log("I interact with " + gameObject.name);
        isInteracting = true;
        interactCaption.SetActive(false);
        GameManager.Gm.canMove = false;
        GameManager.Gm.canRotate = false;
    }

    protected virtual void StopInteract()
    {
        //Debug.Log("I stopped interacting with " + gameObject.name);
        isInteracting = false;
        interactCaption.SetActive(true);
        GameManager.Gm.canMove = true;
        GameManager.Gm.canRotate = true;
    }
}
