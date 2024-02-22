using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZongDemo.Gameplay.Objectives
{
    public sealed class ObjectiveSequence : ObjectiveAction
    {
        [SerializeField] private List<ObjectiveAction> _actions;

        private bool _moveToNextChild;
        private int _currentActionIndex;
        private ObjectiveAction _currentAction;

        public override void OnStart()
        {
            _moveToNextChild = true;
            _currentAction = null;
            _currentActionIndex = -1;
        }

        public override ActionStatus Execute()
        {
            if (_moveToNextChild)
            {
                _moveToNextChild = false;
                MoveNext();
            }

            var status = _currentAction.Execute();
            switch (status)
            {
                case ActionStatus.Running:
                    return ActionStatus.Running;

                case ActionStatus.Success when _currentActionIndex < _actions.Count - 1:
                    _moveToNextChild = true;
                    return ActionStatus.Running;

                case ActionStatus.Success:
                    _currentAction.OnExit();
                    _currentAction = null;
                    return ActionStatus.Success;

                default:
                    return ActionStatus.Success;
            }
        }

        public override void OnExit()
        {
            if (_currentAction != null)
            {
                _currentAction.OnExit();
            }
        }

        private void MoveNext()
        {
            if (_currentAction != null)
            {
                _currentAction.OnExit();
            }

            _currentActionIndex++;
            _currentAction = _actions[_currentActionIndex];
            _currentAction.OnStart();
        }
    }
}