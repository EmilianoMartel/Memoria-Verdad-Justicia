using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePanel : MonoBehaviour
{
    [SerializeField] private float _waitForDesactive = 2f;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameLogic _logic;

    private void OnEnable()
    {
        _logic.newWave += ActivePanel;
        _logic.startWave += DesactivePanel;
    }

    private void OnDisable()
    {
        _logic.newWave -= ActivePanel;
        _logic.startWave -= DesactivePanel;
    }

    private void ActivePanel()
    {
        _panel.SetActive(true);
    }

    private void DesactivePanel()
    {
        StartCoroutine(DesactiveCorrutine());
    }

    private IEnumerator DesactiveCorrutine()
    {
        yield return new WaitForSeconds(_waitForDesactive);
        _panel.SetActive(false);
    }
}
