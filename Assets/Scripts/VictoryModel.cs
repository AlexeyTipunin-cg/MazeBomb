using Assets.Scripts.Bots;
using System;
public class VictoryModel
{
    public event Action onVictory;
    private BotsController _botsController;

    public VictoryModel(BotsController botsController)
    {
        _botsController = botsController;
    }

    public void OnBombBurst()
    {
        if (_botsController.bots.Count <= 0)
        {
            onVictory?.Invoke();
        }
    }
}
