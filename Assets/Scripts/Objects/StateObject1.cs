using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObject1 : Interactive1
{

    [SerializeField]private Vector3 state1, state2;
    [SerializeField] private float animationTime;
    [SerializeField] private MovementType movementType;
    private bool isState2 = false;

    private Hashtable iTweenArgs;
    private enum MovementType { Slide, Rotate };

    protected void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", state2);
        iTweenArgs.Add("rotation", state2);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("isLocal", true);
    }

    protected override void Update()
    {
        base.Update();

    }

    protected override void Interact()
    {
        base.Interact();

        if (!isState2)
        {
            iTweenArgs["position"] = state2;
            iTweenArgs["rotation"] = state2;
        }
        else
        {
            iTweenArgs["position"] = state1;
            iTweenArgs["rotation"] = state1;
        }

        switch (movementType)
        {
            case MovementType.Slide:
                iTween.MoveTo(this.gameObject, iTweenArgs);
                break;
            case MovementType.Rotate:
                iTween.RotateTo(this.gameObject, iTweenArgs);

                break;
        }
        isState2 = !isState2;
        StopInteract();
    }

    protected override void StopInteract()
    {
        base.StopInteract();
    }
}
