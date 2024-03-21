using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTextView : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private FinalTextLogic _logic;

    private void OnEnable()
    {
        _logic.sendText += HandleText;   
    }

    private void OnDisable()
    {
        _logic.sendText -= HandleText;
    }

    private void HandleText(char sendText)
    {
        _text.text += sendText;
    }
}
