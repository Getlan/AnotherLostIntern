using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleProphetie : ComplexObservable
{
    private Animator animator;
    bool open = false;
    private Collider objectCollider;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
    }

    protected override void ActivateComplexZone()
    {
        if (open)
        {
            animator.SetTrigger("close");
            open = false;
        }
        else
        {
            animator.SetTrigger("open");
            open = true;
            AudioManager.instance.Play("Drone_2");
        }

    }

    public override void StopInteract()
    {
        if (open)
        {
            animator.SetTrigger("close");
            open = false;
            StartCoroutine(WaitAnimationEnd());
        }
        else
        {
            FinishStopInteract();
        }
    }

    private void FinishStopInteract()
    {
        base.StopInteract();
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        FinishStopInteract();
    }
}
