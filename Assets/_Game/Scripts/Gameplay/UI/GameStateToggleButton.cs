using System;
using UnityEngine;
using UnityEngine.UI;
using ZongDemo.Core;

namespace ZongDemo.Gameplay.UI
{
    public class GameStateToggleButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private GameplayStateController _gameplayStateController;

        private void Start()
        {
            ServiceLocator.Instance.TryGet(out _gameplayStateController);

            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _gameplayStateController.SetGameplayState(GameplayState.Play, true);
        }
    }
}