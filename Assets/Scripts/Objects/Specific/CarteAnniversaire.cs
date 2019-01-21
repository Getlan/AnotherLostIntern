using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteAnniversaire : ComplexObservable
{
    private Animator animator;
    private bool open = false;
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
            if (hit.transform != null && hit.transform.gameObject == gameObject)
            {
                ActivateComplexZone();
            }
            else if (hit.transform != null && hit.transform.gameObject == zoneToClick)
            {
                CloseBook();
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
        if (!open)
        {
            transform.LookAt(GameManager.Gm.PlayerCamera.transform);
            animator.SetTrigger("open");
            open = true;
            zoneToClick.SetActive(true);
            objectCollider.enabled = false;
            textObject.ChangeTextToRead("CarteAnniversaire");
        }
    }

    public override void Interact()
    {
        base.Interact();
        textObject.ChangeTextToRead("");
    }

    private void CloseBook()
    {
        animator.SetTrigger("close");
        objectCollider.enabled = true;
        zoneToClick.SetActive(false);
        open = false;
        textObject.ChangeTextToRead("");
    }

    public override void StopInteract()
    {
        if (open)
        {
            CloseBook();
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
