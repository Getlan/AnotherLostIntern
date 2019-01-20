using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMusic : MonoBehaviour
{

    public IEnumerator FadeIn(AudioSource audioSource, float maxVolume, float FadeInTime)
    {
        while(audioSource.volume < maxVolume)
        {
            audioSource.volume = audioSource.volume + (Time.deltaTime / (FadeInTime + 1));
            yield return null; 
        }
    }
}
