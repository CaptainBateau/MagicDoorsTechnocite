using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRToTeleport : MonoBehaviour
{
    public Teleportation _teleportation;
    public OVRInput.Button _teleportButton;


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(_teleportButton))
        {
            _teleportation.StartTeleport();
        }
        if (OVRInput.GetUp(_teleportButton))
        {
            _teleportation.StopTeleport();
        }
    }
}