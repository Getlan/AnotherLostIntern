using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordHandler : MonoBehaviour
{
    [SerializeField] private InputField passwordField;
    [SerializeField] private Computer computer;

    public void HandlePassword()
    {
        computer.CheckPassword(passwordField.text);

        Debug.Log(StepManager.instance.CurrentStep);

        if(StepManager.instance.CurrentStep == 0 && computer.CheckPassword(passwordField.text))
        {
            StepManager.instance.StartGame();
        }
    }
}
