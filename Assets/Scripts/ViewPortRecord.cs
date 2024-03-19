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
    [SerializeField] private TMPro.TMP_Text  _lastNameText;
    [SerializeField] private TMPro.TMP_Text  _politicPartyText;
    [SerializeField] private TMPro.TMP_Text _jobsText;
    [SerializeField] private TMPro.TMP_Text  _backstoryText;
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
        _lastNameText.text = file.lastName;
        _politicPartyText.text = file.politicalPartyName;
        _backstoryText.text = file.background;
        _jobsText.text = file.job;
    }
}