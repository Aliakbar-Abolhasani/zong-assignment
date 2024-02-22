using System.Collections.Generic;
using UnityEngine;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class SetActive : ObjectiveAction
    {
        [SerializeField] private List<GameObject> _objectsToEnable;
        [SerializeField] private List<GameObject> _objectsToDisable;

        public override ActionStatus Execute()
        {
            _objectsToEnable.ForEach(x => x.SetActive(true));
            _objectsToDisable.ForEach(x => x.SetActive(false));
            return ActionStatus.Success;
        }
    }
}