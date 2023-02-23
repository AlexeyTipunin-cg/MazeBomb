using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Bots
{
    public class BotsFactory : MonoBehaviour
    {
        [SerializeField] private Canvas _healthCanvas;

        public void SetupBot(BotModel model, BotView view)
        {
            model.onHealthChanged += view.OnHealthChanged;
            view.healthDisplay.transform.SetParent(_healthCanvas.transform, true);
        }
    }
}