using UnityEngine;

public class GamePhysics : MonoBehaviour
{
    [SerializeField] private Layers _layers;
    [SerializeField] private Camera _camera;

    public bool RaycastOnFloor(Vector2 clickCoords, out RaycastHit hit)
    {
        var ray = _camera.ScreenPointToRay(clickCoords);
        return Physics.Raycast(ray, out hit, Mathf.Infinity, _layers.floorMask);
    }

    public bool RaycastOnWalls(Vector3 botPos, Vector3 explosionPos, float radius)
    {
        Vector3 direction = botPos - explosionPos;
        Ray ray = new Ray(explosionPos, direction);
        return Physics.Raycast(ray, out RaycastHit hit, radius, _layers.wallMask);
    }
}