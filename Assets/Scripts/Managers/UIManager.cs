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
    private GameObject UIGillesComputer;
    [SerializeField]
    private ObjectTextUI textObjectUI;

    public static UIManager instance = null;

    private void Start()
    {
        computerDictionnary.Add("AntoineG", UIAntoineComputer);
        computerDictionnary.Add("Nathalie", UINathalieComputer);
        computerDictionnary.Add("Gilles", UIGillesComputer);
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

    public void DisplayObjectText(string objectName)
    {
        textObjectUI.DisplayText(objectName);
    }

    public void HideObjectText()
    {
        textObjectUI.HideText();
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
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/InBox/IconOff").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/InBox/IconOn").gameObject.SetActive(true);
    }

    public void ShowSent(string ownerName)
    {
        HideAllMailsInList(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList/ScrollSent").gameObject.SetActive(true);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Sent/IconOff").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Sent/IconOn").gameObject.SetActive(true);
    }

    public void ShowDraft(string ownerName)
    {
        HideAllMailsInList(ownerName);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList/ScrollDraft").gameObject.SetActive(true);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Draft/IconOff").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Draft/IconOn").gameObject.SetActive(true);
    }

    private void HideAllMailsInList(string ownerName)
    {
        foreach (Transform child in computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/MailList").transform)
        {
            child.gameObject.SetActive(false);
        }
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/InBox/IconOn").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Sent/IconOn").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Draft/IconOn").gameObject.SetActive(false);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/InBox/IconOff").gameObject.SetActive(true);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Sent/IconOff").gameObject.SetActive(true);
        computerDictionnary[ownerName].transform.Find("DesktopPanel/Mails/MailingBox/Select/Draft/IconOff").gameObject.SetActive(true);
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
