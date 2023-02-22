using System;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public interface IBombView
    {
        public event Action<BombTypes, Vector3> onCollision;
    }
}