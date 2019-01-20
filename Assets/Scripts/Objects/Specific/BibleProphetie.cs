using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleProphetie : ComplexObservable
{
    private Animator animator;
    bool open = false;
    private Collider objectCollider;
    private TextObject textObject;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        textObject = this.GetComponent<TextObject>();
    }

    protected override void ActivateComplexZone()
    {
        if (open)
        {
            animator.SetTrigger("close");
            open = false;
            textObject.ChangeTextToRead("");
        }
        else
        {
            animator.SetTrigger("open");
            open = true;
            AudioManager.instance.Play("Drone_2");
            AudioManager.instance.FadeIn("Drone_2", 1, 10);
            textObject.ChangeTextToRead("Bible");
        }

    }

    public override void StopInteract()
    {
        if (open)
        {
            animator.SetTrigger("close");
            open = false;
            StartCoroutine(WaitAnimationEnd());
            textObject.ChangeTextToRead("");
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
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length +0.6f);
        FinishStopInteract();
    }
}
