using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.PlayerStats;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class GivePoints : ObjectiveAction
    {
        [SerializeField] private int _pointsToAdd;

        private IPlayerStatsService _playerStatsService;

        public override void OnStart()
        {
            ServiceLocator.Instance.TryGet(out _playerStatsService);
        }

        public override ActionStatus Execute()
        {
            _playerStatsService.AddPoints(_pointsToAdd);
            return ActionStatus.Success;
        }
    }
}