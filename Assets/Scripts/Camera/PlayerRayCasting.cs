using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    //[SerializeField] private float thickness;
    private bool isInteractingWithManipulableObject
    {
        get { return GameManager.Gm.isInteractingWithManipulableObject; }
    }

    private RaycastHit rayHit;
    private Interactive objectHit =null;
    private bool hitSomething =false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, distanceToSee))
        {
            Interactive rayHitInteractive = rayHit.collider.gameObject.GetComponent<Interactive>();
            if(rayHitInteractive != null)
            {
                if (objectHit != null && objectHit != rayHit.collider.gameObject)
                {
                    objectHit.StopLooking();
                }
                objectHit = rayHitInteractive;
                hitSomething = true;
                objectHit.IsLooking();
                if (Input.GetMouseButtonDown(0)) {
                    if (!objectHit.GetIsInteracting())
                    {
                        objectHit.Interact();
                    }
                    else
                    {
                        if (objectHit.GetComponent<NoStateObject>() != null)
                        {
                            objectHit.GetComponent<NoStateObject>().ClickWhileInteracting();
                        }
                        /*switch (objectHit.GetType().Name)
                        {
                            case "Observable":
                                RaycastHit hit;
                                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                                if (Physics.Raycast(ray, out hit, 10f))
                                {
                                    if (hit.transform == null || hit.transform.gameObject != objectHit)
                                    {
                                        objectHit.StopInteract();
                                        objectHit = null;
                                    }
                                }
                                break;
                        }*/
                    }
                }
            } 
            else if (hitSomething && !isInteractingWithManipulableObject)
            {
                hitSomething = false;
                objectHit.StopLooking();
                objectHit = null;
            }
        }
        else if (hitSomething && !isInteractingWithManipulableObject)
        {
            hitSomething = false;
            objectHit.StopLooking();
            objectHit = null;
        }
    }
}
