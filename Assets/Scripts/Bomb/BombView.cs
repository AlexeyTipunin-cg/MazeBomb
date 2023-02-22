using Assets.Scripts.Bomb;
using System;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public class BombView : MonoBehaviour, IBombView
    {
        public event Action<BombTypes, Vector3> onCollision;
        [SerializeField] private BombTypes _type;

        private void OnCollisionEnter(Collision collision)
        {
            onCollision?.Invoke(_type, transform.position);
            Destroy(gameObject);
        }
    }
}