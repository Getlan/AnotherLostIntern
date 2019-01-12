using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class passwordInput : MonoBehaviour
{

    public InputField password;
    public GameObject passwordSpace; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(password.text == "password")
        {
            passwordSpace.SetActive(false); 
        }
    }
}
