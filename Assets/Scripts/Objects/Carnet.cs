using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnet : ComplexObservable
{

    private Animator animator;
    private int currentStep = 1;
    bool rotate = true;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
    }

    protected override void ActivateComplexZone()
    {

    }


 
}
