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

    void Update()
    {
        if(theme.volume <= 0)
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    public void gameStart()
    {
        canvas.enabled = false;
        AudioManager.instance.FadeOut("Theme_début", 10f);
    }

}
