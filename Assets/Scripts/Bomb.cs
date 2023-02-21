using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action<Vector3, float> onCollision;
    [SerializeField] private float _radius;

    private void OnCollisionEnter(Collision collision)
    {
        onCollision?.Invoke(transform.position, _radius);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
