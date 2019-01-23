using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertus1 : Observable
{
    private TextObject textObject;
    private bool vertusChecked = false;

    protected override void Start()
    {
        base.Start();
        textObject = this.GetComponent<TextObject>();
    }

    public override void Interact()
    {
        base.Interact();
        textObject.ChangeTextToRead("Vertus1");

        if(vertusChecked == false)
        {
            StepManager.instance.CountClue();
            vertusChecked = true; 
        }

    }

    public override void StopInteract()
    {
        base.StopInteract();
        textObject.ChangeTextToRead("");
    }
}
