using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTextUI : MonoBehaviour
{
    [SerializeField] private Text titleHolder;
    [SerializeField] private Text textHolder;
    [SerializeField] public TextFromObject[] textArray;

    public void DisplayText(string objectName)
    {
        this.gameObject.SetActive(true);
        foreach (TextFromObject obj in textArray)
        {
            if (obj.objectName.ToString() == objectName)
            {
                titleHolder.text = obj.title;
                textHolder.text = obj.text;
                break;
            }
        }
    }

    public void HideText()
    {
        titleHolder.text = "";
        textHolder.text = "";
        this.gameObject.SetActive(false);
    }
}
