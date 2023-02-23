using System.Collections.Generic;

namespace Assets.Scripts.Bomb
{
    public class BombsConfig
    {
        public static readonly Dictionary<BombTypes, IBombStrategy> bombTypesMap = new Dictionary<BombTypes, IBombStrategy>
        {
            {BombTypes.Simple, new SimpleBombStrategy()}
        };
        public BombsConfig(SOAllBombsConfig  config)
        {
            foreach (var bombConfig in config.config)
            {
                bombTypesMap[bombConfig.type].SetConfig(bombConfig);
            }
        }

    }
}