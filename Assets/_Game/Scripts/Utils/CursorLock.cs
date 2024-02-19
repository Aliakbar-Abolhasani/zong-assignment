using UnityEngine;

namespace ZongDemo.Utils
{
    public class CursorLock : MonoBehaviour
    {
        private void OnApplicationFocus(bool hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}