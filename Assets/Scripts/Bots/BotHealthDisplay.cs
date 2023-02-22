using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bots
{
    public class BotHealthDisplay : MonoBehaviour
    {
        [SerializeField] private Image _healthBarImage;

        public void DisplayHealth(float currentHealth, float maxHealth)
        {
            _healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }
}