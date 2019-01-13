using System.Collections;
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

    public override void ClickWhileInteracting()
    {
    }
}
