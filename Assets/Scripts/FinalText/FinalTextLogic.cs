using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTextLogic : MonoBehaviour
{
    [SerializeField] private float _waitForLetter = 0.5f;
    [SerializeField] private float _waitForInnit = 0.5f;
    [SerializeField] private string _captureFinal = "capture";
    [SerializeField] private string _freeFinal = "free";
    [SerializeField] private string _judgeFinal = "judge";
    [SerializeField] private FianlSO _final;
    [SerializeField] private SoundManager _soundManager;

    public Action<char> sendText;

    private void Start()
    {
        _soundManager.PlayAudio();
        StartCoroutine(WriteLetter());
    }

    private IEnumerator WriteLetter()
    {
        yield return new WaitForSeconds(_waitForInnit);
        switch (_final.ends)
        {
            case Ends.Capture:
                for (int i = 0; i < _captureFinal.Length; i++)
                {
                    yield return new WaitForSeconds(_waitForLetter);
                    char character = _captureFinal[i];
                    sendText?.Invoke(character);
                }
                break;
            case Ends.Judge:
                for (int i = 0; i < _judgeFinal.Length; i++)
                {
                    yield return new WaitForSeconds(_waitForLetter);
                    char character = _judgeFinal[i];
                    sendText?.Invoke(character);
                }
                break;
            case Ends.Free:
                for (int i = 0; i < _freeFinal.Length; i++)
                {
                    yield return new WaitForSeconds(_waitForLetter);
                    char character = _freeFinal[i];
                    sendText?.Invoke(character);
                }
                break;
            default:
                break;
        }
        _soundManager.StopAudio();
    }
}
