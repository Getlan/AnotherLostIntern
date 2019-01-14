using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject interactCaption;
    Dictionary<string, GameObject> computerDictionnary = new Dictionary<string, GameObject>();
    [SerializeField]
    private GameObject UIAntoineComputer;
    [SerializeField]
    private GameObject UINathalieComputer;
    [SerializeField]
    private GameObject mailsAntoineUI;
    [SerializeField]
    private GameObject newsAntoineUI;

    public static UIManager instance = null;

    private void Start()
    {
        computerDictionnary.Add("AntoineG", UIAntoineComputer);
        computerDictionnary.Add("Nathalie", UINathalieComputer);
    }

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

    public void ShowGameTitle()
    {
        transform.Find("GameTitle").gameObject.SetActive(true);
    }

    public void HideGameTitle()
    {
        transform.Find("GameTitle").gameObject.SetActive(false);
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

    public void ShowUIComputer(string ownerName)
    {
        computerDictionnary[ownerName].SetActive(true);
    }

    public void HideUIComputer(string ownerName)
    {
        computerDictionnary[ownerName].SetActive(false);
    }

    public void UnlockComputer(string ownerName)
    {
      computerDictionnary[ownerName].transform.Find("LoginPanel").gameObject.SetActive(false);
      computerDictionnary[ownerName].transform.Find("DesktopPanel").gameObject.SetActive(true);
    }

    public void ShowNews(string ownerName)
    {
        HideAllApps(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/News").gameObject.SetActive(true);
    }

    public void ShowMails(string ownerName)
    {
        HideAllApps(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails").gameObject.SetActive(true);
    }

    public void ShowInBoxMail(string ownerName)
    {
        char childNumber = ownerName[ownerName.Length - 1];
        int childNumberInt = (int)Char.GetNumericValue(childNumber);
        ownerName = ownerName.Substring(0, ownerName.Length - 1);
        HideAllInBoxMails(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail/InBox").transform.GetChild(childNumberInt).gameObject.SetActive(true);
    }

    public void HideAllInBoxMails(string ownerName)
    {
        foreach (Transform child in computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail/InBox").transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void HideAllApps(string ownerName)
    {
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/News").gameObject.SetActive(false);
    }
}
