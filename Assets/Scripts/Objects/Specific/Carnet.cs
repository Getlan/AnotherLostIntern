using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnet : ComplexObservable
{

    private Animator animator;
    bool open = false;
    bool page1 = false;
    bool page2 = false;
    [SerializeField] private GameObject zoneToOpen;
    [SerializeField] private GameObject otherZoneToClick;
    private Collider objectCollider;
    private AudioSource audioSource;
    [SerializeField] AudioClip pageTurnClip;


    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        objectCollider = this.GetComponent<Collider>();
        audioSource = this.GetComponent<AudioSource>();
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
            else if (hit.transform != null && hit.transform.gameObject == otherZoneToClick)
            {
                ActivateOtherComplexZone();
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
        if (page1)
        {
            animator.SetTrigger("changePage");
            page1 = false;
            page2 = true;
            audioSource.PlayOneShot(pageTurnClip);
        }
        else if (page2)
        {
            CloseBook();
        }
    }

    protected void ActivateOtherComplexZone()
    {
        if (page1)
        {
            CloseBook();
        }
        else if (page2)
        {
            animator.SetTrigger("backPage");
            page1 = true;
            page2 = false;
            audioSource.PlayOneShot(pageTurnClip);
        }
    }

    protected void OpenBook()
    {
        if (!open)
        {
            animator.SetTrigger("open");
            open = true;
            page1 = true;
            zoneToOpen.SetActive(false);
            zoneToClick.SetActive(true);
            otherZoneToClick.SetActive(true);
            objectCollider.enabled = false;
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
        otherZoneToClick.SetActive(false);
        zoneToOpen.SetActive(true);
        zoneToClick.SetActive(false);
        open = false;
        page1 = false;
        page2 = false;
    }

    public override void StopInteract()
    {
        if (open)
        {
            animator.SetTrigger("close");
            objectCollider.enabled = true;
            open = false;
            page1 = false;
            page2 = false;
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
