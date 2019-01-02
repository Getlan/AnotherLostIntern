using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    [SerializeField] private float thickness;
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
        Debug.DrawRay(transform.position, transform.forward, Color.blue, distanceToSee);
        if (Physics.SphereCast(this.transform.position, thickness, this.transform.forward, out rayHit, distanceToSee))
        {
            if (rayHit.collider.tag == "Interactible")
            {
                if (objectHit != null &&objectHit != rayHit.collider.gameObject)
                {
                    objectHit.GetComponent<Interactible>().StopLooking();
                }
                objectHit = rayHit.collider.gameObject;
                hitSomething = true;
                objectHit.GetComponent<Interactible>().IsLooking();
            }
        }
        else if (hitSomething && !isInteractingWithManipulableObject)
        {
            hitSomething = false;
            objectHit.GetComponent<Interactible>().StopLooking();
        }
	}
}
