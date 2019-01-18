using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextFromObject
{
    public enum ObjectName { Badge};
    [SerializeField] public ObjectName objectName;
    public string title;
    [TextArea(3, 10)]
    public string text;
}
