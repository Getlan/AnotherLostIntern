using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetaire : ComplexObservable
{

    private Animator animator;
    private int currentStep = 1;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
    }

    protected override void ActivateComplexZone()
    {
        animator.Play("Step0"+currentStep.ToString());
        currentStep++;
        if (currentStep > 6)
        {
            currentStep = 1;
        }
    }
}
