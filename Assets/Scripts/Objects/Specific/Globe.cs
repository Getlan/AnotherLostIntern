using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : Interactive
{
    [SerializeField] protected Vector3 state1, state2, state3;
    [SerializeField] protected float animationTime;
    private Animator animator;
    bool rotate = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (rotate)
        {
            base.Interact();
            rotate = false;
            animator.SetTrigger("rotate");
            StartCoroutine(WaitAnimationEnd());
        }

    }

    public override void StopInteract()
    {
        base.StopInteract();
    }

    public override void IsLooking()
    {
        base.IsLooking();
        if (!IsInteracting)
        {
            UIManager.instance.ChangeTextInteractCaption("Faire tourner le globe");
        }
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length +0.7f);
        rotate = true;
        StopInteract();
    }
}
