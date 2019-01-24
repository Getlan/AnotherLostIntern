using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrawer : StateObject
{
    [SerializeField] private int nbDrawer;

    public override void Interact()
    {
        base.Interact();
        if (isState2)
        {
            if (nbDrawer == 1)
            {
                StepManager.instance.Drawer1Open();
            }
            else if (nbDrawer == 2)
            {
                StepManager.instance.Drawer2Open();
            }
        }
        else
        {
            if (nbDrawer == 1)
            {
                StepManager.instance.Drawer1Close();
            }
            else if (nbDrawer == 2)
            {
                StepManager.instance.Drawer2Close();
            }
        }
    }

}
