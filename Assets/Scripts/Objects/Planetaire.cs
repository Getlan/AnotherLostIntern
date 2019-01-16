using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetaire : ComplexObservable
{

    private Animator animator;
    private int currentStep = 1;
    bool canRotate = true;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
    }

    protected override void ActivateComplexZone()
    {
        if (canRotate)
        {
            canRotate = false;
            animator.Play("Step0" + currentStep.ToString());
            currentStep++;
            if (currentStep > 6)
            {
                currentStep = 1;
            }
            StartCoroutine(WaitAnimationEnd());
        }
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        canRotate = true;
    }

 
}
