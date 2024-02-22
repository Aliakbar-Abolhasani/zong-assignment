using UnityEngine;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class SetAnimBoolParameter : ObjectiveAction
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _parameterName;
        [SerializeField] private bool _value;

        public override ActionStatus Execute()
        {
            _animator.SetBool(_parameterName, _value);
            return ActionStatus.Success;
        }
    }
}