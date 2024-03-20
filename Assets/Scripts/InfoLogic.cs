using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoLogic : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float _clcikTime = 3f;
    [SerializeField] private LayerMask _compareMask;
    public Vector2 mousePosition;
    public bool click;

    private bool _isActive = false;
    private bool _activeCorrutine = false;
    private int _index = 0;

    public Action<CompareForm> compareEvent;

    private void OnEnable()
    {
        _gameLogic.infoEvent += HandleStartLogic;
    }

    private void OnDisable()
    {
        _gameLogic.infoEvent -= HandleStartLogic;
    }

    private void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (click && !_activeCorrutine)
        {
            StartCoroutine(HandleClick());
        }

    }

    private void HandleStartLogic(bool active)
    {
        Debug.Log("active");
        _isActive = active;
    }

    private IEnumerator HandleClick()
    {
        _activeCorrutine = true;
        click = false;

        Vector2 mousePositionTemp = Mouse.current.position.ReadValue();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePositionTemp), Vector2.zero, 1000f, _compareMask);
        
        if (hit.collider != null && hit.collider.TryGetComponent<CompareForm>(out CompareForm objectMatchForm))
        {
            compareEvent?.Invoke(objectMatchForm);
            if (_index == 0)
            {
                _index++;
            }
            else
            {
                _index = 0;
                _isActive = false;
                _gameLogic.infoEvent?.Invoke(false);
            }

        }

        yield return new WaitForSeconds(_clcikTime);
        _activeCorrutine = false;
        click = false;
    }
}
