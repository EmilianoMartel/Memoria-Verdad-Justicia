using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class Names
{
    public string name;
    public string gender;
}

public class LastNames
{
    public string last_name;
}

public class Stories
{
    public string male;
    public string female;
}

public class Acronyms
{
    public string acronym;
}

public class Jobs
{
    public string job;
}

public class JsonReader : MonoBehaviour
{
    private List<Names> _namesList;
    private List<LastNames> _lastNamesList;
    private List<Stories> _storiesList;
    private List<Acronyms> _acronymsList;
    private List<Jobs> _jobsList;
    [Header("Json Files")]
    [SerializeField] private string NAMES_FILE_NAME = "Names.json";
    [SerializeField] private string LAST_NAME_FILE = "LastName.json";
    [SerializeField] private string STORIES_FILE = "Stories.json";
    [SerializeField] private string ACRONYM_FILE = "Acronym.json";
    [SerializeField] private string JOBS_FILE = "Jobs.json";
    [Header("Data Source")]
    [SerializeField] private ListSO _dataSource;
    private static string _relativeFolder = "StreamingAssets";
    private string _filePathNames;
    private string _filePathLastNames;
    private string _filePathStories;
    private string _filePathAcronyms;
    private string _filePathJobs;

    private void Awake()
    {
        if (!_dataSource)
        {
            Debug.LogError($"{name}: DataSource is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }

        ListReader();

        _dataSource.names = _namesList;
        _dataSource.acronyms = _acronymsList;
        _dataSource.stories = _storiesList;
        _dataSource.lastNames = _lastNamesList;
        _dataSource.jobs = _jobsList;
    }
    
    private void ListReader()
    {
        _filePathNames = Path.Combine(Application.dataPath, _relativeFolder, NAMES_FILE_NAME);
        _filePathLastNames = Path.Combine(Application.dataPath, _relativeFolder, LAST_NAME_FILE);
        _filePathStories = Path.Combine(Application.dataPath, _relativeFolder, STORIES_FILE);
        _filePathAcronyms = Path.Combine(Application.dataPath, _relativeFolder, ACRONYM_FILE);
        _filePathJobs = Path.Combine(Application.dataPath, _relativeFolder, JOBS_FILE);

        try
        {
            if (File.Exists(_filePathNames))
            {
                _namesList = JsonConvert.DeserializeObject<List<Names>>(File.ReadAllText(_filePathNames));
            }
            else
            {
                Debug.LogError($"File dont exist: {_filePathNames}");
            }
            if (File.Exists(_filePathLastNames))
            {
                _lastNamesList = JsonConvert.DeserializeObject<List<LastNames>>(File.ReadAllText(_filePathLastNames));
            }
            else
            {
                Debug.LogError($"File dont exist: {_filePathLastNames}");
            }
            if (File.Exists(_filePathStories))
            {
                _storiesList = JsonConvert.DeserializeObject<List<Stories>>(File.ReadAllText(_filePathStories));
            }
            else
            {
                Debug.LogError($"File dont exist: {_filePathStories}");
            }
            if (File.Exists(_filePathAcronyms))
            {
                _acronymsList = JsonConvert.DeserializeObject<List<Acronyms>>(File.ReadAllText(_filePathAcronyms));
            }
            else
            {
                Debug.LogError($"File dont exist: {_filePathAcronyms}");
            }
            if (File.Exists(_filePathJobs))
            {
                _jobsList = JsonConvert.DeserializeObject<List<Jobs>>(File.ReadAllText(_filePathJobs));
            }
            else
            {
                Debug.LogError($"File dont exist: {_filePathJobs}");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error to charge JSON: {e.Message}");
        }
    }
}