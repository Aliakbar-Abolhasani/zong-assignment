using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Gameplay.Interactions;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public class SetActiveInteractable : ObjectiveAction
    {
        [SerializeField] private bool _active;
        [SerializeField] private List<Interactable> _interactables;

        public override ActionStatus Execute()
        {
            foreach (var interactable in _interactables)
            {
                if (_active)
                {
                    interactable.Enable();
                }
                else
                {
                    interactable.Disable();
                }
            }

            return ActionStatus.Success;
        }
    }
}