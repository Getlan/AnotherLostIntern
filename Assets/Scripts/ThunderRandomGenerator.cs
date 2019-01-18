using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandomGenerator : MonoBehaviour
{
    private Animator anim;
    private int random;
    private float waitTime=3f;
    private float timer =0;
    private bool canTrigger = true;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canTrigger)
        {
            random = Random.Range(0, 100);
            if(random <= 5)
            {
                anim.SetTrigger("isThunder");
                canTrigger = false;
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
