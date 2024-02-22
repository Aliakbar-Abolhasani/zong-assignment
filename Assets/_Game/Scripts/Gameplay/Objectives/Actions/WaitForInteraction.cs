using UnityEngine;
using ZongDemo.Gameplay.Interactions;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class WaitForInteraction : ObjectiveAction
    {
        [SerializeField] private Interactable _interactable;

        public override ActionStatus Execute()
        {
            return _interactable.State == InteractionState.Select ? ActionStatus.Success : ActionStatus.Running;
        }
    }
}