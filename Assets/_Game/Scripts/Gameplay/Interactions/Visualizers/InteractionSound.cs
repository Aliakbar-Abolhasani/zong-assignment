using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZongDemo.Core;

namespace ZongDemo.Gameplay.Interactions.Visualizers
{
    public class InteractionSound : MonoBehaviour
    {
        [Serializable]
        private class StateAudioClip
        {
            public InteractionState State;
            public AudioClip Audio;
        }

        [SerializeField] private Interactable _interactable;
        [SerializeField] private List<StateAudioClip> _clips;

        private GeneralAudioController _audioController;

        private void Start()
        {
            ServiceLocator.Instance.TryGet(out _audioController);

            _interactable.StateChanged += OnInteractableStateChanged;
            OnInteractableStateChanged(_interactable.State);
        }

        private void OnInteractableStateChanged(InteractionState state)
        {
            var clip = _clips.FirstOrDefault(x => x.State == state);
            if (clip != null)
            {
                _audioController.PlaySfx(clip.Audio);
            }
        }
    }
}