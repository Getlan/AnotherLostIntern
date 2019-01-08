using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool canMove { get; set; }
    public bool canRotate { get; set; }
    public bool cursorIsLocked { get; set; }
    public bool isInteractingWithComputer { get; set; }
    public bool isInteractingWithManipulableObject { get; set; }
    [SerializeField] Camera playerCamera;
    [SerializeField] bool fixRotation = true;
    [SerializeField] Rigidbody player;
    [SerializeField] private GameObject cursorIcon;
    [SerializeField] private Transform holdPosition;

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
        isInteractingWithManipulableObject = false;
        cursorIcon.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetCameraPosition()
    {
        return playerCamera.transform.position;
    }

    public Vector3 GetCameraForward()
    {
        return playerCamera.transform.forward;
    }

    public Camera GetCamera()
    {
        return playerCamera;
    }

    public bool GetFixRotation()
    {
        return fixRotation;
    }

    public Rigidbody GetPlayer()
    {
        return player;
    }

    public bool IsPlayerStandingStill()
    {
        return player.velocity.magnitude<1.5f;
    }

    public void ActivateCursorIcon()
    {
        cursorIcon.SetActive(true);
    }

    public void DeactivateCursorIcon()
    {
        cursorIcon.SetActive(false);
    }

    public Transform GetHoldPosition()
    {
        return holdPosition;
    }
}
