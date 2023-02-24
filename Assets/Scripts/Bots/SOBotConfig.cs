using UnityEngine;

namespace Assets.Scripts.Bots
{
    [CreateAssetMenu(fileName = "BotConfig", menuName = "Bot Config")]
    public class SOBotConfig : ScriptableObject
    {
        [SerializeField] private int _health;
        public int health => _health;
    }
}