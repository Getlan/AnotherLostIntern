using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    private int currentStep = 0;

    private bool tutoMailChecked = false;
    private bool tutoScoutCardSeen = false;

    public bool tutoSkip = false;

    [SerializeField] BossDoor bossDoor;

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

        AudioManager.instance.Play("Drone_1");

        if (tutoSkip)
        {
            tutoMailChecked = true;
            tutoScoutCardSeen = true;
            CheckTuto();
        }
    }

    void Update()
    {
        if (currentStep == 0)
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
        if (currentStep == 0 && tutoMailChecked && tutoScoutCardSeen)
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
        AudioManager.instance.FadeIn("Heartbeat", 0.5f, 5);
        bossDoor.SlamDoor();
    }

    public void EnterSecretRoom()
    {
        AudioManager.instance.Play("Drone_3");
        AudioManager.instance.FadeIn("Drone_3", 0.1f, 15);
    }
}
