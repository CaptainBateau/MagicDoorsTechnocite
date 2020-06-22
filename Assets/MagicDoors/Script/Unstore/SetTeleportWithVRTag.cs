using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTeleportWithVRTag : MonoBehaviour
{
    public Teleportation m_teleportationLinked;
    public SideType m_type;
    

    void Start()
    {
        
    }

   
    void Update()
    {
        if (m_teleportationLinked.m_userHead == null)
        {
            bool found;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.Head,
                out found,   out m_teleportationLinked.m_userHead);
        }
        if (m_teleportationLinked.m_userHead == null)
        {
            bool found;
            VirtualRealityTags.GetClassicVrTag(
                m_type==SideType.Left?VirtualRealityClassicTags.ControllerLeft: VirtualRealityClassicTags.ControllerLeft,
                out found,  out m_teleportationLinked.m_userHead);
        }

    }
}
