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
        private PlayerController _playerController;
        public BombController(BotsController botsController, BombFactory bombFactory, PlayerController playerController, GamePhysics gamePhysics)
        {
            _botsController = botsController;
            _bombFactory = bombFactory;
            _gamePhysics = gamePhysics;
            _playerController = playerController;

            _playerController.onDropBomb += CreateBomb;
        }

        public void Dispose()
        {
            _playerController.onDropBomb -= CreateBomb;
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
            var _bots = _botsController.bots;
            List<BotView> destroyedBots = new List<BotView>();

            var strategy = BombTypesMap.bombTypesMap[bombType];
            strategy.FindDamagedBots(_bots, pos, _gamePhysics);


            onBombBurst?.Invoke();
        }
    }
}