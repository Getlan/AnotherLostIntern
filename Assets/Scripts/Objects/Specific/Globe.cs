using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : Interactive
{
    [SerializeField] protected Vector3 state1, state2, state3;
    [SerializeField] protected float animationTime;
    private Animator animator;
    //protected Hashtable iTweenArgs;

    private void Start()
    {
        interactCaptionText = "Faire tourner le globe";
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        animator.SetTrigger("rotate");
        Invoke("StopInteract", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public override void StopInteract()
    {
        base.StopInteract();
    }
}
