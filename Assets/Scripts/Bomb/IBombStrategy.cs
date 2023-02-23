using Assets.Scripts.Bots;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public interface IBombStrategy
    {
        public void SetConfig(SOBombConfig config);
        public void FindDamagedBots(Dictionary<BotModel, Vector3> bot, Vector3 explosionPos, GamePhysics physics);
    }
}