using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    public AudioSource[] sources;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void Play(string name)
    {
        foreach (AudioSource s in sources){
            if(s.name == name)
            {
                s.Play();
            }
        }
    }

    // Update is called once per frame
    public void Stop(string name)
    {
        foreach (AudioSource s in sources)
        {
            if (s.name == name)
            {
                s.Stop();
            }
        }
    }
}
