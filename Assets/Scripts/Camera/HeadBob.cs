using System;
using UnityEngine;
using UnityStandardAssets.Utility;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private CurveControlledBob motionBob = new CurveControlledBob();
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private float strideInterval;
    [Range(0f, 1f)] [SerializeField] private float runningStrideLengthen;
    private Vector3 originalCameraPosition;


    private void Start()
    {
        motionBob.Setup(Camera, strideInterval);
        originalCameraPosition = Camera.transform.localPosition;
    }


    private void Update()
    {
        Vector3 newCameraPosition;

        //If the player is moving, do the head bob
        if (playerMove.Velocity.magnitude > 0)
        {
            Camera.transform.localPosition = motionBob.DoHeadBob(playerMove.Velocity.magnitude*(playerMove.Running ? runningStrideLengthen : 1f));
            newCameraPosition = Camera.transform.localPosition;
        }

        //If the player is not moving, the camera doesn't move
        else
        {
            newCameraPosition = Camera.transform.localPosition;
        }

        //Update the camera position
        Camera.transform.localPosition = newCameraPosition;
    }
}
