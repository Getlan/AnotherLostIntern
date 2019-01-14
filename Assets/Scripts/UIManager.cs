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

    /*
    * Game
    */

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

    /*
    * Computer
    */
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

    public void ShowNewsApp(string ownerName)
    {
        HideAllApps(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/News").gameObject.SetActive(true);
    }

    public void ShowMailsApp(string ownerName)
    {
        HideAllApps(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails").gameObject.SetActive(true);
    }

    private void HideAllApps(string ownerName)
    {
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/News").gameObject.SetActive(false);
    }

    /*
     * Mails
     */

    public void ShowInBox(string ownerName)
    {
        HideAllMailsInList(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList/ScrollInBox").gameObject.SetActive(true);
    }

    public void ShowSent(string ownerName)
    {
        HideAllMailsInList(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList/ScrollSent").gameObject.SetActive(true);
    }

    public void ShowDraft(string ownerName)
    {
        HideAllMailsInList(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList/ScrollDraft").gameObject.SetActive(true);
    }

    private void HideAllMailsInList(string ownerName)
    {
        foreach (Transform child in computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList").transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void ShowInBoxMail(string ownerName, int nbMail)
    {
        HideAllMailDetails(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail/InBox").transform.GetChild(nbMail).gameObject.SetActive(true);
    }

    public void ShowSentMail(string ownerName, int nbMail)
    {
        HideAllMailDetails(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail/Sent").transform.GetChild(nbMail).gameObject.SetActive(true);
    }


    public void ShowDraftMail(string ownerName, int nbMail)
    {
        HideAllMailDetails(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail/Draft").transform.GetChild(nbMail).gameObject.SetActive(true);
    }

    private void HideAllMailDetails(string ownerName)
    {
        foreach (Transform child1 in computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailDetail").transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                child2.gameObject.SetActive(false);
            }
        }
    }
}
