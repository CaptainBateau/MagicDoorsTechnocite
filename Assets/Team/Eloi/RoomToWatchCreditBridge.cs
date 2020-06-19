using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

//THIS CODE IS SHIT. BUT I DID IT TO BE READY IN TIME IN THE PROJECT.
public class RoomToWatchCreditBridge : MonoBehaviour
{

    public float m_timeBetweenCheck = 0.5f;
    public ParticipantCreditEvent m_onCreditChange;
    [Header("Debug (Don't touche)")]
    public Transform m_playerHead;
    public string m_currentSelection;
    public string m_previousSelection;
    public NameToScritableCredit[] m_credits;
    private void Start()
    {
        InvokeRepeating("CheckCredit", 0, m_timeBetweenCheck);
    }

    private void CheckCredit()
    {
        m_currentSelection = GetPseudonymeOfNearestCredit();
        if (m_currentSelection != m_previousSelection) {
            CreditsData credit = GetCreditForPseudonyme(m_currentSelection);
            m_onCreditChange.Invoke(credit);
            m_previousSelection = m_currentSelection;
        }
    }

    private CreditsData GetCreditForPseudonyme(string pseudo)
    {
        for (int i = 0; i < m_credits.Length; i++)
        {
            if (pseudo.Trim() == m_credits[i].m_pseudoId)
            {
                return m_credits[i].m_scritableData;
            }
        }
        return null;
    }

    public QuickCredit[] GetCreditsInSceneDirty()
    {
        //CHANGE SATURDAY HIT ME IF IT IS NOT CHANGE IN RELEASE
        return GameObject.FindObjectsOfType<QuickCredit>();
    }

    public string GetPseudonymeOfNearestCredit() {
        string nameID="";
        QuickCredit[] credits = GetCreditsInSceneDirty();
        if (credits.Length <= 0)
            return "";

        if (m_playerHead == null)
        {
            bool found;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.Head, out found, out m_playerHead);
        }
        Debug.Log("A");
        if (m_playerHead != null) {
            credits = credits.OrderBy(k => Vector3.Distance(m_playerHead.position, k.transform.position)).ToArray();

            Debug.Log("B");
            if (credits.Length > 0)
                nameID = credits[0].GetPseudonym();
        }
        return nameID;
    }

    [System.Serializable]
    public struct NameToScritableCredit {
        public string m_pseudoId;
        public CreditsData m_scritableData;
    }

    [System.Serializable]
    public class ParticipantCreditEvent : UnityEvent<CreditsData>{};
}

