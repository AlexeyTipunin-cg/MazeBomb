using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _screenBorderThickness = 10f;
    [SerializeField] private Vector2 _screenXLimits = Vector2.zero;
    [SerializeField] private Vector2 _screenZLimits = Vector2.zero;

    private Transform _playerCameraTransform;

    private Vector2 _prevInput;
    void Start()
    {
        _playerCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 oldPos = _playerCameraTransform.position;
        Vector3 pos = oldPos;

        Vector3 cursorMovement = Vector3.zero;
        Vector2 cursorPosition = Mouse.current.position.ReadValue();

        if (cursorPosition.y >= Screen.height - _screenBorderThickness)
        {
            cursorMovement.z += 1;
        }
        else if (cursorPosition.y <= _screenBorderThickness)
        {
            cursorMovement.z -= 1;
        }

        if (cursorPosition.x >= Screen.width - _screenBorderThickness)
        {
            cursorMovement.x += 1;
        }
        else if (cursorPosition.x <= _screenBorderThickness)
        {
            cursorMovement.x -= 1;
        }

        pos += cursorMovement.normalized * _speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, _screenXLimits.x, _screenXLimits.y);
        pos.z = Mathf.Clamp(pos.z, _screenZLimits.x, _screenZLimits.y);

        if (oldPos != pos)
        {
            _playerCameraTransform.position = pos;
        }
    }
}
