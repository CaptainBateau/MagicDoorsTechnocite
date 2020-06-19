using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOVR : MonoBehaviour
{
    public Grab _grab;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            Debug.Log("Jacky");
            _grab.SetGrab();
        }
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            Debug.Log("Michel");
            _grab.SetGrab(false);
        }
    }
    
}
