using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject interactCaption;
    [SerializeField]
    private GameObject UIAntoineComputer;
    [SerializeField]
    private GameObject mailsAntoineUI;
    [SerializeField]
    private GameObject newsAntoineUI;

    public static UIManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowInteractCaption()
    {
        interactCaption.SetActive(true);
    }

    public void HideInteractCaption()
    {
        interactCaption.SetActive(false);
    }

    public void ChangeTextInteractCaption(string newText)
    {
        interactCaption.GetComponent<Text>().text = newText;
    }

    public void ShowUIAntoine()
    {
        UIAntoineComputer.SetActive(true);
    }

    public void HideUIAntoine()
    {
        UIAntoineComputer.SetActive(false);
    }

    public void ShowNewsAntoine()
    {
        mailsAntoineUI.SetActive(false);
        newsAntoineUI.SetActive(true);
    }

    public void ShowMailsAntoine()
    {
        newsAntoineUI.SetActive(false);
        mailsAntoineUI.SetActive(true);
    }
}
