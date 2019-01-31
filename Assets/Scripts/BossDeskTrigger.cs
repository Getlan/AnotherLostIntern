using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeskTrigger : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!activated && other.CompareTag("Player"))
        {
            StepManager.instance.EnterBossDesk();
            activated = true;
        }
    }
}
