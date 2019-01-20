using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteAnniversaire : ComplexObservable
{
    private Animator animator;
    private bool open = false;
    [SerializeField] private GameObject zoneToOpen;
    private Collider objectCollider;
    private TextObject textObject;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        objectCollider = this.GetComponent<Collider>();
        textObject = this.GetComponent<TextObject>();
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
            textObject.ChangeTextToRead("CarteAnniversaire");
        }
    }

    public override void Interact()
    {
        base.Interact();
        zoneToOpen.SetActive(true);
        textObject.ChangeTextToRead("");
    }

    private void CloseBook()
    {
        animator.SetTrigger("close");
        objectCollider.enabled = true;
        zoneToOpen.SetActive(true);
        zoneToClick.SetActive(false);
        open = false;
        textObject.ChangeTextToRead("");
    }

    public override void StopInteract()
    {
        if (open)
        {
            animator.SetTrigger("close");
            objectCollider.enabled = true;
            open = false;
            textObject.ChangeTextToRead("");
            StartCoroutine(WaitAnimationEnd());
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

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.4f);
        FinishStopInteract();
    }
}
