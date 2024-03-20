using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcronymsLogic : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _maxAcronyms;
    [Header("Managers")]
    [SerializeField] private ListSO _listSO;
    [SerializeField] private float _waitForList = 0.5f;

    private List<string> acronyms = new List<string>();

    public Action<string> setAcronyms;

    private void Awake()
    {
        if (!_listSO)
        {
            Debug.LogError($"{name}: DataSource is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        StartCoroutine(SetAcronyms());
    }

    private IEnumerator SetAcronyms()
    {
        yield return new WaitForSeconds( _waitForList );
        RandomAcronyms();
    }

    private void RandomAcronyms()
    {
        List<int> list = new List<int>();
        list = GenerateUniqueRandomNumbers(0, _listSO.acronyms.Count, _maxAcronyms);
        for (int i = 0; i < list.Count; i++)
        {
            acronyms.Add(_listSO.acronyms[list[i]].acronym);
            setAcronyms?.Invoke(_listSO.acronyms[list[i]].acronym);
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

    public bool ContainsAcronyms(string politicPartyName)
    {
        if (acronyms.Contains(politicPartyName))
        {
            return true;
        }
        return false;
    }
}