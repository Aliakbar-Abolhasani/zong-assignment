namespace ZongDemo.Core.UI.Popups
{
    public interface IPopupService
    {
        public T GetPopup<T>() where T : PopupPanel;
        public void DisposePopup(PopupPanel popupPanel);
    }
}