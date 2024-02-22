using TMPro;
using UnityEngine;

namespace ZongDemo.Core.UI.Popups.Generic
{
    public class GenericToastPopup : PopupPanel
    {
        [SerializeField] private TMP_Text _message;
        [SerializeField] private float _destroyDelay;

        private void Awake()
        {
            Destroy(gameObject, _destroyDelay);
        }

        public GenericToastPopup SetMessage(string message)
        {
            _message.text = message;
            return this;
        }
    }
}