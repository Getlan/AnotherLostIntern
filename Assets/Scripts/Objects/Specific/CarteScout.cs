using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteScout : ComplexObservable
{

    private Animator animator;
    private bool open = false;
    private bool activated = false;
    private bool seen = false;
    private Collider objectCollider;
    private TextObject textObject;

    private AudioSource audioSource;
    [SerializeField] AudioClip cardOpen;

    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        objectCollider = this.GetComponent<Collider>();
        textObject = this.GetComponent<TextObject>();
        audioSource = GetComponent<AudioSource>();
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
        if (!open)
        {
            transform.LookAt(GameManager.Gm.PlayerCamera.transform);
            animator.SetTrigger("open");
            audioSource.PlayOneShot(cardOpen);
            open = true;
            zoneToClick.SetActive(true);
            objectCollider.enabled = false;
            if (!seen)
            {
                seen = true;
            }
            textObject.ChangeTextToRead("CarteScout2");
        }
    }

    public override void Interact()
    {
        base.Interact();
        textObject.ChangeTextToRead("CarteScout1");
    }

    private void CloseBook()
    {
        animator.SetTrigger("close");
        objectCollider.enabled = true;
        zoneToClick.SetActive(false);
        open = false;
        textObject.ChangeTextToRead("CarteScout1");
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
        if (seen && !activated)
        {
            StepManager.instance.DoTutoScoutCardSeen();
            activated = true;   
        }
    }

    private void FinishStopInteract()
    {
        zoneToClick.SetActive(false);
        textObject.ChangeTextToRead("");
        base.StopInteract();
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.4f);
        FinishStopInteract();
    }
}
