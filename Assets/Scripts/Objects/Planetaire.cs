using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetaire : ComplexObservable
{

    private Animator animator;
    private int currentStep = 1;
    bool rotate = true;

    private AudioSource cogSfx; 

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        cogSfx = this.gameObject.GetComponent<AudioSource>();
    }

    protected override void ActivateComplexZone()
    {
        if (rotate)
        {
            rotate = false;
            animator.Play("Step0" + currentStep.ToString());
            cogSfx.Play();
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
        rotate = true;
    }

 
}
