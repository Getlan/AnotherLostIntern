using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextFromObject
{
    public enum ObjectName { Carnet1,Carnet2,Bible,CarteAnniversaire,CarteScout1, CarteScout2, CarteScout3,Vertus1,Vertus2,PostItEnigme};
    [SerializeField] public ObjectName objectName;
    public string title;
    [TextArea(3, 10)]
    public string text;
    public float fontSize = 50;
}
