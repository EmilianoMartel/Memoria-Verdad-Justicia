using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WorkersLogic : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _maxWorkers = 10;
    [SerializeField] private int _minWorkerStar = 0;
    [SerializeField] private int _maxWorkerStar = 5;
    [SerializeField] private int _minAmountLosingWorker = 0;
    [SerializeField] private int _maxAmountLosingWorker = 1;
    [SerializeField] private int _minAmountEartingnWorker = 0;
    [SerializeField] private int _maxAmountEarningWorker = 1;
    [SerializeField] private float _chanceLosingWorker = 20;
    [SerializeField] private float _chanceEarningWorker = 20;
    [Header("Managers")]
    [SerializeField] private float _waitForData = 0.5f;
    [SerializeField] private ListSO _dataSO;

    struct JobsSituation
    {
        public string name;
        public int actualWorkers;
    }

    private List<JobsSituation> _jobsList = new List<JobsSituation>();

    public Action<string, int, int> jobSetEvent;

    private void Awake()
    {
        if (!_dataSO)
        {
            Debug.LogError($"{name}: DataSource is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        StartCoroutine(SetJobsList());
    }

    private IEnumerator SetJobsList()
    {
        yield return new WaitForSeconds( _waitForData );
        for (int i = 0; i < _dataSO.jobs.Count; i++)
        {
            int amount = UnityEngine.Random.Range(_minWorkerStar, _maxWorkerStar);
            jobSetEvent?.Invoke(_dataSO.jobs[i].job,amount,_maxWorkers);
        }
    }
}
