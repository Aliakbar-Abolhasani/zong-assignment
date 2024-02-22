using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZongDemo.Gameplay.Interactions
{
    // NOTE: Could have made a more complex system by introducing inheritance and composition,
    // but this one will do the job for the demo
    public class Interactor : MonoBehaviour
    {
        [Header("Ray")]
        [SerializeField] private Transform _origin;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _rayDistance;

        [Header("Selection")]
        [SerializeField] private InputActionProperty _interactionButton;

        /// <summary>
        ///     Can be null
        /// </summary>
        public Interactable ActiveInteractable { get; private set; }
        public event Action<Interactable, InteractionState> ActiveInteractableStateChanged;

        private void OnEnable()
        {
            _interactionButton.action.performed += OnSelection;
            _interactionButton.action.canceled += OnDeselection;
        }

        private void OnDisable()
        {
            _interactionButton.action.performed -= OnSelection;
            _interactionButton.action.canceled -= OnDeselection;
        }

        private void Update()
        {
            if (!Physics.Raycast(_origin.position, _origin.forward, out var hit, _rayDistance, _layerMask))
            {
                SetActiveInteractableState(InteractionState.Normal);
                ActiveInteractable = null;
                return;
            }

            if (hit.collider.TryGetComponent(out InteractableReference reference))
            {
                var interactable = reference.Interactable;
                // Deselect previous one
                if (ActiveInteractable != null)
                {
                    if (ActiveInteractable == interactable)
                    {
                        return;
                    }

                    SetActiveInteractableState(InteractionState.Normal);
                }

                ActiveInteractable = interactable;
                SetActiveInteractableState(InteractionState.Hover);
            }
            else if (ActiveInteractable != null)
            {
                SetActiveInteractableState(InteractionState.Normal);
                ActiveInteractable = null;
            }
        }

        private void OnSelection(InputAction.CallbackContext ctx)
        {
            if (ActiveInteractable != null)
            {
                SetActiveInteractableState(InteractionState.Select);
            }
        }

        private void OnDeselection(InputAction.CallbackContext ctx)
        {
            if (ActiveInteractable != null && ActiveInteractable.State == InteractionState.Select)
            {
                SetActiveInteractableState(InteractionState.Hover);
            }
        }

        private void SetActiveInteractableState(InteractionState state)
        {
            ActiveInteractable.SetState(state);
            ActiveInteractableStateChanged?.Invoke(ActiveInteractable, state);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_origin.position, _origin.forward * _rayDistance);
        }
    }
}