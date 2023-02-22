﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public class SimpleBombStrategy : IBombStrategy
    {
        private int _radius = 4;
        private int _damage = 2;
        public List<Bot> FindDamagedBots(Bot[] bots, Vector3 explosionPos, GamePhysics physics)
        {
            List<Bot> damagedBots = new List<Bot>();

            for (int i = 0; i < bots.Length; i++)
            {
                var bot = bots[i];
                var distance = Vector3.Distance(explosionPos, bot.transform.position);
                if (distance <= _radius)
                {
                    if (physics.RaycastOnWalls(bot.transform.position, explosionPos, _radius))
                    {
                        continue;
                    }
                    bot.MakeDamage(_damage);
                }
            }

            return damagedBots;
        }
    }

}