using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObject : Interactive
{

    [SerializeField]private Vector3 state1, state2;
    [SerializeField] private float animationTime;
    private bool isState2 = false;

    private Hashtable iTweenArgs;

    protected void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", state2);
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
        }
        else
        {
            iTweenArgs["position"] = state1;
        }
        iTween.MoveTo(this.gameObject, iTweenArgs);
        isState2 = !isState2;
        StopInteract();
    }

    protected override void StopInteract()
    {
        base.StopInteract();
    }
}
