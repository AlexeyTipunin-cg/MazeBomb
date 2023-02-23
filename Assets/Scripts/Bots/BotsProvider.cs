using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotsProvider : MonoBehaviour
    {
        public BotView[] GetBots()
        {
            return GetComponentsInChildren<BotView>();
        }
    }
}
