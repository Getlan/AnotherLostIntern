using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartbeatTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.Play("Heartbeat");
            AudioManager.instance.FadeIn("Heartbeat", 0.5f, 5);
        }
    }
}
