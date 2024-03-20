using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class InfoLogic : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;

    private bool _isActive = false;
    private LineRenderer _lineRenderer;
    private bool _isDragging;
    private Vector3 _endPoint;
    private CompareForm _objectMatchForm;

    private void OnEnable()
    {
        _gameLogic.infoEvent += HandleStartLogic;
    }

    private void OnDisable()
    {
        _gameLogic.infoEvent -= HandleStartLogic;
    }

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                _isDragging = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                _lineRenderer.SetPosition(0, mousePosition);
            }
        }
        if (_isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            _lineRenderer.SetPosition(1, mousePosition);
            _endPoint = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(_endPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out _objectMatchForm))
            {
                Debug.Log("Correct Form!");
                this.enabled = false;
            }
            else
            {
                _lineRenderer.positionCount = 0;
            }
            _lineRenderer.positionCount = 0;
        }
    }

    private void HandleStartLogic(bool active)
    {
        Debug.Log("active");
        _isActive = active;
    }
}
