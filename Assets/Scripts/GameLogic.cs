using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public enum Ends
{
    Capture,
    Judge,
    Free
}
public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _waitForManager = 1f;
    [Header("Managers")]
    [SerializeField] private ButtonsLogic _buttonsLogic;
    [SerializeField] private InfoLogic _infoLogic;
    [SerializeField] private AcronymsLogic _acronymsLogic;
    [SerializeField] private RandomiseFile _files;
    [SerializeField] private WorkersLogic _workersLogic;
    private int _actualIndex = -1;
    private int index = 0;

    [Header("GameParameters")]
    [SerializeField] private int _maxWaves = 5;
    [SerializeField] private int _maxFilesPerWave = 5;
    [SerializeField] private int _maxPeploSaveAmount = 1;
    [SerializeField] private float _captureChance = 10;
    [SerializeField] private float _percentSavePeopleToWin = 80f;
    private float _actualCaptureChanceFails = 0;
    private float _actualCaptureChanceWorkers = 0;

    private int _actualFile = 0;
    private int _capturePeople = 0;
    private int _fails = 0;
    private int _actualWave = 0;
    private int _totalPeople = 0;
    private int _savePeople = 0;
    private int _peopleToWork = 0;
    private int _extraPeopleWork = 0;

    public Action<int> newFile;
    public Action<bool> infoEvent;
    public Action<Ends> endGame;
    public Action newWave;


    private void OnEnable()
    {
        _buttonsLogic.free += HandleFree;
        _buttonsLogic.info += HandleActiveInfo;
        _buttonsLogic.capture += HandleInt;
        _buttonsLogic.newWorker += HandleWork;
        _workersLogic.incrementChance += HandleWorkChance;
    }

    private void OnDisable()
    {
        _buttonsLogic.free -= HandleFree;
        _buttonsLogic.info -= HandleActiveInfo;
        _buttonsLogic.capture -= HandleInt;
        _buttonsLogic.newWorker -= HandleWork;
        _workersLogic.incrementChance -= HandleWorkChance;
    }

    private void Start()
    {
        StartCoroutine(StartFile());
    }

    private IEnumerator StartFile()
    {
        yield return new WaitForSeconds(_waitForManager);
        FirstFile();
    }

    private void FirstFile()
    {
        newFile?.Invoke(index);
        _actualIndex++;
        index++;
    }

    [ContextMenu("NewFile")]
    private void HandleFree()
    {
        if (_acronymsLogic.ContainsAcronyms(_files.ActualPoliticParty(_actualIndex)))
        {
            _fails++;
            _actualCaptureChanceFails += _captureChance;
        }
        _totalPeople++;
        _savePeople++;
        newFile?.Invoke(index);
        _actualIndex++;
        index++;
        WaveCheck();
    }

    private void HandleActiveInfo()
    {
        infoEvent?.Invoke(true);
    }

    private void HandleInt()
    {
        _capturePeople++;
        _totalPeople++;
        newFile?.Invoke(index);
        _actualIndex++;
        index++;
        WaveCheck();
    }

    private void HandleWork()
    {
        if (_workersLogic.ContainsAndSumWorker(_files.ActualWork(_actualIndex)))
        {
            _peopleToWork++;
        }
        else
        {
            _peopleToWork++;
        }
        newFile?.Invoke(index);
        _actualIndex++;
        index++;
        WaveCheck();
    }

    private void HandleWorkChance()
    {
        _captureChance++;
        _extraPeopleWork++;
    }

    private void WaveCheck()
    {
        _actualFile++;
        if (_actualFile > _maxFilesPerWave)
        {
            _actualWave++;
            _actualFile = 0;
            newWave?.Invoke();
        }
        EndGame();
    }

    private void EndGame()
    {
        if (_fails > _maxPeploSaveAmount)
        {
            int temp = UnityEngine.Random.Range(0, 100);
            if (temp <= _actualCaptureChanceFails)
            {
                endGame?.Invoke(Ends.Capture);
                Debug.Log("Capture");
            }
        }
        if (_extraPeopleWork > _maxPeploSaveAmount)
        {
            int temp = UnityEngine.Random.Range(0, 100);
            if (temp <= _actualCaptureChanceFails)
            {
                endGame?.Invoke(Ends.Capture);
                Debug.Log("Capture");
            }
        }
        if (_actualWave >= _maxWaves)
        {
            if ((_savePeople+_peopleToWork)/_totalPeople >= _percentSavePeopleToWin)
            {
                endGame?.Invoke(Ends.Free);
                Debug.Log("GoodEnd");
            }
            else
            {
                endGame?.Invoke(Ends.Judge);
                Debug.Log("Judge");
            }
        }
    }
}
