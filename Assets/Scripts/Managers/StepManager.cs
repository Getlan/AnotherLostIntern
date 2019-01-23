using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    private int currentStep = 0;

    private bool tutoMailChecked = false;
    private bool tutoScoutCardSeen = false;
    private bool endActivated = false;

    [SerializeField] private Computer computerAntoine;

    [SerializeField] private bool tutoSkip = false;
    [SerializeField] private bool menuSkip = false;

    [SerializeField] BossDoor bossDoor;
    private bool drawer1 = false;
    private bool drawer2 = false;
    [SerializeField] private BossLibrary library;
    [SerializeField] private Material bloodStain;
    [SerializeField] private Material bible;
    [SerializeField] private Material vertus1;
    [SerializeField] private Material vertus2;
    [SerializeField] private Material planetaire;
    [SerializeField] private Material postIt;

    [SerializeField] private GameObject subtitleCanvas;
    private AudioSource radioAudioSource;
    [SerializeField] private AudioClip[] radio_voice;
    [SerializeField] string[] radioLines;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject endManagerUI;

    [SerializeField] private Button answerButton;

    private bool isPlayingRadio = false;

    public static StepManager instance = null;

    private int hints = 0; 

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
        UIManager.instance.FillDictionnary();
        if (menuSkip)
        {
            currentStep++;
        }
        else
        {
            Menu();
        }
        if (tutoSkip)
        {
            tutoMailChecked = true;
            tutoScoutCardSeen = true;
            CheckTuto();
        }
        radioAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentStep == 0 || currentStep == 1)
        {
            GameManager.Gm.CanMove = false;
            //GameManager.Gm.CanInteract = false;
            //GameManager.Gm.CanRotate = false;
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
    }

    public void EnterBossDesk()
    {
        AudioManager.instance.Play("Door_slam");
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
        if (!library.Open && drawer1 && drawer2)
        {
            library.OpenSecretPassage();
            AudioManager.instance.Play("Rail");
        }
        else if (library.Open && !drawer1 && !drawer2)
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
        AudioManager.instance.Play("Boom");
        endManagerUI.SetActive(true);


        while (AudioManager.instance.sources[7].isPlaying)
        {
            yield return null;
        }

        StartCoroutine(PlayRadioVoice());
        while (isPlayingRadio == true)
        {
            yield return null;
        }
        credits.SetActive(true);
        AudioManager.instance.Play("Theme_fin");
    }


    public void End()
    {
        if (!endActivated)
        {
            StartCoroutine(EndGame());
            endActivated = true;
        }
    }

    public void Menu()
    {
        AudioManager.instance.Play("Theme_début");
        computerAntoine.Interact();
    }

    public void StartGame()
    {
        currentStep++;
        AudioManager.instance.FadeOut("Theme_début", 10f);
        GameManager.Gm.CursorIsLocked = false;
        GameManager.Gm.IsInteractingWithComputer = true;
        GameManager.Gm.CanInteract = true;
        GameManager.Gm.CanRotate = true;
    }

    public void GlowObjects(float value)
    {
        bloodStain.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
        bible.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
        vertus1.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
        vertus2.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
        planetaire.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
        postIt.SetVector("_EmissionColor", new Color(0.7490196f, 0.7490196f, 0.7490196f, 1f) * value);
    }

    public void PlayMumDialog(AudioClip[] mumDialogClips,string[] mumDialogLines,AudioSource audioSource)
    {
        StartCoroutine(PlayMumDialogCoroutine(mumDialogClips, mumDialogLines, audioSource));
    }

    IEnumerator PlayMumDialogCoroutine(AudioClip[] mumDialogClips, string[] mumDialogLines, AudioSource audioSource)
    {
        for (int i = 0; i < 2; i++)
        {
            UIManager.instance.PrintSubtitles(mumDialogLines[i]);
            audioSource.PlayOneShot(mumDialogClips[i]);
            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }

        UIManager.instance.PrintSubtitles(mumDialogLines[3]);
        audioSource.PlayOneShot(mumDialogClips[3]);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        answerButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        answerButton.gameObject.SetActive(false);
        UIManager.instance.PrintSubtitles(mumDialogLines[4]);
        audioSource.PlayOneShot(mumDialogClips[4]);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        answerButton.transform.GetChild(0).gameObject.SetActive(false);
        answerButton.transform.GetChild(1).gameObject.SetActive(true);
        answerButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        answerButton.gameObject.SetActive(false);
        for (int i =5; i < mumDialogLines.Length; i++)
        {
            UIManager.instance.PrintSubtitles(mumDialogLines[i]);
            audioSource.PlayOneShot(mumDialogClips[i]);
            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }
        UIManager.instance.PrintSubtitles("");
    }

    IEnumerator PlayRadioVoice()
    {

        isPlayingRadio = true;
        for (int i = 0; i < radio_voice.Length; i++)
        {
            UIManager.instance.PrintSubtitles(radioLines[i]);
            radioAudioSource.PlayOneShot(radio_voice[i]);
            while (radioAudioSource.isPlaying)
            {
                yield return null;
            }
        }
        UIManager.instance.PrintSubtitles("");
        isPlayingRadio = false;
    }

    public void CountClue()
    {
        hints += 1;
        PlayClue();
    }

    private void PlayClue()
    {
        if(hints == 1)
        {
            AudioManager.instance.Play("Indices_1");
        }
        if (hints == 2)
        {
            AudioManager.instance.Play("Indices_2");
        }
        if (hints == 3)
        {
            AudioManager.instance.Play("Indices_3");
        }
    }
}
