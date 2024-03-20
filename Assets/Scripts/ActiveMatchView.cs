using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveMatchView : MonoBehaviour
{
    [SerializeField] private GameObject _sprite;
    [SerializeField] private GameLogic _gameManager;

    private void OnEnable()
    {
        _gameManager.infoEvent += HandleActive;
    }

    private void OnDisable()
    {
        _gameManager.infoEvent -= HandleActive;
    }

    private void Start()
    {
        _sprite.SetActive(false);
    }

    private void HandleActive(bool active)
    {
        _sprite.SetActive(active);
    }
}
