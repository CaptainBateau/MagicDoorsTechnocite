using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    public float m_startInvoke;
    public ClapShader m_shaderTrigger;
    public AudioSource m_source;
    public AudioClip m_clip;

    public void ZAWARUDOOOO()
    {
        m_source.clip = m_clip;
        m_source.Play();
        Invoke("StopTime", m_startInvoke);
    }

    void StopTime()
    {
        m_shaderTrigger.ChangeShaderRequestAction();
    }
}
