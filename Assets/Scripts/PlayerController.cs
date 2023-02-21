using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _dropBomb;
    void Start()
    {
        _dropBomb.action.performed += OnDropBomb;
    }

    private void OnDestroy()
    {
        _dropBomb.action.performed -= OnDropBomb;
    }

    public void OnDropBomb(InputAction.CallbackContext context)
    {
        Debug.Log("BOOOOOOOOOOOOOOOOMB");
    }
}
