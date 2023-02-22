using Assets.Scripts.Bots;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public interface IBombStrategy
    {
        public List<BotView> FindDamagedBots(Dictionary<BotModel, BotView> bot, Vector3 explosionPos, GamePhysics physics);
    }
}