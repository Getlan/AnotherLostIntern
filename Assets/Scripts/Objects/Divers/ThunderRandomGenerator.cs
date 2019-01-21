using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandomGenerator : MonoBehaviour
{
    public Animator thunderAnim;
    public Animator windowAnim; 
    private int random;
    private float waitTime=15f;
    private float timer= 0f;
    private bool canTrigger = true;

    private float sfxTimer = 0f; 
    public AudioSource thunderSfx; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canTrigger)
        {
            random = Random.Range(0, 100);
            if(random <= 5)
            {
                thunderAnim.SetTrigger("Thunder");
                windowAnim.SetTrigger("Thunder");
                canTrigger = false;
                thunderSfx.Play();

            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                timer = 0;
                canTrigger = true;
            }
        }
    }
}
