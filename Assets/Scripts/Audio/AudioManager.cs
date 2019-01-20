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
            }
        }
    }

    public void FadeIn(string name, int maxVolume, float FadeTime)
    {
        foreach (AudioSource s in sources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartFadeIn(s, maxVolume, FadeTime));
            }
        }
    }

    private IEnumerator StartFadeIn(AudioSource source, int maxVolume, float FadeTime)
    {
        float startVolume = source.volume;

        while (source.volume < maxVolume)
        {
            source.volume += 1 * Time.deltaTime / FadeTime;

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
}