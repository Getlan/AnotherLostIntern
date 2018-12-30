using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool canMove { get; set; }
    public bool canRotate { get; set; }
    public bool cursorIsLocked { get; set; }
    public bool isInteractingWithComputer { get; set; }

    public static GameManager Gm = null;

    void Awake()
    {
        if (Gm == null)
        {
            Gm = this;
        }
        else if (Gm != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        canMove = true;
        canRotate = true;
        cursorIsLocked = true;
        isInteractingWithComputer = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
