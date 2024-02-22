using UnityEngine;

namespace ZongDemo.Core.UI.Popups
{
    public class PopupPanel : MonoBehaviour
    {
        private IPopupService _popupService;

        private void Start()
        {
            ServiceLocator.Instance.TryGet(out _popupService);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            _popupService.DisposePopup(this);
        }
    }
}