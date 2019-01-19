using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    bool isDisplayed = false;
    [SerializeField] NoStateObject interactiveObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ReadText") && interactiveObject.IsInteracting)
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
        else if(isDisplayed && (Input.GetButtonDown("MainAction") || !interactiveObject.IsInteracting)){
            UIManager.instance.HideObjectText();
            isDisplayed = false;
        }
    }
}
