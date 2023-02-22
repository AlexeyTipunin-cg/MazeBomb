using Assets.Scripts.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    [SerializeField] private VictoryPopup _victoryPopup;
    [SerializeField] private BotsController _botsController;
    [SerializeField] private BombFactory _bombFactory;
    [SerializeField] private Layers _layers;

    private BombController _bombController;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _victoryPopup.gameObject.SetActive(false);

        _bombController = new BombController(_botsController, _bombFactory, Camera.main, _layers);
        VictoryModel victoryModel = new VictoryModel();
        _bombController.onBombBurst += victoryModel.OnBombBurst;
        victoryModel.onVictory += OnVictory;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
