using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Canvas canvas;
    public AudioSource theme;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Theme_début");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameStart()
    {
        canvas.enabled = false;
        AudioManager.instance.FadeOut("Theme_début", 10f);
    }

    /*public IEnumerator FadeOutTheme(AudioSource source, float FadeTime))
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume* Time.deltaTime / FadeTime;

            yield return null;
        }
    }*/

    /*public IEnumerator FadeOutTheme(AudioSource source, float FadeTime)
    {
        float startVolume = source.volume; 

        while(source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null; 
        }
    }*/
}
