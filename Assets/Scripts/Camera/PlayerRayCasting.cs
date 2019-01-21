using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    private int distanceLookingDown = 6;
    private float distanceLookingUp = 5.5f;

    private float maxClickTime = 0.15f;
    private float startClickTime = 0;

    private RaycastHit rayHit;
    private Interactive objectHit =null;
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Gm.IsInteracting)
        {
            if (Input.GetButtonDown("MainAction") && objectHit.GetComponent<NoStateObject>() != null)
            {
                startClickTime = Time.time;
            }
            else if (Input.GetButtonUp("MainAction") && objectHit.GetComponent<NoStateObject>() != null)
            {
                if (Time.time - startClickTime < maxClickTime)
                {
                    Debug.Log("click");
                    objectHit.GetComponent<NoStateObject>().ClickWhileInteracting();
                }
            }
        }
        else
        {
            if (GameManager.Gm.PlayerCamera.transform.localRotation.x > 0.5)
            {
                distanceToSee = distanceLookingDown;
            }
            else
            {
                distanceToSee = distanceLookingUp;
            }
            if (GameManager.Gm.CanInteract && Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, distanceToSee) && rayHit.collider.gameObject.GetComponent<Interactive>()!=null)
            {
                GameObject rayHitObject = rayHit.collider.gameObject;
                if (objectHit != null && objectHit != rayHitObject)
                    {
                        objectHit.StopLooking();
                        UIManager.instance.HideInteractCaption();
                    }
                    objectHit = rayHitObject.GetComponent<Interactive>();
                    objectHit.IsLooking();
                    if (Input.GetButtonDown("MainAction"))
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
