using UnityEngine;
using Object = UnityEngine.Object;

namespace ZongDemo.Core.UI.Popups
{
    public class PopupService : IPopupService
    {
        private Canvas _canvas;

        public PopupService()
        {
            SetupCanvas();
        }

        public T GetPopup<T>() where T : PopupPanel
        {
            var path = $"{Constants.ResourcePath.UI_POPUP_PATH}{typeof(T).Name}";
            var popupPrefab = Resources.Load<GameObject>(path);
            var popup = Object.Instantiate(popupPrefab, _canvas.transform).GetComponent<T>();
            return popup;
        }

        public void DisposePopup(PopupPanel popupPanel)
        {
            Object.Destroy(popupPanel.gameObject);
        }

        private void SetupCanvas()
        {
            var canvasPrefab = Resources.Load<Canvas>(Constants.ResourcePath.UI_POPUP_PATH + "PopupCanvas");
            var canvas = Object.Instantiate(canvasPrefab);
            Object.DontDestroyOnLoad(canvas);
            _canvas = canvas;
        }
    }
}