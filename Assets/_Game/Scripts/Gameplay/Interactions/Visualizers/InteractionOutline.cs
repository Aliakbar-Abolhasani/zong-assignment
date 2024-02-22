using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZongDemo.Gameplay.Interactions.Visualizers
{
    public class InteractionOutline : MonoBehaviour
    {
        [SerializeField] private Interactable _interactable;
        [SerializeField] private Material _outlineMaterial;
        [SerializeField] private List<Renderer> _renderers;

        private static readonly int s_enabled = Shader.PropertyToID("_Enabled");
        private Material m_outlineMaterialInstance;

        private void Start()
        {
            Initialize();

            _interactable.StateChanged += OnInteractableStateChanged;
            OnInteractableStateChanged(_interactable.State);
        }

        private void OnInteractableStateChanged(InteractionState state)
        {
            switch (state)
            {
                case InteractionState.Select:
                case InteractionState.Normal:
                    DisableOutline();
                    break;
                case InteractionState.Hover:
                    EnableOutline();
                    break;
            }
        }

        private void Initialize()
        {
            m_outlineMaterialInstance = new Material(_outlineMaterial);
            foreach (var r in _renderers)
            {
                var oldMaterials = r.materials;
                var length = oldMaterials.Length;
                var newMaterials = new Material[length + 1];
                Array.Copy(oldMaterials, newMaterials, length);
                newMaterials[length] = m_outlineMaterialInstance;
                r.materials = newMaterials;
            }
        }

        private void EnableOutline()
        {
            m_outlineMaterialInstance.SetFloat(s_enabled, 1);
        }

        private void DisableOutline()
        {
            m_outlineMaterialInstance.SetFloat(s_enabled, 0);
        }
    }
}