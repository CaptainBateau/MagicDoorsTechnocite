using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusToCheatcode : MonoBehaviour
{
    //public Grab _grab;

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Debug.Log("Jacky");
    //        _grab.SetGrab();
    //    }
    //    if (Input.GetButtonUp("Fire1"))
    //    {
    //        Debug.Log("Michel");
    //        _grab.SetGrab(false);
    //    }
    //}

    public DebugMagicRoomCheatCode m_cheatCode;

    private float m_switchRoomDelay;
    public float m_timeBetweenSwitchRoom=0.5f;
    private void Start()
    {
        m_cheatCode.SetScreamerFPS(false);
    }

    void Update()
    {
        if (m_switchRoomDelay >= 0f) 
        m_switchRoomDelay -= Time.deltaTime;



        float rightTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float leftTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        float rightGrab = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        float leftGrab = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);



        m_cheatOn = OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two);
        if (m_cheatOn) 
        {
            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                m_cheatCode.SetLoaderToAllParticipants();
            }
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                m_cheatCode.SwitchLightOnOff();
            }
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                m_cheatCode.SwitchJimmyScreamerAndTexts();
            }


            Vector2 vl2 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            if (m_switchRoomDelay<0f && vl2.x > 0.8f)
            {
                m_switchRoomDelay = m_timeBetweenSwitchRoom;
                m_cheatCode.LoadAnOtherRoomInZoneA();
            }
            else if (m_switchRoomDelay < 0f && vl2.x < -0.8f)
            {

                m_switchRoomDelay = m_timeBetweenSwitchRoom;
                m_cheatCode.LoadAnOtherRoomInZoneB();
            }
            
            if (vl2.y > 0.8f)
            {

            }
            if (vl2.y < -0.8f)
            {

            }
            Vector2 vr2 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            if (vr2.x > 0.8f)
            {
                m_cheatCode.SetJimmyFPSToHight();
            }
            if (vr2.x < -0.8f)
            {
                m_cheatCode.SetJimmyFPSToLow();
            }
            if (vr2.y > 0.8f)
            {
                m_cheatCode.SetJimmyFPSToMedium();
            }
            if (vr2.y < -0.8f)
            {

            }



            if (rightTrigger > 0.5f)
            {
                m_cheatCode.SetHandOnOff(true);
                m_cheatCode.SpawnObjectInSceneForDebugging();
            }
            if (leftTrigger > 0.5f)
            {

                m_cheatCode.SetHandOnOff(false);
                m_cheatCode.SpawnObjectInSceneForDebugging();
            }
            if (rightGrab > 0.5f)
            {

                m_cheatCode.SpawnObjectInSceneForDebugging();
            }
            if (leftGrab > 0.5f)
            {

                m_cheatCode.SpawnObjectInSceneForDebugging();
            }

        }


        //if (Input.GetKeyDown(KeyCode.KeypadMinus))
        //{
        //    m_cheatCode.SetOnOffRoomA();
        //}
        //if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        //{
        //    m_cheatCode.SetOnOffRoomB();
        //}
        //if (Input.GetKeyDown(KeyCode.KeypadDivide))
        //{
        //    m_cheatCode.SetOnOffDoorDebugJoinHighlight();
        //}
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            m_cheatCode.SpawnObjectInSceneForDebugging();
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            m_cheatCode.SpawnObjectInSceneForDebugging();
        }

        if (m_cheatOn != m_cheatOnPrevious)
        {
           m_cheatCode.NotifyCheatOnOff(m_cheatOn);
        }
        m_cheatOnPrevious = m_cheatOn;
    }
    private bool m_cheatOnPrevious;
    private bool m_cheatOn;
}