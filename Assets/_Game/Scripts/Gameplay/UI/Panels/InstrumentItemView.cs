using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZongDemo.Core.Inventory;

namespace ZongDemo.Gameplay.UI.Panels
{
    public class InstrumentItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nameText;

        private InstrumentItem _item;

        public void Set(InstrumentItem item, int amount)
        {
            _item = item;
            _image.sprite = item.Image;
            _nameText.text = item.Name;
        }
    }
}