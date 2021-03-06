﻿using System;
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
    private TextObject textObject;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        objectCollider = this.GetComponent<Collider>();
        audioSource = this.GetComponent<AudioSource>();
        textObject = this.GetComponent<TextObject>();
    }

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2f))
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
            textObject.ChangeTextToRead("Carnet2");
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
            textObject.ChangeTextToRead("Carnet1");
        }
    }

    protected void OpenBook()
    {
        if (!open)
        {
            UIManager.instance.ShowReadCaption();
            transform.LookAt(GameManager.Gm.PlayerCamera.transform);
            animator.SetTrigger("open");
            open = true;
            page1 = true;
            zoneToClick.SetActive(true);
            otherZoneToClick.SetActive(true);
            objectCollider.enabled = false;
            textObject.ChangeTextToRead("Carnet1");
        }
    }

    public override void Interact()
    {
        base.Interact();
        textObject.ChangeTextToRead("");
    }

    private void CloseBook()
    {
        UIManager.instance.HideReadCaption();
        textObject.ChangeTextToRead("");
        animator.SetTrigger("close");
        objectCollider.enabled = true;
        otherZoneToClick.SetActive(false);
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
