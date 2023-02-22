using UnityEngine;

namespace Assets.Scripts.Bomb
{
    public class BombFactory : MonoBehaviour
    {
        [SerializeField] private BombView _bombPrefab;
        [SerializeField] private Transform _bombsContainer;

        public IBombView CreateBomb(Vector3 pos)
        {
            BombView bomb = Instantiate(_bombPrefab, pos, Quaternion.identity, _bombsContainer);
            return bomb;
        }
    }
}