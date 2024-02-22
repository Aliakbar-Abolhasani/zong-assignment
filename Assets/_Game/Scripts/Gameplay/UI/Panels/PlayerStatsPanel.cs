using TMPro;
using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.PlayerStats;

namespace ZongDemo.Gameplay.UI.Panels
{
    // We could make this more extensible by introducing a generic PlayerStatsItemView
    // but since we only have one stats (points) it is not needed
    public class PlayerStatsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointsText;

        private IPlayerStatsService _playerStatsService;

        private void OnEnable()
        {
            if (_playerStatsService == null)
            {
                ServiceLocator.Instance.TryGet(out _playerStatsService);
            }

            _pointsText.text = _playerStatsService.Points.ToString();
        }
    }
}