using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRToGrab : MonoBehaviour
{
    public MultiGrab _grab;

    public OVRInput.Button _grabButton;


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(_grabButton))
        {
            _grab.SetGrab();
        }
        if (OVRInput.GetUp(_grabButton))
        {
            _grab.SetGrab(false);
        }
    }
}
