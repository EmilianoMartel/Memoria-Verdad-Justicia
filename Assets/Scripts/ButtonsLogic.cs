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
    [SerializeField] private Button _infoButton;

    public Action free;
    public Action capture;
    public Action newWorker;
    public Action info;

    private void OnEnable()
    {
        _intButton.onClick.AddListener(CaptureEvent);
        _refButton.onClick.AddListener(NewWorkerEvent);
        _indifButton.onClick.AddListener(FreeEvent);
        _infoButton.onClick.AddListener(InfoEvent);
    }

    private void OnDisable()
    {
        _intButton.onClick.RemoveListener(CaptureEvent);
        _refButton.onClick.RemoveListener(NewWorkerEvent);
        _indifButton.onClick.RemoveListener(FreeEvent);
        _infoButton?.onClick?.RemoveListener(InfoEvent);
    }

    private void CaptureEvent()
    {
        capture?.Invoke();
    }

    private void NewWorkerEvent()
    {
        newWorker?.Invoke();
    }

    private void FreeEvent()
    {
        free?.Invoke();
    }

    private void InfoEvent()
    {
        info?.Invoke();
    }
}
