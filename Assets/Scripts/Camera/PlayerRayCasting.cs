using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    [SerializeField] private float thickness;

    private RaycastHit rayHit;
    private GameObject objectHit;
    private bool hitSomething =false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.SphereCast(this.transform.position, thickness, this.transform.forward, out rayHit, distanceToSee))
        {
            if (rayHit.collider.tag == "Interactible")
            {
                objectHit = rayHit.collider.gameObject;
                hitSomething = true;
                objectHit.GetComponent<Interactible>().IsLooking();
            }
        }
        else if (hitSomething)
        {
            hitSomething = false;
            objectHit.GetComponent<Interactible>().StopLooking();
        }
	}
}
