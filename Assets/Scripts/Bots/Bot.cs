using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bot : MonoBehaviour
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
