using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLibrary : MonoBehaviour
{
    private bool open = false;
    [SerializeField] private Vector3 positionClose, positionOpen;
    [SerializeField] private float animationTime;
    private Hashtable iTweenArgs;

    public bool Open
    {
        get
        {
            return open;
        }

        set
        {
            open = value;
        }
    }

    protected void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", positionOpen);
        iTweenArgs.Add("rotation", positionOpen);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("isLocal", true);
    }

    public void OpenSecretPassage()
    {
        open = true;
        iTween.MoveTo(this.gameObject, iTweenArgs);
        iTweenArgs["position"] = positionClose;
        //[AUDIO] son ouverture
    }

    public void CloseSecretPassage()
    {
        open = false;
        iTween.MoveTo(this.gameObject, iTweenArgs);
        iTweenArgs["position"] = positionOpen;
        //[AUDIO] son fermeture
    }
}
