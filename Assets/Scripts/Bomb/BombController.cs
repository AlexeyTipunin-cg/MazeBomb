using System;
using System.Collections.Generic;
using UnityEngine;

public class BombController
{
    public event Action onBombBurst;
    private BotsController _botsController;
    private BombFactory _bombFactory;
    private Camera _camera;
    private Layers _layers;

    public BombController(BotsController botsController, BombFactory bombFactory, Camera camera, Layers layers)
    {
        _botsController = botsController;
        _bombFactory = bombFactory;
        _camera = camera;
        _layers = layers;

        PlayerController.onDropBomb += CreateBomb;
    }

    public void CreateBomb(Vector2 clickCoords)
    {
        Ray ray = _camera.ScreenPointToRay(clickCoords);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layers.floorMask))
        {
            var pos = hit.point + new Vector3(0, 5, 0);
            var bomb = _bombFactory.CreateBomb(pos);
            bomb.onCollision += BombBurst;
        }
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
                if (Physics.Raycast(ray, out RaycastHit hit, distance, _layers.wallMask))
                {
                    continue;
                }
                bot.MakeDamage(damage);
            }
        }

        onBombBurst.Invoke();

        //foreach (var item in destroyedBots)
        //{
        //    Destroy(item.gameObject);
        //}
    }
}
