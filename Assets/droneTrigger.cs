using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.Play("Drone_3");
            AudioManager.instance.FadeIn("Drone_3", 0.02f, 15);
            Debug.Log("trigger");
        }
    }
}
