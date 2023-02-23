using Assets.Scripts.Bots;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Bomb
{
    public class SimpleBombStrategy : IBombStrategy
    {
        private SOBombConfig _bombConfig;
        public void SetConfig(SOBombConfig config)
        {
            _bombConfig = config;
        }

        public void FindDamagedBots(Dictionary<BotModel, Vector3> bot, Vector3 explosionPos, GamePhysics physics)
        {
            Assert.IsNotNull(_bombConfig, "Bomb SO config is null");

            List<BotModel> damagedBots = new List<BotModel>();

            foreach (var botPair in bot)
            {
                var botPos = botPair.Value;
                var distance = Vector3.Distance(explosionPos, botPos);
                if (distance <= _bombConfig.radius)
                {
                    if (physics.RaycastOnWalls(botPos, explosionPos, _bombConfig.radius))
                    {
                        continue;
                    }
                    damagedBots.Add(botPair.Key);
                }
            }

            foreach (var botModel in damagedBots)
            {
                botModel.MakeDamage(_bombConfig.damage);
            }
        }
    }

}