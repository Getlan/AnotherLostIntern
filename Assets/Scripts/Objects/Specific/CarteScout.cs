using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteScout : ComplexObservable
{

    private Animator animator;
    private bool open = false;
    private bool activated = false;
    private bool seen = false;
    [SerializeField] private GameObject zoneToOpen;
    private Collider objectCollider;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        objectCollider = this.GetComponent<Collider>();
    }

    private void Update()
    {
        if(!activated && seen && !this.IsInteracting)
        {
            StepManager.instance.DoStep1ScoutCardSeen();
            activated = true;
        }
    }

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.transform != null && hit.transform.gameObject == zoneToClick)
            {
                ActivateComplexZone();
            }
            else if (hit.transform != null && hit.transform.gameObject == zoneToOpen)
            {
                OpenBook();
            }
            else if (hit.transform == null || hit.transform.gameObject != this.gameObject)
            {
                StopInteract();
            }
        }
        else
        {
            StopInteract();
        }
    }

    protected override void ActivateComplexZone()
    {
        CloseBook();
    }

    protected void OpenBook()
    {
        if (!open)
        {
            animator.SetTrigger("open");
            open = true;
            zoneToOpen.SetActive(false);
            zoneToClick.SetActive(true);
            objectCollider.enabled = false;
            if (!seen)
            {
                seen = true;
            }
        }
    }

    public override void Interact()
    {
        base.Interact();
        zoneToOpen.SetActive(true);
    }

    private void CloseBook()
    {
        animator.SetTrigger("close");
        objectCollider.enabled = true;
        zoneToOpen.SetActive(true);
        zoneToClick.SetActive(false);
        open = false;
    }

    public override void StopInteract()
    {
        if (open)
        {
            animator.SetTrigger("close");
            objectCollider.enabled = true;
            open = false;
            Invoke("FinishStopInteract", 1);
        }
        else
        {
            FinishStopInteract();
        }
    }

    private void FinishStopInteract()
    {
        zoneToClick.SetActive(false);
        base.StopInteract();
    }
}
