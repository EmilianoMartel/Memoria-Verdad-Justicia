using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _waitForManager = 1f;
    [SerializeField] private ButtonsLogic _buttonsLogic;
    private int index = 0;

    public Action<int> newFile;
    public Action<bool> infoEvent;

    private void OnEnable()
    {
        _buttonsLogic.free += NewFileText;
        _buttonsLogic.info += HandleActiveInfo;
    }

    private void OnDisable()
    {
        _buttonsLogic.free -= NewFileText;
        _buttonsLogic.info -= HandleActiveInfo;
    }

    private void Start()
    {
        StartCoroutine(StartFile());
    }

    private IEnumerator StartFile()
    {
        yield return new WaitForSeconds(_waitForManager);
        NewFileText();
    }

    [ContextMenu("NewFile")]
    private void NewFileText()
    {
        newFile?.Invoke(index);
        index++;
    }


    private void HandleActiveInfo()
    {
        infoEvent?.Invoke(true);
    }

    private void HandleDesactiveInfo()
    {
        infoEvent?.Invoke(false);
    }
}
