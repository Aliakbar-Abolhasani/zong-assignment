using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ZongDemo.Core.UI.TabSystem
{
    /// <summary>
    ///     Implementation of <see cref="TabButton" /> which handles a panel activation
    /// </summary>
    public class PanelTabButton : TabButton
    {
        [SerializeField] private GameObject _panelToActivate;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _normalSprite;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _normalTextColor;
        [SerializeField] private Color _selectedTextColor;

        protected override void OnInitialized()
        {
            Deselect();
        }

        public override void Select()
        {
            _backgroundImage.sprite = _selectedSprite;
            _text.color = _selectedTextColor;
            _panelToActivate.SetActive(true);
        }

        public override void Deselect()
        {
            _backgroundImage.sprite = _normalSprite;
            _text.color = _normalTextColor;
            _panelToActivate.SetActive(false);
        }
    }
}