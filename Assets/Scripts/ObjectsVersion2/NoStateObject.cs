using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoStateObject : Interactive
{

    protected string interactCaptionText;

    public override void IsLooking()
    {
        base.IsLooking();
        if (!isInteracting)
        {
            interactCaption.GetComponent<Text>().text = interactCaptionText;
        }
    }
}
