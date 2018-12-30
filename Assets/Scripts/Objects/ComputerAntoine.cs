using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAntoine : Computer {

    [SerializeField]
    private GameObject mailsUI;
    [SerializeField]
    private GameObject newsUI;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
    }

    public void showNews()
    {
        mailsUI.SetActive(false);
        newsUI.SetActive(true);
    }

    public void showMails()
    {
        newsUI.SetActive(false);
        mailsUI.SetActive(true);
    }
}
