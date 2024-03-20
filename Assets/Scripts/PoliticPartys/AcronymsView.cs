using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcronymsView : MonoBehaviour
{
    [SerializeField] private AcronymsLogic _acronymsLogic;
    [SerializeField] private List<TMPro.TMP_Text> _textList = new List<TMP_Text>();

    private int indexCount = 0;


    private void OnEnable()
    {
        _acronymsLogic.setAcronyms += HandleAcronyms;
    }

    private void OnDisable()
    {
        _acronymsLogic.setAcronyms -= HandleAcronyms;
    }

    private void Awake()
    {
        if (!_acronymsLogic)
        {
            Debug.LogError($"{name}: AcronymsLogic is null.\nCheck and assigned one.\nDisabled component.");
            enabled = false;
            return;
        }
    }

    private void HandleAcronyms(string name)
    {
        if (indexCount > _textList.Count)
        {
            indexCount = 0;
        }
        _textList[indexCount].text = name;
        indexCount++;
    }
}
