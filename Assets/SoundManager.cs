using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource drone_1;
    public AudioSource drone_2;
    public AudioSource drone_3;
    public AudioSource heartbeatSound;

    [SerializeField]
    private bool drone2 = false;
    [SerializeField]
    private bool heartbeat = false;
    [SerializeField]
    private bool drone3 = false; 

    // Start is called before the first frame update
    void Start()
    {
        drone_1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(drone2 == true)
        {
            StartCoroutine(FadeIn(drone_2, 0.3f, 5f));
          
        }

        if(heartbeat == true)
        {
            StartCoroutine(FadeIn(heartbeatSound, 1f, 2f));
    
        }

        if(drone3 == true)
        {
            StartCoroutine(FadeIn(drone_3, 1f, 10f));
     
        }
    }

    IEnumerator FadeIn(AudioSource audioSource, float volume, float duration)
    {
        while(audioSource.volume < volume)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null; 
        }
    }
}
