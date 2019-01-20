using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueToClick : MonoBehaviour
{
    private bool isActivated = false;
    private bool clicked = false;

    private void Update()
    {
        if(!isActivated && clicked && !this.transform.parent.GetComponent<Interactive>().IsInteracting)
        {
            StepManager.instance.DoStep1MailChecked();
            isActivated = true;

        }
    }

    public void Clicked()
    {
        clicked = true;
    }
}
