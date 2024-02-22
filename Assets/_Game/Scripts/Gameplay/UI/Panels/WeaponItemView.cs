using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZongDemo.Core.Inventory;

namespace ZongDemo.Gameplay.UI.Panels
{
    public class WeaponItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nameText;

        private WeaponItem _item;

        public void Set(WeaponItem item, int amount)
        {
            _item = item;
            _image.sprite = item.Image;
            _nameText.text = item.Name;
        }
    }
}