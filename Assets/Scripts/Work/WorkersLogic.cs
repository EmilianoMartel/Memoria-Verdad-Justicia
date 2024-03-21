using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WorkersLogic : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _maxJobs = 5;
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
    [SerializeField] private GameLogic _gameLogic;

    private struct JobState
    {
        public string name;
        public int actualWorkers;
    }

    private List<JobState> _jobsDic = new List<JobState>();

    public Action<string, int, int> jobSetEvent;
    public Action incrementChance;
    public Action<string,int> jobState;

    private void OnEnable()
    {
        _gameLogic.newWave += HandleNextWave;
    }

    private void OnDisable()
    {
        _gameLogic.newWave -= HandleNextWave;
    }

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
        yield return new WaitForSeconds(_waitForData);
        RandomJobs();
    }

    private void RandomJobs()
    {
        List<int> list = new List<int>();
        list = GenerateUniqueRandomNumbers(0, _dataSO.jobs.Count, _maxJobs);
        for (int i = 0; i < list.Count; i++)
        {
            int amount = UnityEngine.Random.Range(_minWorkerStar, _maxWorkerStar);
            jobSetEvent?.Invoke(_dataSO.jobs[list[i]].job, amount, _maxWorkers);
            JobState jobState = new JobState();
            jobState.name = _dataSO.jobs[list[i]].job;
            jobState.actualWorkers = amount;
            _jobsDic.Add(jobState);
        }
    }

    public bool ContainsAndSumWorker(string work)
    {
        for (int i = 0; i < _jobsDic.Count; i++)
        {
            if (_jobsDic[i].name == work)
            {
                JobState jobTemp = new JobState();
                jobTemp.actualWorkers = _jobsDic[i].actualWorkers + 1;
                jobTemp.name = _jobsDic[i].name;
                _jobsDic[i] = jobTemp;
                if (_jobsDic[i].actualWorkers > _maxWorkers)
                {
                    incrementChance?.Invoke();
                }
                string messegae = _jobsDic[i].name + " " + _jobsDic[i].actualWorkers + "/" + _maxWorkers;
                jobState?.Invoke(messegae, i);
                Debug.Log("enviado");
                return true;
            }
        }
        return false;
    }

    private void HandleNextWave()
    {
        for (int i = 0; i < _jobsDic.Count; i++)
        {
            int earningChance = UnityEngine.Random.Range(0, 100);
            int loosingChance = UnityEngine.Random.Range(0, 100);
            JobState jobTemp = new JobState();
            if (earningChance <= _chanceEarningWorker)
            {
                if (_jobsDic[i].actualWorkers <= _maxWorkers)
                {
                    int amount = UnityEngine.Random.Range(_minAmountEartingnWorker, _maxAmountEarningWorker);
                    jobTemp.actualWorkers = _jobsDic[i].actualWorkers + amount;
                    jobTemp.name = _jobsDic[i].name;
                    _jobsDic[i] = jobTemp;
                }
            }
            if (loosingChance <= _chanceLosingWorker)
            {
                if (_jobsDic[i].actualWorkers > 0)
                {
                    int amount = UnityEngine.Random.Range(_minAmountLosingWorker, _maxAmountLosingWorker);
                    jobTemp.actualWorkers = _jobsDic[i].actualWorkers - amount;
                    jobTemp.name = _jobsDic[i].name;
                    
                    if (_jobsDic[i].actualWorkers < 0)
                    {
                        jobTemp.actualWorkers = 0;
                    }
                    _jobsDic[i] = jobTemp;
                }
            }
            string messegae = _jobsDic[i].name + " " + _jobsDic[i].actualWorkers + "/" + _maxWorkers;
            jobState?.Invoke(messegae, i);
        }
    }

    private List<int> GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        if (count > (max - min + 1))
        {
            throw new ArgumentException("The number of unique numbers cannot be greater than the specified range.");
        }

        List<int> uniqueNumbers = new List<int>();
        HashSet<int> generatedNumbers = new HashSet<int>();


        while (uniqueNumbers.Count < count)
        {
            int randomNumber = UnityEngine.Random.Range(min, max);

            if (!generatedNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                generatedNumbers.Add(randomNumber);
            }
        }

        return uniqueNumbers;
    }
}
