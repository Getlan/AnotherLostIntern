using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class NoStateObject : Interactive
{

    public override void IsLooking()
    {
        base.IsLooking();
        if (!IsInteracting)
        {
            UIManager.instance.ChangeTextInteractCaption(interactCaptionText);
        }
    }

    abstract public void ClickWhileInteracting();
}
