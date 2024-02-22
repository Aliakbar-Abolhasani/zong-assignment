using UnityEngine;

namespace ZongDemo.Gameplay.UI
{
    public class GameplayUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _fullscreenUI;

        public void SetActiveFullScreenUI(bool active)
        {
            _fullscreenUI.SetActive(active);
        }
    }
}