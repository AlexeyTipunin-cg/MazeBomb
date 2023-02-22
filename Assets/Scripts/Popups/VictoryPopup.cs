using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Popups
{
    public class VictoryPopup : MonoBehaviour
    {
        public event Action restartGame;
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(OnRestartClick);
        }

        private void OnRestartClick()
        {
            restartGame?.Invoke();
        }
    }
}