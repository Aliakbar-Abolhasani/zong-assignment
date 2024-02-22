using UnityEngine;
using ZongDemo.Core;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class SetGameplayState : ObjectiveAction
    {
        [SerializeField] private GameplayState _state;

        private GameplayStateController _gameplayStateController;

        public override void OnStart()
        {
            ServiceLocator.Instance.TryGet(out _gameplayStateController);
        }

        public override ActionStatus Execute()
        {
            _gameplayStateController.SetGameplayState(_state, false);
            return ActionStatus.Success;
        }
    }
}