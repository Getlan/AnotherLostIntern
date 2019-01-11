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
    private GameObject objectHit =null;
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
                    objectHit.GetComponent<Interactive>().StopLooking();
                }
                objectHit = rayHit.collider.gameObject;
                hitSomething = true;
                objectHit.GetComponent<Interactive>().IsLooking();
            } 
            else if (hitSomething && !isInteractingWithManipulableObject)
            {
                hitSomething = false;
                objectHit.GetComponent<Interactive>().StopLooking();
            }
        }
        else if (hitSomething && !isInteractingWithManipulableObject)
        {
            hitSomething = false;
            objectHit.GetComponent<Interactive>().StopLooking();
        }
	}
}
