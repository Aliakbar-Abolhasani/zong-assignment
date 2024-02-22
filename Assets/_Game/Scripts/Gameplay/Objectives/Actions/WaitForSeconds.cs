using UnityEngine;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class WaitForSeconds : ObjectiveAction
    {
        [SerializeField] private float _delay;

        private float _timer;

        public override void OnStart()
        {
            _timer = 0;
        }

        public override ActionStatus Execute()
        {
            _timer += Time.deltaTime;
            return _timer >= _delay ? ActionStatus.Success : ActionStatus.Running;
        }
    }
}