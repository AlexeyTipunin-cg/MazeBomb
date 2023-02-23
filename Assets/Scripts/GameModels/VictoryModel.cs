using Assets.Scripts.Bots;
using System;

namespace Assets.Scripts.GameModels
{
    public class VictoryModel
    {
        public event Action onVictory;
        private BotsController _botsController;

        public VictoryModel(BotsController botsController)
        {
            _botsController = botsController;
        }

        public void OnBombBurst()
        {
            if (!_botsController.hasBots)
            {
                onVictory?.Invoke();
            }
        }
    }
}

