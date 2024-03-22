using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLogic : MonoBehaviour
{
    [SerializeField] private Button _intButton;
    [SerializeField] private Button _refButton;
    [SerializeField] private Button _indifButton;
    [SerializeField] private List<SoundManager> _soundManager = new List<SoundManager>();

    public Action free;
    public Action capture;
    public Action newWorker;
    public Action info;

    private void OnEnable()
    {
        _intButton.onClick.AddListener(CaptureEvent);
        _refButton.onClick.AddListener(NewWorkerEvent);
        _indifButton.onClick.AddListener(FreeEvent);
    }

    private void OnDisable()
    {
        _intButton.onClick.RemoveListener(CaptureEvent);
        _refButton.onClick.RemoveListener(NewWorkerEvent);
        _indifButton.onClick.RemoveListener(FreeEvent);
    }

    private void CaptureEvent()
    {
        PlaySound();
        capture?.Invoke();
    }

    private void NewWorkerEvent()
    {
        PlaySound();
        newWorker?.Invoke();
    }

    private void FreeEvent()
    {
        PlaySound();
        free?.Invoke();
    }

    private void PlaySound()
    {
        int index = UnityEngine.Random.Range(0, _soundManager.Count);
        if (index >= 0 && index < _soundManager.Count)
        {
            _soundManager[index].PlayAudio();
        }
        
    }
}
