using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{

    AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCustomSound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
