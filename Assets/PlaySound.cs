using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    Transform m_head;
    AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        m_head = Camera.main.transform; 
        
    }

    public void PlayCustomSound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

}
