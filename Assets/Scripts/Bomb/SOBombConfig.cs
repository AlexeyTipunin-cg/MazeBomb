using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    [CreateAssetMenu(fileName = "BombConfig", menuName = "Create bomb config")]
    public class SOBombConfig : ScriptableObject
    {
        [SerializeField]
        private float _radius;
        [SerializeField]
        private float _damage;
        [SerializeField]
        private BombTypes _type;

        public float radius => _radius;
        public float damage => _damage;

        public BombTypes type => _type;
    }
}