using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bots
{
    public class BotHealthDisplay : MonoBehaviour
    {
        [SerializeField] private BotView _bot;
        [SerializeField] private Image _healthBarImage;

        private void Start()
        {
            _bot.onHealthChanged += DisplayHealth;
        }

        private void OnDestroy()
        {
            _bot.onHealthChanged -= DisplayHealth;
        }

        private void DisplayHealth(float currentHealth, float maxHealth)
        {
            _healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }
}