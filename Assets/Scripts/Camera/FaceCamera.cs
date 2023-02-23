using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private Transform _mainCameraTransform;

    void Start()
    {
        _mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        var pos = _target.position + _offset;
        transform.position = pos;
        transform.LookAt(pos + _mainCameraTransform.rotation * Vector3.forward, _mainCameraTransform.rotation * Vector3.up);
    }
}
