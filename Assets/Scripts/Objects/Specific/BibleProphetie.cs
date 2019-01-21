using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleProphetie : ComplexObservable
{
    private Animator animator;
    bool open = false;
    bool activated = false;
    private Collider objectCollider;
    private TextObject textObject;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        textObject = this.GetComponent<TextObject>();
        objectCollider = this.GetComponent<Collider>();
    }

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2f))
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
        transform.LookAt(GameManager.Gm.PlayerCamera.transform);
        animator.SetTrigger("open");
        open = true;
        zoneToClick.SetActive(true);
        objectCollider.enabled = false;
        if (!activated)
        {
            activated = true;
            AudioManager.instance.Play("Drone_2");
            AudioManager.instance.FadeIn("Drone_2", 1, 10);
        }
        textObject.ChangeTextToRead("Bible");
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
        base.StopInteract();
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length +0.6f);
        FinishStopInteract();
    }
}
