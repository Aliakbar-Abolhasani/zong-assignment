using UnityEngine;

namespace ZongDemo.Utils
{
    public class CameraBillboard : MonoBehaviour
    {
        [SerializeField] private bool _yAxisOnly;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            var forward = _camera.transform.forward;
            if (_yAxisOnly)
            {
                forward.y = 0;
            }

            transform.forward = forward;
        }
    }
}