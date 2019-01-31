using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ObjectWithPause
{
    [SerializeField] private OwnerName ownerName;
    private enum OwnerName {Antoine, Nathalie,Gilles };
    [SerializeField] private string password;
    [SerializeField] private bool unlocked;
    private float clickTimer = 0;
    private float maxTime = 0.2f;


    public bool Unlocked
    {
        get
        {
            return unlocked;
        }

        set
        {
            unlocked = value;
        }
    }

    protected void Start()
    {
        interactCaptionText = "Utiliser";
    }

    private void Update()
    {
        if (clickTimer > maxTime && this.IsInteracting && Input.GetButton("MainAction"))
        {
            AudioManager.instance.Play("Mouse_click");
            clickTimer = 0;
        }
        clickTimer += Time.deltaTime;

    }

    public override void Interact()
    {
        base.Interact();
        GameManager.Gm.PlayerCamera.GetComponent<PlayerRayCasting>().DistanceToSee = 0;
        UIManager.instance.ShowUIComputer(ownerName.ToString());
        GameManager.Gm.IsInteractingWithComputer = true;
    }

    public override void StopInteract()
    {
        base.StopInteract();
        UIManager.instance.HideUIComputer(ownerName.ToString());
        GameManager.Gm.IsInteractingWithComputer = false;
        GameManager.Gm.PlayerCamera.GetComponent<PlayerRayCasting>().DistanceToSee = 6;
    }

    public bool CheckPassword(string passwordToTest)
    {
        if (passwordToTest == password)
        {
            Unlocked = true;
            UIManager.instance.UnlockComputer(ownerName.ToString());

            return true; 
        }

        return false; 
    }

    public void ShowNewsApp()
    {
        UIManager.instance.ShowNewsApp(ownerName.ToString());
    }

    public void ShowMailsApp()
    {
        UIManager.instance.ShowMailsApp(ownerName.ToString());
    }

    public void ShowInBox()
    {
        UIManager.instance.ShowInBox(ownerName.ToString());
    }

    public void ShowSent()
    {
        UIManager.instance.ShowSent(ownerName.ToString());
    }

    public void ShowDraft()
    {
        UIManager.instance.ShowDraft(ownerName.ToString());
    }

    public void ShowInBoxMail(int nbMail)
    {
        UIManager.instance.ShowInBoxMail(ownerName.ToString(), nbMail);
    }

    public void ShowSentMail(int nbMail)
    {
        UIManager.instance.ShowSentMail(ownerName.ToString(), nbMail);
    }


    public void ShowDraftMail(int nbMail)
    {
        UIManager.instance.ShowDraftMail(ownerName.ToString(), nbMail);
    }

    public override void ClickWhileInteracting()
    {
    }
}
