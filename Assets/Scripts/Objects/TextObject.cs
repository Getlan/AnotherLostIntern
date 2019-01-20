using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    bool isDisplayed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ReadText") && this.GetComponent<NoStateObject>().IsInteracting)
        {
            if (!isDisplayed)
            {
                UIManager.instance.DisplayObjectText(this.gameObject.name);
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
}
