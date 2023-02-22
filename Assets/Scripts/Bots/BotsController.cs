using UnityEngine;

namespace Assets.Scripts.Bots
{
    public class BotsController : MonoBehaviour
    {
        public BotView[] GetBots()
        {
            return GetComponentsInChildren<BotView>();
        }
    }
}