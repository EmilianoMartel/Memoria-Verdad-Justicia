using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMPro.TMP_Text _text;

    private void OnEnable()
    {
        _gameLogic.endGame += HandleActiveFinal;
    }

    private void OnDisable()
    {
        _gameLogic.endGame -= HandleActiveFinal;
    }

    private void Start()
    {
        _panel.SetActive(false);
        _text.gameObject.SetActive(false);
    }

    private void HandleActiveFinal(Ends ends)
    {
        switch (ends)
        {
            case Ends.Capture:
                _panel.SetActive(true);
                _text.gameObject.SetActive(true);
                _text.text = "Capturado";
                break;
            case Ends.Judge:
                _panel.SetActive(true);
                _text.gameObject.SetActive(true);
                _text.text = "Juzgado";
                break;
            case Ends.Free:
                _panel.SetActive(true);
                _text.gameObject.SetActive(true);
                _text.text = "Ganaste";
                break;
            default:
                break;
        }
    }
}
