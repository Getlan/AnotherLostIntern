using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    private int currentStep = 0;

    private bool step1MailChecked = false;
    private bool step1PasswordSeen = false;

    public bool tutoSkip = false; 

    [SerializeField] bool skipIntro = false;

    public static StepManager instance = null;

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

    // Start is called before the first frame update
    void Start()
    {
        Hashtable iTweenArgs;
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", new Vector3(0, 0.74f, 0));
        iTweenArgs.Add("rotation", GameManager.Gm.PlayerCamera.transform.rotation);
        iTweenArgs.Add("time", 0f);
        iTweenArgs.Add("isLocal", true);
        iTween.MoveTo(GameManager.Gm.PlayerCamera.transform.gameObject, iTweenArgs);
        AudioManager.instance.Play("Thunder");
        if (!skipIntro)
        {
            Invoke("Intro", 2);
            GameManager.Gm.CanRotate = false;
            GameManager.Gm.CanInteract = false;
        }
    }

    void Update()
    {

        if(tutoSkip == true)
        {
            step1MailChecked = true;
            step1PasswordSeen = true;
            CheckStep1();
        }

        if (currentStep == 0)
        {
            GameManager.Gm.CanMove = false;
        }
    }

    private void Intro()
    {
        AudioManager.instance.Play("Phone");
        UIManager.instance.ShowGameTitle();
        Invoke("EndIntro", 10);
    }

    private void EndIntro()
    {
        UIManager.instance.HideGameTitle();
        GameManager.Gm.CanRotate = true;
        GameManager.Gm.CanInteract = true;

    }

    public void DoStep1MailChecked()
    {
        step1MailChecked = true;
        CheckStep1();
    }

    public void DoStep1PasswordSeen()
    {
        step1PasswordSeen = true;
        CheckStep1();
    }

    private void CheckStep1()
    {
        if (currentStep == 0 && step1MailChecked && step1PasswordSeen)
        {
            currentStep++;
            Hashtable iTweenArgs;
            iTweenArgs = iTween.Hash();
            iTweenArgs.Add("position", new Vector3(0, 1.5f, 0));
            iTweenArgs.Add("rotation", GameManager.Gm.PlayerCamera.transform.rotation);
            iTweenArgs.Add("time", 2.5f);
            iTweenArgs.Add("isLocal", true);
            iTween.MoveTo(GameManager.Gm.PlayerCamera.transform.gameObject, iTweenArgs);
            GameManager.Gm.CanMove = true;
        }
    }

    private void Step1()
    {
        GameManager.Gm.CanMove = true;
    }

}
