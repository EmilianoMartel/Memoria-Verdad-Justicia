using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _file;
    [SerializeField] private GameObject _politicParty;
    [SerializeField] private GameObject _jobs;
    [SerializeField] private GameObject _panel;
    [SerializeField] private List<GameObject> _buttonList;
    [SerializeField] private GameObject _introPanel;

    [SerializeField] private List<string> _tutorialList;

    [SerializeField] private List<RectTransform> _newPositionList;

    private int _index = 0;

    public Action<string> newText;
    public Action<RectTransform> changePosition;
    public Action final;

    private void Awake()
    {
        Vector3 vector = new Vector3(0, 0, 10);
        _file.transform.position += vector;
        _politicParty.transform.position += vector;
        _jobs.transform.position += vector;
        for (int i = 0; i < _buttonList.Count; i++)
        {
            _buttonList[i].SetActive(false);
        }
    }

    private void Start()
    {
        newText?.Invoke(_tutorialList[_index]);
        _index++;
    }

    public void NextTutorial()
    {
        if (_index >= _tutorialList.Count - 1)
        {
            for (int i = 0; i < _buttonList.Count; i++)
            {
                _buttonList[i].SetActive(false);
            }
            final?.Invoke();
        }

        newText?.Invoke(_tutorialList[_index]);
        switch (_index)
        {
            case 1:
                FirstChange();
                break;
            case 2:
                SecondChange();
                break;
            case 3:
                ThirdChange();
                break;
            case 4:
                FourChange();
                break;
            default:
                break;
        }
        _index++;
    }

    private void FirstChange()
    {
        Vector3 vector = new Vector3(0, 0, -11);
        _file.transform.position += vector;
        changePosition?.Invoke(_newPositionList[0]);
    }

    private void SecondChange()
    {
        Vector3 vector = new Vector3(0, 0, 10);
        _file.transform.position += vector;
        Vector3 vector1 = new Vector3(0, 0, -11);
        _politicParty.transform.position += vector1;
        changePosition?.Invoke(_newPositionList[1]);
    }

    private void ThirdChange()
    {
        Vector3 vector = new Vector3(0, 0, 10);
        _politicParty.transform.position += vector;
        Vector3 vector1 = new Vector3(0, 0, -11);
        _jobs.transform.position += vector1;
        changePosition?.Invoke(_newPositionList[1]);
    }

    private void FourChange()
    {
        Vector3 vector = new Vector3(0, 0, 10);
        _jobs.transform.position += vector;
        for (int i = 0; i < _buttonList.Count; i++)
        {
            _buttonList[i].SetActive(true);
        }
        changePosition?.Invoke(_newPositionList[2]);
    }
}
