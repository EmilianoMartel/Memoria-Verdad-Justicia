using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomiseFile : MonoBehaviour
{
    [SerializeField] private int _countFiles;
    [SerializeField] private ListSO _dataList;
    [SerializeField] private float _waitForData = 0.5f;
    private List<RecordFile> _fileList = new List<RecordFile>();


    private void Awake()
    {
        if (!_dataList)
        {
            Debug.LogError($"{name}: DataSource is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }
        if (_countFiles <= 0)
        {
            Debug.LogError($"{name}: CountFiles can´t be 0 or less.\nDisabled component.");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        StartCoroutine(GenerateList());
    }

    private IEnumerator GenerateList()
    {
        yield return new WaitForSeconds(_waitForData);

        if (_countFiles == 1)
        {
            GenerateFiles();
        }
        else
        {
            for (int i = 0; i < _countFiles; i++)
            {
                GenerateFiles();
            }
        }
    }

    private void GenerateFiles()
    {
        int randomIndexName = UnityEngine.Random.Range(0, _dataList.names.Count);
        int randomIndexLastName = UnityEngine.Random.Range(0, _dataList.lastNames.Count);
        int randomIndexAcronyms = UnityEngine.Random.Range(0, _dataList.acronyms.Count);
        int randomStorie = UnityEngine.Random.Range(0, _dataList.stories.Count);

        RecordFile temp = new RecordFile();
        temp.name = _dataList.names[randomIndexName].name;
        temp.lastName = _dataList.lastNames[randomIndexLastName].last_name;
        temp.politicalPartyName = _dataList.acronyms[randomIndexAcronyms].acronym;
        temp.background = _dataList.stories[randomStorie].story;
        temp.gender = _dataList.names[randomIndexName].gender;
        _fileList.Add(temp);
    }

    [ContextMenu("Show random file")]
    private void TestShowFile()
    {
        int i = UnityEngine.Random.Range(0, _fileList.Count);
        Debug.Log($"{name}: {_fileList[i].name}" +
            $"\n{_fileList[i].lastName}" +
            $"\n{_fileList[i].gender}" +
            $"\n{_fileList[i].politicalPartyName}" +
            $"\n{_fileList[i].background}");
    }
}
