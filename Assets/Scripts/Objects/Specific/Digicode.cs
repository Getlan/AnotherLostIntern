using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digicode : ComplexObservable
{
    private bool step1 = false;
    private bool step2 = false;
    private bool step3 = false;
    private bool step4 = false;
    private bool step5 = false;

    private GameObject[] buttons;

    private bool activated = false;
    private bool buttonPushed = false;

    private int nbButtonsPushed = 0;

    private AudioSource audioSource;
    [SerializeField] AudioClip wrongCodeClip;
    [SerializeField] AudioClip righCodeClip;
    [SerializeField] AudioClip buttonTouched;

    private GameObject rightLight;
    private GameObject wrongLight;

    protected override void Start()
    {
        base.Start();
        audioSource = this.GetComponent<AudioSource>();
        buttons = new GameObject[10];
        for (int i = 0; i < this.transform.childCount - 2; i++)
        {
            buttons[i] = this.transform.GetChild(i).gameObject;
            buttons[i].GetComponent<Collider>().enabled = false;
        }
        wrongLight = this.transform.GetChild(this.transform.childCount - 2).gameObject;
        rightLight = this.transform.GetChild(this.transform.childCount - 1).gameObject;
        zoneToClick = buttons[7];
    }

    private void OnMouseDrag()
    {

    }

    protected override void ActivateComplexZone()
    {
        if (step1)
        {
            Reinitialize();
            step2 = true;
            zoneToClick = buttons[2];
        }
        else if (step2)
        {
            Reinitialize();
            step3 = true;
            zoneToClick = buttons[2];
        }
        else if (step3)
        {
            Reinitialize();
            step4 = true;
            zoneToClick = buttons[1];
        }
        else if (step4)
        {
            step5 = true;
            RightCode();
        }
        else
        {
            step1 = true;
            zoneToClick = buttons[1];
        }
    }

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform != null)
            {
                if (hit.transform.gameObject == zoneToClick)
                {
                    audioSource.PlayOneShot(buttonTouched);
                    ActivateComplexZone();
                    nbButtonsPushed++;
                    buttonPushed = true;
                }
                else
                {
                    foreach (GameObject button in buttons)
                    {
                        if (hit.transform.gameObject == button)
                        {
                            audioSource.PlayOneShot(buttonTouched);
                            nbButtonsPushed++;
                            buttonPushed = true;
                            break;
                        }
                    }
                }
            }
            if (!buttonPushed && hit.transform.gameObject != this.gameObject)
            {
                StopInteract();
            }
        }
        else
        {
            StopInteract();
        }
        if (nbButtonsPushed == 5 && !step5)
        {
            WrongCode();
        }
        buttonPushed = false;
    }

    public override void IsLooking()
    {
        if (!activated)
        {
            base.IsLooking();
        }
    }

    public override void Interact()
    {
        if (!activated)
        {
            base.Interact();
            foreach (GameObject button in buttons)
            {
                button.GetComponent<Collider>().enabled = true;
                button.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
        }
    }

    public override void StopInteract()
    {
        base.StopInteract();
        Reinitialize();
        nbButtonsPushed = 0;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Collider>().enabled = false;
            button.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    private void WrongCode()
    {
        Reinitialize();
        zoneToClick = buttons[7];
        nbButtonsPushed = 0;
        audioSource.PlayOneShot(wrongCodeClip);
        wrongLight.SetActive(true);
        StartCoroutine(BlinkLight(wrongLight));
    }

    private void RightCode()
    {
        StepManager.instance.UnlockBossDoor();
        audioSource.PlayOneShot(righCodeClip);
        activated = true;
        StopInteract();
        rightLight.SetActive(true);
        wrongLight.SetActive(false);
        StartCoroutine(BlinkLight(rightLight));

    }

    private void Reinitialize()
    {
        step1 = false;
        step2 = false;
        step3 = false;
        step4 = false;
    }

    IEnumerator BlinkLight(GameObject light)
    {
        float endTime = Time.time + 1f;
        while (Time.time < endTime)
        {
            light.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            light.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        light.SetActive(true);
    }
}
