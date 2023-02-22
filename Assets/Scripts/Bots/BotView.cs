using System;
using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotView : MonoBehaviour
    {
        public event Action<float, float> onHealthChanged;
        [SerializeField] private int maxHealth;
        private float _health;

        private void Start()
        {
            _health = maxHealth;
        }

        public void MakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
                return;
            }
            onHealthChanged?.Invoke(_health, maxHealth);
        }
    }
}