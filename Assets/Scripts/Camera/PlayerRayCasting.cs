using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    //[SerializeField] private float thickness;

    private RaycastHit rayHit;
    private Interactive objectHit =null;
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Gm.IsInteracting)
        {
            if (Input.GetMouseButtonDown(0) && objectHit.GetComponent<NoStateObject>() != null)
            {
                objectHit.GetComponent<NoStateObject>().ClickWhileInteracting();
            }
        }
        else
        {
            if (GameManager.Gm.CanInteract && Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, distanceToSee) && rayHit.collider.gameObject.GetComponent<Interactive>()!=null)
            {
                GameObject rayHitObject = rayHit.collider.gameObject;
                if (objectHit != null && objectHit != rayHitObject)
                    {
                        objectHit.StopLooking();
                    }
                    objectHit = rayHitObject.GetComponent<Interactive>();
                    objectHit.IsLooking();
                    if (Input.GetMouseButtonDown(0))
                    {
                        objectHit.Interact();
                    }
                }
            else if (objectHit != null)
            {
                objectHit.StopLooking();
                objectHit = null;
            }
        }
    }
}
