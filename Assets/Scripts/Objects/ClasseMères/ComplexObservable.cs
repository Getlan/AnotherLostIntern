using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ComplexObservable : Observable
{
    [SerializeField] protected GameObject zoneToClick;

    public override void ClickWhileInteracting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform != null && hit.transform.gameObject == zoneToClick)
            {
                ActivateComplexZone();
            }
            else if (hit.transform == null || hit.transform.gameObject != this.gameObject)
            {
                StopInteract();
            }
        }
        else
        {
            StopInteract();
        }
    }

    abstract protected void ActivateComplexZone();
}
