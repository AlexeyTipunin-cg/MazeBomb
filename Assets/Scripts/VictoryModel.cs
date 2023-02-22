using System;
public class VictoryModel
{
    public event Action onVictory;

    public void OnBombBurst()
    {
        onVictory?.Invoke();
    }
}
