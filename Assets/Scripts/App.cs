using Assets.Scripts.Bomb;
using Assets.Scripts.Bots;
using Assets.Scripts.GameModels;
using Assets.Scripts.Input;
using Assets.Scripts.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private VictoryPopup _victoryPopup;
    [SerializeField] private BotsProvider _botProvider;
    [SerializeField] private BotsFactory _botFactory;
    [SerializeField] private BombFactory _bombFactory;
    [SerializeField] private GamePhysics _gamePhysics;
    [SerializeField] private SOAllBombsConfig _soBombsConfig;

    private BombController _bombController;
    private BotsController _botsController;
    private VictoryModel _victoryModel;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _victoryPopup.gameObject.SetActive(false);

        BombsConfig bombsConfig = new BombsConfig(_soBombsConfig);

        _botsController = new BotsController(_botProvider, _botFactory);
        _bombController = new BombController(_botsController, _bombFactory, _playerController, _gamePhysics);
        _victoryModel = new VictoryModel(_botsController);

        _bombController.onBombBurst += _victoryModel.OnBombBurst;
        _victoryModel.onVictory += OnVictory;
        _victoryPopup.restartGame += RestartScene;

        _botsController.Init();
    }

    private void Dispose()
    {
        _bombController.onBombBurst -= _victoryModel.OnBombBurst;
        _victoryModel.onVictory -= OnVictory;
        _victoryPopup.restartGame -= RestartScene;

        _botsController.Dispose();
        _bombController.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    private void OnVictory()
    {
        _victoryPopup.gameObject.SetActive(true);
    }

    private void RestartScene()
    {
        Dispose();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
