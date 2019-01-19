using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueToSee : MonoBehaviour
{
    private RaycastHit rayHit;
    private float distanceToSee = 5;
    private bool seen = false;
    private bool isActivated = false;

    private void Update()
    {
        if (this.transform.parent.GetComponent<Interactive>().IsInteracting && !seen)
        {
            if (Physics.Raycast(GameManager.Gm.PlayerCamera.transform.position, GameManager.Gm.PlayerCamera.transform.forward, out rayHit, distanceToSee))
            {
                if (rayHit.transform != null && rayHit.transform.gameObject == this.gameObject)
                {
                    seen = true;
                }
            }
        }
        else if (!isActivated && seen && !this.transform.parent.GetComponent<Interactive>().IsInteracting)
        {
            StepManager.instance.DoStep1PasswordSeen();
            isActivated = true;
        }
    }
}
