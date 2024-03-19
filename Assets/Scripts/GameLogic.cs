using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _waitForManager = 1f;

    private int index = 0;

    public Action<int> newFile;

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

}
