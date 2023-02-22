using Assets.Scripts.Bomb;
using Assets.Scripts.Bots;
using Assets.Scripts.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    [SerializeField] private VictoryPopup _victoryPopup;
    [SerializeField] private BotsController _botsController;
    [SerializeField] private BombFactory _bombFactory;
    [SerializeField] private GamePhysics _gamePhysics;

    private BombController _bombController;
    private VictoryModel _victoryModel;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _victoryPopup.gameObject.SetActive(false);

        _bombController = new BombController(_botsController, _bombFactory, _gamePhysics);
        _victoryModel = new VictoryModel(_botsController);

        _bombController.onBombBurst += _victoryModel.OnBombBurst;
        _victoryModel.onVictory += OnVictory;
        _victoryPopup.restartGame += RestartScene;
    }

    private void OnDestroy()
    {
        _victoryPopup.restartGame -= RestartScene;
    }

    private void OnVictory()
    {
        _victoryPopup.gameObject.SetActive(true);
    }

    private void RestartScene()
    {
        _bombController.onBombBurst -= _victoryModel.OnBombBurst;
        _bombController.Dispose();
        _bombController = null;
        _victoryModel.onVictory -= OnVictory;
        _victoryPopup.restartGame -= RestartScene;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
