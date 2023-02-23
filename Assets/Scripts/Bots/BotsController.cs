using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotsController
    {
        private BotsProvider _botsProvider;
        private BotsFactory _botsFactory;
        private Dictionary<BotModel, BotView> _botModelToView = new Dictionary<BotModel, BotView>();
        public bool hasBots => _botModelToView.Count > 0;

        public BotsController(BotsProvider provider, BotsFactory botsFactory)
        {
            _botsProvider = provider;
            _botsFactory = botsFactory;
        }

        public void Init()
        {
            var bots = _botsProvider.GetBots();
            foreach (var bot in bots)
            {
                BotModel model = new BotModel();
                model.onDestroyed += OnBotKilled;

                _botsFactory.SetupBot(model, bot);

                model.onHealthChanged += bot.OnHealthChanged;
                _botModelToView.Add(model, bot);
            }
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