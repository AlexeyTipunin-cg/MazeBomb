using UnityEngine;

namespace Assets.Scripts.Bomb
{
    [CreateAssetMenu(fileName = "BombsConfig", menuName = "All Bombs Config")]
    public class SOAllBombsConfig : ScriptableObject
    {
        [SerializeField] private SOBombConfig[] _config;
        public SOBombConfig[] config => _config;

    }
}