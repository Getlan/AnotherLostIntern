﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ObjectWithPause
{
    [SerializeField] private OwnerName ownerName;
    private enum OwnerName { AntoineG, Nathalie };
    [SerializeField] private string password;
    [SerializeField] private bool unlocked;

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
        if(this.IsInteracting && Input.GetButton("MainAction"))
        {
            AudioManager.instance.Play("Mouse_click");
        }
        
    }

    public override void Interact()
    {
        base.Interact();
        UIManager.instance.ShowUIComputer(ownerName.ToString());
        GameManager.Gm.IsInteractingWithComputer = true;
    }

    public override void StopInteract()
    {
        base.StopInteract();
        UIManager.instance.HideUIComputer(ownerName.ToString());
        GameManager.Gm.IsInteractingWithComputer = false;
    }

    public void CheckPassword(string passwordToTest)
    {
        if (passwordToTest == password)
        {
            Unlocked = true;
            UIManager.instance.UnlockComputer(ownerName.ToString());
        }
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
