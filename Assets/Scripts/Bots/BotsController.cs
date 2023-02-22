using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Bots
{
    public class BotsController : MonoBehaviour
    {
        private Dictionary<BotModel, BotView> _botModelToView = new Dictionary<BotModel, BotView>();
        public Dictionary<BotModel, BotView> bots => _botModelToView;
        private BotView[] GetBots()
        {
            return GetComponentsInChildren<BotView>();
        }
        private void Start()
        {
            var bots = GetBots().ToList();
            foreach (var bot in bots)
            {
                BotModel model = new BotModel();
                model.onHealthChanged += bot.OnHealthChanged;
                model.onDestroyed += OnBotKilled;
                _botModelToView.Add(model, bot);
            }
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