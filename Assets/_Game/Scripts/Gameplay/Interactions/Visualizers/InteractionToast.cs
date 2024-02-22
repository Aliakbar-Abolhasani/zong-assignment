using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.UI.Popups;
using ZongDemo.Core.UI.Popups.Generic;

namespace ZongDemo.Gameplay.Interactions.Visualizers
{
    public class InteractionToast : MonoBehaviour
    {
        [SerializeField] private Interactable _interactable;
        [SerializeField] private string _toastMessage;

        private IPopupService _popupService;

        private void Start()
        {
            ServiceLocator.Instance.TryGet(out _popupService);

            _interactable.StateChanged += OnInteractableStateChanged;
            OnInteractableStateChanged(_interactable.State);
        }

        private void OnInteractableStateChanged(InteractionState state)
        {
            if (state == InteractionState.Select)
            {
                _popupService
                    .GetPopup<GenericToastPopup>()
                    .SetMessage(_toastMessage)
                    .Open();
            }
        }
    }
}