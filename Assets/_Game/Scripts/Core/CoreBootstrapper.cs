using UnityEngine;
using ZongDemo.Core.Inventory;
using ZongDemo.Core.PlayerStats;
using ZongDemo.Core.UI.Popups;

namespace ZongDemo.Core
{
    public class CoreBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Instance
                .Register<IInventoryService>(new InMemoryInventoryService())
                .Register<IPlayerStatsService>(new InMemoryPlayerStatsService())
                .Register<IPopupService>(new PopupService());
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance
                .Unregister<IInventoryService>()
                .Unregister<IPlayerStatsService>()
                .Unregister<IPopupService>();
        }
    }
}