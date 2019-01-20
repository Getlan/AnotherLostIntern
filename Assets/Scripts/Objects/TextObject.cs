using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    bool isDisplayed = false;
    private bool canDisplay = false;
    string textName = "";

    public bool CanDisplay
    {
        get
        {
            return canDisplay;
        }

        set
        {
            canDisplay = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ReadText") && this.GetComponent<NoStateObject>().IsInteracting && canDisplay)
        {
            if (!isDisplayed)
            {
                UIManager.instance.DisplayObjectText(textName);
                isDisplayed = true;
            }
            else
            {
                UIManager.instance.HideObjectText();
                isDisplayed = false;
            }
        }
        else if(isDisplayed && (Input.GetButtonDown("MainAction") || !this.GetComponent<NoStateObject>().IsInteracting)){
            UIManager.instance.HideObjectText();
            isDisplayed = false;
        }
    }

    public void ChangeTextToRead(string textName)
    {
        if (textName != "")
        {
            canDisplay = true;
        }
        else {
            canDisplay = false;
        }
        this.textName = textName;
    }
}
