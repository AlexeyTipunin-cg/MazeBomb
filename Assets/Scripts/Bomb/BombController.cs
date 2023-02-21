using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private BotsController _botsController;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private LayerMask _wallsMask;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        PlayerController.onDropBomb += CreateBomb;
    }

    private void OnDestroy()
    {
        PlayerController.onDropBomb -= CreateBomb;
    }

    public void CreateBomb(Vector2 clickCoords)
    {
        Ray ray = _camera.ScreenPointToRay(clickCoords);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floorMask))
        {
            var pos = hit.point + new Vector3(0, 5, 0);
            CreateBomb(pos);
        }
    }

    private void CreateBomb(Vector3 pos)
    {
        Bomb bomb = Instantiate(_bombPrefab, pos, Quaternion.identity, _parent);
        bomb.onCollision += BombBurst;
    }

    private void BombBurst(Vector3 pos, float radius, float damage)
    {
        var _bots = _botsController.GetBots();
        List<Bot> destroyedBots = new List<Bot>();

        for (int i = 0; i < _bots.Length; i++)
        {
            var bot = _bots[i];
            var distance = Vector3.Distance(pos, bot.transform.position);
            if (distance <= radius)
            {
                Vector3 direction = bot.transform.position - pos;
                Ray ray = new Ray(pos, direction);
                if (Physics.Raycast(ray, out RaycastHit hit, distance, _wallsMask))
                {
                    continue;
                }
                bot.MakeDamage(damage);


            }
        }

        foreach (var item in destroyedBots)
        {
            Destroy(item.gameObject);
        }
    }
}
