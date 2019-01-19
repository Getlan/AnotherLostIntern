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
    }
}
