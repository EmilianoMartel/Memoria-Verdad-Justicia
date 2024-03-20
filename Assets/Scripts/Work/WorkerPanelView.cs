using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WorkerPanelView : MonoBehaviour
{
    [SerializeField] private WorkersLogic _workLogic;
    [SerializeField] private List<TMPro.TMP_Text> _textList = new List<TMP_Text>();

    private int indexCount = 0;

    private void OnEnable()
    {
        _workLogic.jobSetEvent += HandleWorks;
        _workLogic.jobState += HandleActualWorkers;
    }

    private void OnDisable()
    {
        _workLogic.jobSetEvent -= HandleWorks;
        _workLogic.jobState -= HandleActualWorkers;
    }

    private void Awake()
    {
        if (!_workLogic)
        {
            Debug.LogError($"{name}: WorkLogic is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }
    }

    private void HandleWorks(string job, int actualAmount, int maxAmount)
    {
        if (indexCount >= _textList.Count)
        {
            indexCount = 0;
        }
        _textList[indexCount].text = job + " " + actualAmount + "/" + maxAmount;
        indexCount++;
    }

    private void HandleActualWorkers(string job, int index)
    {
        if (index >= _textList.Count || index < 0)
        {
            return;
        }
        _textList[index].text = job;
    }
}