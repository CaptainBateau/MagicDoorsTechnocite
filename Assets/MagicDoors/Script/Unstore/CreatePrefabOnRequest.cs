using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabOnRequest : MonoBehaviour
{
    public Transform m_where;
    public GameObject m_prefab;
    public bool m_destroyAfterSpawn = true;
    public float m_destroyAfter = 3f;
    public void Spawn() {
        GameObject obj = GameObject.Instantiate(m_prefab, m_where.position, m_where.rotation);
        if (m_destroyAfterSpawn)
            Destroy(obj, m_destroyAfter);
    }

}
