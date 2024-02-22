using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Gameplay.Interactions;

namespace ZongDemo.Gameplay.Objectives.Conditions
{
    public sealed class InteractionSelectionCondition : ObjectiveCondition
    {
        [SerializeField] private Interactor _interactor;
        [SerializeField] private List<Interactable> _interactablesForTrueCase;
        [SerializeField] private List<Interactable> _interactablesForFalseCase;

        private ConditionResult _result;

        public override void OnStart()
        {
            base.OnStart();
            _result = ConditionResult.Running;
            _interactor.ActiveInteractableStateChanged += OnActiveInteractableStateChanged;
        }

        public override void OnExit()
        {
            base.OnExit();
            _interactor.ActiveInteractableStateChanged -= OnActiveInteractableStateChanged;
        }

        protected override ConditionResult CheckCondition()
        {
            return _result;
        }

        private void OnActiveInteractableStateChanged(Interactable interactable, InteractionState state)
        {
            if (state != InteractionState.Select)
            {
                return;
            }

            // if interactable is part of the TrueCase interactables then set the result to true, otherwise set it to false
            _result = _interactablesForTrueCase.Contains(interactable) ? ConditionResult.Success : ConditionResult.Failure;
        }
    }
}