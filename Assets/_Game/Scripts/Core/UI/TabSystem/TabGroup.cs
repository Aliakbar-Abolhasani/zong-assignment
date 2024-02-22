using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZongDemo.Core.UI.TabSystem
{
    public sealed class TabGroup : MonoBehaviour
    {
        [SerializeField] private List<TabButton> _tabs;
        [SerializeField] private TabButton _defaultTab;

        public List<TabButton> Tabs => _tabs;
        public TabButton SelectedTab { get; private set; }

        public event Action<TabButton> OnTabChanged;

        private void Awake()
        {
            foreach (var tab in _tabs)
            {
                tab.Initialize(this);
            }
        }

        private void Start()
        {
            if (_defaultTab != null && _tabs.Contains(_defaultTab))
            {
                SelectTab(_defaultTab);
            }
            else
            {
                SelectTab(_tabs[0]);
            }
        }

        public void SelectTab(TabButton tab)
        {
            if (!_tabs.Contains(tab))
            {
                Debug.LogError($"Tab {tab} doesn't belong to this group");
                return;
            }

            if (SelectedTab != null)
            {
                SelectedTab.Deselect();
            }

            SelectedTab = tab;
            SelectedTab.Select();
            OnTabChanged?.Invoke(SelectedTab);
        }
    }
}