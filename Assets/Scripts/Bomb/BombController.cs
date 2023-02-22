using Assets.Scripts.Bots;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public class BombController
    {
        public event Action onBombBurst;
        private BotsController _botsController;
        private BombFactory _bombFactory;
        private GamePhysics _gamePhysics;
        public BombController(BotsController botsController, BombFactory bombFactory, GamePhysics gamePhysics)
        {
            _botsController = botsController;
            _bombFactory = bombFactory;
            _gamePhysics = gamePhysics;

            PlayerController.onDropBomb += CreateBomb;
        }

        public void CreateBomb(Vector2 clickCoords)
        {
            if (_gamePhysics.RaycastOnFloor(clickCoords, out RaycastHit hit))
            {
                var pos = hit.point + new Vector3(0, 5, 0);
                var bomb = _bombFactory.CreateBomb(pos);
                bomb.onCollision += BombBurst;
            }
        }
        private void BombBurst(BombTypes bombType, Vector3 pos)
        {
            var _bots = _botsController.GetBots();
            List<BotView> destroyedBots = new List<BotView>();

            for (int i = 0; i < _bots.Length; i++)
            {
                var strategy = BombTypesMap.bombTypesMap[bombType];
                strategy.FindDamagedBots(_bots, pos, _gamePhysics);
            }

            onBombBurst.Invoke();
        }
    }
}