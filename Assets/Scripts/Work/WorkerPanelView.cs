using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WorkerPanelView : MonoBehaviour
{
    [SerializeField] private WorkersLogic _workLogic;
    [SerializeField] private TMPro.TMP_Text _textPrefab;

    private List<TMPro.TMP_Text> _textList = new List<TMP_Text>();

    private void OnEnable()
    {
        _workLogic.jobSetEvent += HandleWorks;
    }

    private void OnDisable()
    {
        _workLogic.jobSetEvent -= HandleWorks;
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
        TMPro.TMP_Text temp;
        temp = Instantiate(_textPrefab);
        temp.transform.SetParent(transform, false);
        temp.text = job + " " + actualAmount + "/" + maxAmount;
        _textList.Add(temp);
    }
}