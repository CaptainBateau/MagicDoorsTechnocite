using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetForceForwardTargetWithVR : MonoBehaviour
{
    public AddForceForwardTarget m_forceAdd;
    public VirtualRealityClassicTags m_whatToFollow;

    void Start()
    {
        if (m_forceAdd.m_target == null) { 
            bool found = false;
            VirtualRealityTags.GetClassicVrTag(m_whatToFollow, out found, out m_forceAdd.m_target);
        }
        
    }

}
