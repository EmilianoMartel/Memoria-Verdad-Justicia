using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareForm : MonoBehaviour
{
    [SerializeField] private InfoLogic _infoLogic;

    public Action selectedEvent;

    private void OnEnable()
    {
        _infoLogic.compareEvent += HandleEvent;
    }

    private void OnDisable()
    {
        _infoLogic.compareEvent -= HandleEvent;
    }

    private void HandleEvent(CompareForm compare)
    {
        if (compare == this)
        {
            selectedEvent?.Invoke();
        }
    }
}
