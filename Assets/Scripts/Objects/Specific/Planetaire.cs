using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetaire : ComplexObservable
{

    private Animator animator;
    private int currentStep = 1;
    bool rotate = true;
    private AudioSource audioSource;
    [SerializeField] AudioClip cogClip;

    private bool planetaireChecked = false; 

    private AudioSource cogSfx; 

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }

    protected override void ActivateComplexZone()
    {
        if (rotate)
        {
            rotate = false;
            animator.Play("Step0" + currentStep.ToString());
            audioSource.PlayOneShot(cogClip);
            currentStep++;
            if (currentStep > 6)
            {
                currentStep = 1;
            }
            StartCoroutine(WaitAnimationEnd());
            if(planetaireChecked == false)
            {
                StepManager.instance.CountClue();
                planetaireChecked = true; 
            }
           
        }
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        rotate = true;
    }

 
}
