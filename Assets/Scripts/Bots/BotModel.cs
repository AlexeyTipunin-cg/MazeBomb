﻿using System;

namespace Assets.Scripts.Bots
{
    public class BotModel
    {
        public event Action<float, float> onHealthChanged;
        public event Action<BotModel> onDestroyed;
        private int _maxHealth;
        private float _health;

        public BotModel(int maxHealth)
        {
            _maxHealth = maxHealth;
            _health = _maxHealth;
        }

        public void MakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                onDestroyed?.Invoke(this);
                return;
            }
            onHealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}
