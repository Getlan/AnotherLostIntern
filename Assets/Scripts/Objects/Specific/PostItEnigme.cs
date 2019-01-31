using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItEnigme : Observable
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
        textObject.ChangeTextToRead("PostItEnigme");
        if(StepManager.instance.postItChecked == false)
        {
            AudioManager.instance.Play("Indices_1");
            StepManager.instance.postItChecked = true; 
        }
    }

    public override void StopInteract()
    {
        base.StopInteract();
        textObject.ChangeTextToRead("");
    }
}
