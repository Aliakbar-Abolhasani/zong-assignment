using System;
using UnityEngine;

namespace ZongDemo.Gameplay.Interactions
{
    // NOTE: Could have made a more complex system by introducing inheritance and composition,
    // but this one will do the job for the demo
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private bool _enableByDefault;
        [SerializeField] private Collider _collider;

        public event Action<InteractionState> StateChanged;
        public InteractionState State { get; private set; } = InteractionState.Normal;

        private void Awake()
        {
            if (_enableByDefault)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }

        public void Enable()
        {
            _collider.enabled = true;
        }

        public void Disable()
        {
            _collider.enabled = false;
        }

        public void SetState(InteractionState state)
        {
            // Debug.Log($"{gameObject.name}: setting interaction state to {state}", gameObject);
            State = state;
            StateChanged?.Invoke(state);
        }
    }
}