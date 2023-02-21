using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action<Vector3, float, float> onCollision;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    private void OnCollisionEnter(Collision collision)
    {
        onCollision?.Invoke(transform.position, _radius, _damage);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
