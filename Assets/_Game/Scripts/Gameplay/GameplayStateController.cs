using System;
using UnityEngine;
using UnityEngine.InputSystem;
using ZongDemo.Gameplay.UI;

namespace ZongDemo.Gameplay
{
    public enum GameplayState
    {
        Play,
        UI
    }

    public class GameplayStateController : MonoBehaviour
    {
        [SerializeField] private GameplayUIManager _uiManager;

        [Header("Inputs")]
        [SerializeField] private InputActionAsset _inputActionAsset;
        // We could create a separate class to handle state toggle by user input but Pain Driven Design forever :)
        [SerializeField] private InputActionProperty _uiToggleButton;
        [SerializeField] private string _genericActionMapId;
        [SerializeField] private string _playerActionMapId;
        [SerializeField] private string _uiActionMapId;

        private InputActionMap _genericActionMap;
        private InputActionMap _playerActionMap;
        private InputActionMap _uiActionMap;

        private GameplayState _currentState;

        public bool IsUserAllowedToSwitchState { get; set; } = true;

        private void Awake()
        {
            _genericActionMap = FindActionMap(_genericActionMapId);
            _playerActionMap = FindActionMap(_playerActionMapId);
            _uiActionMap = FindActionMap(_uiActionMapId);

            _genericActionMap.Enable();
        }

        private void Start()
        {
            SetGameplayState(GameplayState.Play, false);
        }

        private void OnEnable()
        {
            _uiToggleButton.action.performed += OnToggleButtonPressed;
        }

        private void OnDisable()
        {
            _uiToggleButton.action.performed -= OnToggleButtonPressed;
        }

        private void OnToggleButtonPressed(InputAction.CallbackContext ctx)
        {
            ToggleState(true);
        }

        /// <param name="initiatedByUser">Is this method being called by the player?</param>
        public void ToggleState(bool initiatedByUser)
        {
            SetGameplayState(_currentState == GameplayState.Play ? GameplayState.UI : GameplayState.Play, initiatedByUser);
        }

        /// <param name="initiatedByUser">Is this method being called by the player?</param>
        public void SetGameplayState(GameplayState state, bool initiatedByUser)
        {
            if (initiatedByUser && !IsUserAllowedToSwitchState)
            {
                return;
            }

            switch (state)
            {
                case GameplayState.Play:
                    Cursor.lockState = CursorLockMode.Locked;
                    _uiActionMap?.Disable();
                    _playerActionMap?.Enable();
                    _uiManager.SetActiveFullScreenUI(false);
                    break;

                case GameplayState.UI:
                    Cursor.lockState = CursorLockMode.None;
                    _playerActionMap?.Disable();
                    _uiActionMap?.Enable();
                    _uiManager.SetActiveFullScreenUI(true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }

            _currentState = state;
        }

        private InputActionMap FindActionMap(string id)
        {
            return string.IsNullOrEmpty(id) ? null : _inputActionAsset.FindActionMap(id);
        }
    }
}