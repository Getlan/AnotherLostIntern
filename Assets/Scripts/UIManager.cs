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
