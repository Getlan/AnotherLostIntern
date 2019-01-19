using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool canMove;
    private bool canRotate;
    private bool canInteract;
    private bool cursorIsLocked;
    private bool isInteracting;
    private bool isInteractingWithComputer;
    private bool isInteractingWithManipulableObject;

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
        canInteract = true;
        canRotate = true;
        canMove = true;
        CursorIsLocked = true;
        IsInteractingWithComputer = false;
        IsInteractingWithManipulableObject = false;
        IsInteracting = false;
        cursorIcon.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetCameraPosition()
    {
        return PlayerCamera.transform.position;
    }

    public Vector3 GetCameraForward()
    {
        return PlayerCamera.transform.forward;
    }

    public bool IsPlayerStandingStill()
    {
        return Player.velocity.magnitude<1.5f;
    }

    public void ActivateCursorIcon()
    {
        cursorIcon.SetActive(true);
    }

    public void DeactivateCursorIcon()
    {
        cursorIcon.SetActive(false);
    }

    public bool IsInteracting
    {
        get
        {
            return isInteracting;
        }

        set
        {
            isInteracting = value;
        }
    }

    public Rigidbody Player
    {
        get
        {
            return Player1;
        }

        set
        {
            Player1 = value;
        }
    }

    public bool IsInteractingWithComputer
    {
        get
        {
            return isInteractingWithComputer;
        }

        set
        {
            isInteractingWithComputer = value;
        }
    }

    public bool IsInteractingWithManipulableObject
    {
        get
        {
            return isInteractingWithManipulableObject;
        }

        set
        {
            isInteractingWithManipulableObject = value;
        }
    }

    public bool CursorIsLocked
    {
        get
        {
            return cursorIsLocked;
        }

        set
        {
            cursorIsLocked = value;
        }
    }

    public bool CanRotate
    {
        get
        {
            return canRotate;
        }

        set
        {
            canRotate = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
        }
    }

    public Camera PlayerCamera
    {
        get
        {
            return playerCamera;
        }

        set
        {
            playerCamera = value;
        }
    }

    public bool FixRotation
    {
        get
        {
            return fixRotation;
        }

        set
        {
            fixRotation = value;
        }
    }

    public Rigidbody Player1
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    public Transform HoldPosition
    {
        get
        {
            return holdPosition;
        }

        set
        {
            holdPosition = value;
        }
    }

    public bool CanInteract
    {
        get
        {
            return canInteract;
        }

        set
        {
            canInteract = value;
        }
    }
}
