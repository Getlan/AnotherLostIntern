using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexObservable : Observable
{
    [SerializeField] private GameObject zoneToClick;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isInteracting && Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 10f))
            {
                if(hit.transform != null && hit.transform.gameObject == zoneToClick)
                {
                    ActivateComplexZone();
                }
            }
        }
    }

    private void ActivateComplexZone()
    {
        iTween.ShakePosition(this.gameObject,new Vector3(0.01f, 0.01f, 0.01f),0.6f);
    }
}
