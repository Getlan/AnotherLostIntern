using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    [SerializeField] private float distanceToSee;
    private RaycastHit whatIHit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, this.transform.forward*distanceToSee,Color.magenta);
		if(Physics.Raycast(this.transform.position, this.transform.forward,out whatIHit, distanceToSee))
        {
            Debug.Log("I touched " + whatIHit.collider.gameObject.name);
        }
	}
}
