using System;
using UnityEngine;

[Serializable]
public class MouseLook
{
    //Mouse sensitivity
    [SerializeField] private float xSensitivity = 2f;
    [SerializeField] private float ySensitivity = 2f;

    //Max and min vertical rotation values
    [SerializeField] private float minimumX = -45f;
    [SerializeField] private float maximumX = 90f;

    //Lock the cursor
    [SerializeField] private bool lockCursor = true;
    private bool cursorIsLocked
    {
        get { return GameManager.Gm.CursorIsLocked; }
    }

    //Rotation values
    private Quaternion characterTargetRot;
    private Quaternion cameraTargetRot;

    public void Init(Transform character, Transform camera)
    {
        characterTargetRot = character.localRotation;
        cameraTargetRot = camera.localRotation;
    }

    //Rotate the camera and the character based on mouse inputs
    public void LookRotation(Transform character, Transform camera)
    {
        //Get mouse inputs
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        //Compute camera and character rotation
        characterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        //Block vertical rotation
        cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);

        //Set camera and character rotation
        character.localRotation = characterTargetRot;
        camera.localRotation = cameraTargetRot;
    }

    //Check if the cursor must be locked or not
    public void UpdateLockCursor()
    {
        if (!GameManager.Gm.IsInteractingWithComputer && !GameManager.Gm.IsInteractingWithManipulableObject)
        {
            //If the player presses escape, unlock
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameManager.Gm.Quit();
            }
        }

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    //Block vertical rotation
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, minimumX, maximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
