using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public interface IBombStrategy
    {
        public List<Bot> FindDamagedBots(Bot[] bots, Vector3 explosionPos, GamePhysics physics);
    }
}