using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifix : Observable
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
        textObject.ChangeTextToRead("Crucifix");
    }

    public override void StopInteract()
    {
        base.StopInteract();
        textObject.ChangeTextToRead("");
    }
}
