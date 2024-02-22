using System.Collections;
using UnityEngine;

namespace ZongDemo.Gameplay.Objectives
{
    public enum ConditionResult
    {
        Undefined,
        Running,
        Success,
        Failure
    }

    public abstract class ObjectiveCondition : ObjectiveAction
    {
        [SerializeField] private ObjectiveAction _trueAction;
        [SerializeField] private ObjectiveAction _falseAction;

        private ObjectiveAction _actionToExecute;
        private ConditionResult _conditionResult;

        public override void OnStart()
        {
            _conditionResult = ConditionResult.Running;
            _actionToExecute = null;
        }

        public sealed override ActionStatus Execute()
        {
            if (_conditionResult == ConditionResult.Running)
            {
                _conditionResult = CheckCondition();
                if (_conditionResult == ConditionResult.Running)
                {
                    return ActionStatus.Running;
                }

                _actionToExecute = _conditionResult == ConditionResult.Success ? _trueAction : _falseAction;
                _actionToExecute.OnStart();
            }

            return _actionToExecute.Execute();
        }

        public override void OnExit()
        {
            if (_actionToExecute != null)
            {
                _actionToExecute.OnExit();
            }
        }

        protected abstract ConditionResult CheckCondition();
    }
}