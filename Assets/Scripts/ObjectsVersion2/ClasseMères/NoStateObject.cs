using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class NoStateObject : Interactive
{

    protected string interactCaptionText;

    public override void IsLooking()
    {
        base.IsLooking();
        if (!isInteracting)
        {
            UIManager.instance.ChangeTextInteractCaption(interactCaptionText);
        }
    }

    abstract public void ClickWhileInteracting();
}
