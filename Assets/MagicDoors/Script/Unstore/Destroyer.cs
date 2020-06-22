using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{

    public UnityEvent m_onDevDestroyRequest;
    public UnityEvent m_callBeforeOnDestroy;

    public void TriggerDestruction(float callDelay)
    {
        Invoke("TriggerDestruction", callDelay);

    }
    public void TriggerDestruction()
    {
        m_onDevDestroyRequest.Invoke();
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        m_callBeforeOnDestroy.Invoke();


    }



}
