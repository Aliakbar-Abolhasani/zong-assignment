using System;
using UnityEngine;

namespace ZongDemo.Gameplay.Interactions.Visualizers
{
    public class InteractionHint : MonoBehaviour
    {
        [SerializeField] private Interactable _interactable;
        [SerializeField] private GameObject _hintUI;
        [SerializeField] private GameObject _buttonUI;

        private void Start()
        {
            _interactable.StateChanged += OnInteractableStateChanged;
            OnInteractableStateChanged(_interactable.State);
        }

        private void OnInteractableStateChanged(InteractionState state)
        {
            switch (state)
            {
                case InteractionState.Normal:
                    _buttonUI.SetActive(false);
                    break;
                case InteractionState.Hover:
                    _buttonUI.SetActive(true);
                    break;
                case InteractionState.Select:
                    _buttonUI.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}