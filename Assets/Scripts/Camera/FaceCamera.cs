using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform _mainCameraTransform;
    void Start()
    {
        _mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + _mainCameraTransform.rotation * Vector3.forward, _mainCameraTransform.rotation * Vector3.up);
    }
}
