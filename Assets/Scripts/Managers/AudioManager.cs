using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        foreach (AudioSource s in sources)
        {
            if (s.name == name)
            {
                s.Play();
                break;
            }
        }
    }

    public void FadeIn(string name, float maxVolume, float FadeTime)
    {
        foreach (AudioSource s in sources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartFadeIn(s, maxVolume, FadeTime));
                break;
            }
        }
    }

    private IEnumerator StartFadeIn(AudioSource source, float maxVolume, float FadeTime)
    {
        float startVolume = source.volume;

        while (source.volume < maxVolume)
        {
            source.volume += 1 * Time.deltaTime / FadeTime;

            yield return null;
        }
    }

    public void FadeOut(string name, float FadeTime)
    {
        foreach (AudioSource s in sources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartFadeOut(s, FadeTime));
            }
        }
    }

    private IEnumerator StartFadeOut(AudioSource source, float FadeTime)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        //source.Stop();
        //source.volume = startVolume;
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

    public bool CheckEndGame()
    {
        if(sources[0].volume <= 0 && sources[1].volume <= 0 && sources[2].volume <= 0 && sources[3].volume <= 0)
        {
            return true; 
        }
        return false; 
    }
}