using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audio;

    [ContextMenu("StartAudio")]
    public void PlayAudio()
    {
        _audioSource.clip = _audio;
        _audioSource.Play();
    }

    public void StopAudio()
    {
        _audioSource.Stop();
    }
}