using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiamMiamScript : MonoBehaviour
{
    public Transform m_observedPoint;
    public Transform m_playerHead;
    public float m_distanceToEat=0.3f;
    public float m_checkDelay=0.5f;
    public UnityEvent m_startEating;
    public UnityEvent m_stopEating;
    [Header("Debug")]
    public bool m_isEating;
    void Start()
    {
        InvokeRepeating("CheckForHeadCollision", 0, m_checkDelay);
    }

    public void CheckForHeadCollision()
    {
        if (m_playerHead == null) {
            bool found;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyesCenter, out found, out m_playerHead);
        }
        if (m_playerHead == null)
            return;
        
            bool previousEating= m_isEating;
        m_isEating = Vector3.Distance(m_playerHead.position, m_observedPoint.position)< m_distanceToEat;
        if (previousEating != m_isEating) {
            if (m_isEating)
            {
                m_startEating.Invoke();
            }
            else
            {
                m_stopEating.Invoke();
            }
        }
    }

    private void Reset()
    {
        m_observedPoint = transform;
    }
}
