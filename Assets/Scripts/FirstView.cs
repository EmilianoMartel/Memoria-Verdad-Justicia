using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstView : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private FirstSceneLogic _firstLogic;

    private void OnEnable()
    {
        _firstLogic.sendChar += HandleText;
    }

    private void OnDisable()
    {
        _firstLogic.sendChar -= HandleText;
    }

    private void HandleText(char sendText)
    {
        _text.text += sendText;
    }
}
