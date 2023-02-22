using UnityEngine;

public class BombFactory : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _bombsContainer;

    public Bomb CreateBomb(Vector3 pos)
    {
        Bomb bomb = Instantiate(_bombPrefab, pos, Quaternion.identity, _bombsContainer);
        return bomb;
    }
}
