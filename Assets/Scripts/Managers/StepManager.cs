using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    private int currentStep = 0;

    private bool tutoMailChecked = false;
    private bool tutoScoutCardSeen = false;
    private bool endActivated = false; 

    public bool tutoSkip = false;

    public Animator textAnim;
    public GameObject endManagerUI; 

    [SerializeField] BossDoor bossDoor;
    private bool drawer1=false;
    private bool drawer2=false;
    [SerializeField] BossLibrary library;

    public static StepManager instance = null;

    public int CurrentStep
    {
        get
        {
            return currentStep;
        }

        set
        {
            currentStep = value;
        }
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

        AudioManager.instance.Play("Drone_1");
        AudioManager.instance.Play("Theme_début");

        if (tutoSkip)
        {
            tutoMailChecked = true;
            tutoScoutCardSeen = true;
            CheckTuto();
        }
    }

    void Update()
    {
        if (currentStep == 0 || currentStep == 1)
        {
            GameManager.Gm.CanMove = false;
        }
    }

    public void DoTutoMailChecked()
    {
        tutoMailChecked = true;
        CheckTuto(); 
    }

    public void DoTutoScoutCardSeen()
    {
        tutoScoutCardSeen = true;
        CheckTuto();
    }

    private void CheckTuto()
    {
        if (currentStep == 1 && tutoMailChecked && tutoScoutCardSeen)
        {
            AudioManager.instance.Play("PhoneRingtone");
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

    public void UnlockBossDoor()
    {
        bossDoor.UnlockDoor();
        //[AUDIO] unlock door
    }

    public void EnterBossDesk()
    {
        AudioManager.instance.Play("Heartbeat");
        AudioManager.instance.FadeIn("Heartbeat", 0.6f, 5);
        bossDoor.SlamDoor();
    }

    public void EnterSecretRoom()
    {
        AudioManager.instance.Play("Drone_3");
        AudioManager.instance.FadeIn("Drone_3", 0.2f, 15);
    }

    public void Drawer1Open()
    {
        this.drawer1 = true;
        CheckSecretLibrary();
    }

    public void Drawer1Close()
    {
        this.drawer1 = false;
        CheckSecretLibrary();
    }

    public void Drawer2Open()
    {
        this.drawer2 = true;
        CheckSecretLibrary();
    }

    public void Drawer2Close()
    {
        this.drawer2 = false;
        CheckSecretLibrary();
    }

    private void CheckSecretLibrary()
    {
        if(!library.Open && drawer1 && drawer2)
        {
            library.OpenSecretPassage();
        }
        else if(library.Open && !drawer1 && !drawer2)
        {
            library.CloseSecretPassage();
        }
    }

    private IEnumerator EndGame()
    {
        AudioManager.instance.FadeOut("Drone_1", 5f);
        AudioManager.instance.FadeOut("Drone_2", 5f);
        AudioManager.instance.FadeOut("Drone_3", 5f);
        AudioManager.instance.FadeOut("Heartbeat", 5f);

        while (AudioManager.instance.CheckEndGame() != true)
        {
            yield return null;
        }

        Debug.Log("check end game true ");
        AudioManager.instance.Play("Boom");
        endManagerUI.SetActive(true);
        textAnim.SetTrigger("End");

        yield return new WaitForSeconds(4f);

        AudioManager.instance.Play("Radio");
    }

    public void End()
    {
        if (!endActivated)
        {
            StartCoroutine(EndGame());
            endActivated = true;
        }
    }

    public void StartGame()
    {
        currentStep += 1;
        AudioManager.instance.FadeOut("Theme_début", 10f);
    }
}
