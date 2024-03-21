using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneLogic : MonoBehaviour
{
    [SerializeField] private string _message = " \"La sobreexposición es perjudicial para la salud\"\nLey 26.043";
    [SerializeField] private float _waitForText = 0.5f;
    [SerializeField] private float _waitForLetters = 0.1f;
    [SerializeField] private float _waifForChange = 1;
    [SerializeField] private string _nextScene = "Menu";

    public Action<char> sendChar;

    private void Start()
    {
        StartCoroutine(SendText());
    }

    private IEnumerator SendText()
    {
        yield return new WaitForSeconds(_waitForText);
        for (int i = 0; i < _message.Length; i++)
        {
            char text = _message[i];
            sendChar?.Invoke(text);
            yield return new WaitForSeconds(_waitForLetters);
        }
        yield return new WaitForSeconds(_waifForChange);
        SceneManager.LoadScene(_nextScene);
    }
}
