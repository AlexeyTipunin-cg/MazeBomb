using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotView : MonoBehaviour
    {
        [SerializeField] private BotHealthDisplay _healthDisplay;

        public BotHealthDisplay healthDisplay => _healthDisplay;
        public void OnKilled()
        {
            Destroy(gameObject);
            Destroy(_healthDisplay.gameObject);
        }

        public void OnHealthChanged(float currentHealth, float maxHealth)
        {
            _healthDisplay.DisplayHealth(currentHealth, maxHealth);
        }
    }
}