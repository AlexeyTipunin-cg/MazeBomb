using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotsController
    {
        private BotsProvider _botsProvider;
        private BotsFactory _botsFactory;
        private SOBotConfig _config;
        private Dictionary<BotModel, BotView> _botModelToView = new Dictionary<BotModel, BotView>();
        public bool hasBots => _botModelToView.Count > 0;

        public BotsController(BotsProvider provider, BotsFactory botsFactory, SOBotConfig config)
        {
            _botsProvider = provider;
            _botsFactory = botsFactory;
            _config = config;
        }

        public void Init()
        {
            var bots = _botsProvider.GetBots();
            foreach (var bot in bots)
            {
                BotModel model = new BotModel(_config.health);
                model.onDestroyed += OnBotKilled;

                _botsFactory.SetupBot(model, bot);
                _botModelToView.Add(model, bot);
            }
        }

        public void Dispose()
        {
            _botModelToView.Clear();
        }

        public Dictionary<BotModel, Vector3> GetModelsToPos()
        {
            var modelsToPos = _botModelToView.ToDictionary(pair => pair.Key, value => value.Value.transform.position);
            return modelsToPos;
        }
        private void OnBotKilled(BotModel model)
        {
            var bot = _botModelToView[model];
            model.onHealthChanged -= bot.OnHealthChanged;
            bot.OnKilled();
            _botModelToView.Remove(model);
        }
    }
}