using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using TMPro;

public class ViewPortRecord : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private SpriteRenderer _photo;
    [SerializeField] private TMPro.TMP_Text  _nameText;
    [SerializeField] private TMPro.TMP_Text  _lastNameText;
    [SerializeField] private TMPro.TMP_Text  _politicPartyText;
    [SerializeField] private TMPro.TMP_Text _jobsText;
    [SerializeField] private TMPro.TMP_Text  _backstoryText;
    [Header("Phtos")]
    [SerializeField] private List<Sprite> _malePhotoList = new List<Sprite>();
    [SerializeField] private List<Sprite> _femalePhotoList = new List<Sprite>();
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
        if (_malePhotoList.Count == 0 || _femalePhotoList.Count == 0)
        {
            Debug.LogError($"{name}: PhotoList is null\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }

    private void ShowFile(RecordFile file)
    {
        int randomIndex;
        _nameText.text = file.name;
        _lastNameText.text = file.lastName;
        _politicPartyText.text = file.politicalPartyName;
        _backstoryText.text = file.background;
        _jobsText.text = file.job;
        if (file.gender == "male")
        {
            randomIndex = UnityEngine.Random.Range(0, _malePhotoList.Count);
            _photo.sprite = _malePhotoList[randomIndex];
        }
        else
        {
            randomIndex = UnityEngine.Random.Range(0, _femalePhotoList.Count);
            _photo.sprite = _malePhotoList[randomIndex];
        }
    }
}