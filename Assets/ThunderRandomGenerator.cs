using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandomGenerator : MonoBehaviour
{

    private Animator anim;

    [SerializeField]
    private int random;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 100); 

        if(random <= 5)
        {
            anim.SetTrigger("isThunder");

        }


    }
}
