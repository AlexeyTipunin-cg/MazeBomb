using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static event Action<Vector2> onDropBomb;
    [SerializeField] private InputActionReference _dropBomb;

    private void OnEnable()
    {
        _dropBomb.action.Enable();
        _dropBomb.action.performed += OnDropBomb;
    }

    private void OnDisable()
    {
        _dropBomb.action.performed -= OnDropBomb;
        _dropBomb.action.Disable();
    }

    private void OnDropBomb(InputAction.CallbackContext context)
    {
        var clickCoords = Mouse.current.position.ReadValue();
        onDropBomb?.Invoke(clickCoords);
    }
}
