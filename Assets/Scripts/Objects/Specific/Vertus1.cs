using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertus1 : Observable
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
        textObject.ChangeTextToRead("Vertus1");
    }

    public override void StopInteract()
    {
        base.StopInteract();
        textObject.ChangeTextToRead("");
    }
}
