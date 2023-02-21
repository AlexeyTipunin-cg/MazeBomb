using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private LayerMask _floorMask;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        PlayerController.onDropBomb += CreateBomb;
    }

    public void CreateBomb(Vector2 clickCoords)
    {
        Ray ray = _camera.ScreenPointToRay(clickCoords);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floorMask))
        {
            var pos = hit.point + new Vector3(0, 5, 0);
            Instantiate(_bombPrefab, pos, Quaternion.identity);
        }
    }
}
