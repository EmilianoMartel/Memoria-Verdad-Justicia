using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using TMPro;

public class ViewPortRecord : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private Image _photo;
    [SerializeField] private TMPro.TMP_Text  _nameText;
    [SerializeField] private TMPro.TMP_Text  _lastName;
    [SerializeField] private TMPro.TMP_Text  _politicParty;
    [SerializeField] private TMPro.TMP_Text  _backstory;
    [Header("Managers")]
    [SerializeField] private RandomiseFile _randomiser;

    private void OnEnable()
    {
        _randomiser.sendFile += ShowFile;
    }

    private void OnDisable()
    {
        _randomiser.sendFile -= ShowFile;
    }

    private void Awake()
    {
        if (!_randomiser)
        {
            Debug.LogError($"{name}: Randomiser is null\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }

    private void ShowFile(RecordFile file)
    {
        _nameText.text = file.name;
        _lastName.text = file.lastName;
        _politicParty.text = file.politicalPartyName;
        _backstory.text = file.background;
    }
}