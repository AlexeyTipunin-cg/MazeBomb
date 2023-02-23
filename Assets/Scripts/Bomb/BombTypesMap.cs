using System.Collections.Generic;

namespace Assets.Scripts.Bomb
{
    public static class BombTypesMap
    {
        public static readonly Dictionary<BombTypes, IBombStrategy> bombTypesMap = new Dictionary<BombTypes, IBombStrategy>
        {
            {BombTypes.Simple, new SimpleBombStrategy()}
        };
    }
}