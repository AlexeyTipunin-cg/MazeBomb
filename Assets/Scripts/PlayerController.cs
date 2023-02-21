using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static event Action<Vector2> onDropBomb;
    [SerializeField] private InputActionReference _dropBomb;

    void Start()
    {
        _dropBomb.action.performed += OnDropBomb;
    }

    private void OnDestroy()
    {
        _dropBomb.action.performed -= OnDropBomb;
    }

    private void OnDropBomb(InputAction.CallbackContext context)
    {
        var clickCoords = Mouse.current.position.ReadValue();
        onDropBomb?.Invoke(clickCoords);
    }
}
