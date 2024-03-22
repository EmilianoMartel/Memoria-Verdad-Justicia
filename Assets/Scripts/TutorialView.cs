using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialView : MonoBehaviour
{
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private GameObject _next;
    [SerializeField] private GameObject _menu;


    private void OnEnable()
    {
        _tutorial.newText += ChangeText;
        _tutorial.changePosition += HandlePosition;
        _tutorial.final += HandleFinal;
    }

    private void OnDisable()
    {
        _tutorial.newText -= ChangeText;
        _tutorial.changePosition -= HandlePosition;
        _tutorial.final -= HandleFinal;
    }

    private void ChangeText(string newText)
    {
        _text.text = newText;
    }

    private void HandlePosition(RectTransform newPosition)
    {
        _text.rectTransform.position = newPosition.position;
    }

    private void HandleFinal()
    {
        _next.SetActive(false);
        _menu.SetActive(true);
    }
}
