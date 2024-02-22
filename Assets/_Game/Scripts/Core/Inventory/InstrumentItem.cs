using UnityEngine;

namespace ZongDemo.Core.Inventory
{
    [CreateAssetMenu(menuName = "Zong/Inventory/InstrumentItem")]
    public class InstrumentItem : InventoryItem
    {
        public Sprite Image;
        // NOTE: in an actual game more stuff should be added here about the weapon
    }
}