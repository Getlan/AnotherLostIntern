using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertus2 : Observable
{
    private TextObject textObject;

    protected override void Start()
    {
        base.Start();
        textObject = this.GetComponent<TextObject>();
    }

    public override void Interact()
    {
        base.Interact();
        textObject.ChangeTextToRead("Vertus2");


        if(StepManager.instance.postItChecked == true)
        {
            if (StepManager.instance.vertusChecked == false)
            {
                StepManager.instance.CountClue();
                StepManager.instance.vertusChecked = true;
            }

        }

    }

    public override void StopInteract()
    {
        base.StopInteract();
        textObject.ChangeTextToRead("");
    }
}
