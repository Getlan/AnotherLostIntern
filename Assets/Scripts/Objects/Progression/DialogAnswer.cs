using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnswer : MonoBehaviour
{
    public void Click(){
        this.gameObject.SetActive(false);
        AudioManager.instance.Play("Interference");
    }
}
