using UnityEngine;

public class Layers : MonoBehaviour
{
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private LayerMask _wallMask;

    public LayerMask floorMask => _floorMask;
    public LayerMask wallMask => _wallMask;
}
