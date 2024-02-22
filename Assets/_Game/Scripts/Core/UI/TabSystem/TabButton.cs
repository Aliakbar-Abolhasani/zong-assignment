using UnityEngine;
using UnityEngine.EventSystems;

namespace ZongDemo.Core.UI.TabSystem
{
    public abstract class TabButton : MonoBehaviour, IPointerClickHandler
    {
        protected TabGroup Group { get; private set; }

        public void Initialize(TabGroup group)
        {
            Group = group;
            OnInitialized();
        }

        protected virtual void OnInitialized()
        {
        }

        public abstract void Select();

        public abstract void Deselect();

        public void OnPointerClick(PointerEventData eventData)
        {
            Group.SelectTab(this);
        }
    }
}