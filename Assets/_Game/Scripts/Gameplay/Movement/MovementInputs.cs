using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZongDemo.Gameplay.Movement
{
    /// <summary>
    ///     Default implementation of <see cref="IMovementInputs" /> compatible with the new Unity Input System
    /// </summary>
    public class MovementInputs : MonoBehaviour, IMovementInputs
    {
        [SerializeField] private InputActionProperty _lookAction;
        [SerializeField] private InputActionProperty _movementAction;
        [SerializeField] private InputActionProperty _sprintAction;

        public Vector2 LookAxis { get; private set; }
        public Vector2 MovementAxis { get; private set; }
        public bool IsSprinting { get; private set; }

        private void OnLook(InputAction.CallbackContext ctx)
        {
            LookAxis = ctx.ReadValue<Vector2>();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            MovementAxis = ctx.ReadValue<Vector2>();
        }

        private void OnSprint(InputAction.CallbackContext ctx)
        {
            IsSprinting = ctx.ReadValueAsButton();
        }

        private void OnEnable()
        {
            SubscribeActions();
        }

        private void OnDisable()
        {
            UnsubscribeActions();
        }

        private void SubscribeActions()
        {
            SubscribeAction(_lookAction, OnLook);
            SubscribeAction(_movementAction, OnMove);
            SubscribeAction(_sprintAction, OnSprint);
        }

        private void UnsubscribeActions()
        {
            UnsubscribeAction(_lookAction, OnLook);
            UnsubscribeAction(_movementAction, OnMove);
            UnsubscribeAction(_sprintAction, OnSprint);
        }

        private static void SubscribeAction(InputActionProperty action, Action<InputAction.CallbackContext> callback)
        {
            action.action.started += callback;
            action.action.performed += callback;
            action.action.canceled += callback;
        }

        private static void UnsubscribeAction(InputActionProperty action, Action<InputAction.CallbackContext> callback)
        {
            action.action.started -= callback;
            action.action.performed -= callback;
            action.action.canceled -= callback;
        }
    }
}