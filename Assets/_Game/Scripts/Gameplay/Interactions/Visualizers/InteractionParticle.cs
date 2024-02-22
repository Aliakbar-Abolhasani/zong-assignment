using UnityEngine;

namespace ZongDemo.Gameplay.Interactions.Visualizers
{
    public class InteractionParticle : MonoBehaviour
    {
        [SerializeField] private Interactable _interactable;
        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private Transform _spawnPosition;

        private void Start()
        {
            _interactable.StateChanged += OnInteractableStateChanged;
            OnInteractableStateChanged(_interactable.State);
        }

        private void OnInteractableStateChanged(InteractionState state)
        {
            if (state == InteractionState.Select)
            {
                var particle = Instantiate(_particlePrefab, _spawnPosition.position, Quaternion.identity);
                particle.Play(true);
            }
        }
    }
}