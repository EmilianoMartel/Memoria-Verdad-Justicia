using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private InfoLogic _infoLogic;

    public void SetMouseValue(InputAction.CallbackContext inputContext)
    {
        _infoLogic.mousePosition = inputContext.ReadValue<Vector2>();
    }

    public void SetClickValue(InputAction.CallbackContext inputContext)
    {
        _infoLogic.click = true;
    }
}