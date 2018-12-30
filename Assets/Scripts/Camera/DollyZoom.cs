using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]

public class DollyZoom : MonoBehaviour {

    private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float dollySpeed;
    [SerializeField] private float maxTime = 1f;
    private float timerDolly = 0f;
    private bool canDolly = true;
    private float initialFrustumHeight;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        cam = GetComponent<Camera>();
        Debug.Assert(cam != null);

        float distanceFromTarget = Vector3.Distance(transform.position, target.position);
        initialFrustumHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (canDolly)
        //{
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * dollySpeed);
            float currentDistance = Vector3.Distance(transform.position, target.position);
            cam.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
            checkDolly();
        //}
    }

    private float ComputeFrustumHeight(float distance)
    {
        return (2.0f * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    private float ComputeFieldOfView(float height, float distance)
    {
        return (2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg);
    }


    //Check if the timer is finished
    private void checkDolly()
    {
        timerDolly += Time.deltaTime;
        if (timerDolly > maxTime)
        {
            canDolly = false;
        }
    }

    //Starts the dolly effect
    public void StartDolly()
    {
        if (!canDolly)
        {
            timerDolly = 0.0f;
            canDolly = true;
        }
    }
}
