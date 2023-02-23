using Assets.Scripts.Bots;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public class SimpleBombStrategy : IBombStrategy
    {
        private int _radius = 4;
        private int _damage = 2;
        public void FindDamagedBots(Dictionary<BotModel, Vector3> bot, Vector3 explosionPos, GamePhysics physics)
        {
            List<BotModel> damagedBots = new List<BotModel>();

            foreach (var botPair in bot)
            {
                var botPos = botPair.Value;
                var distance = Vector3.Distance(explosionPos, botPos);
                if (distance <= _radius)
                {
                    if (physics.RaycastOnWalls(botPos, explosionPos, _radius))
                    {
                        continue;
                    }
                    damagedBots.Add(botPair.Key);
                }
            }

            foreach (var botModel in damagedBots)
            {
                botModel.MakeDamage(_damage);
            }
        }
    }

}