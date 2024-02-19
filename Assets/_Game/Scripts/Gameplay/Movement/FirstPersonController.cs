using UnityEngine;

namespace ZongDemo.Gameplay.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        private readonly float SPEED_THRESHOLD = 0.1f;

        // Used public fields so that we can change it in other scripts
        public GameObject CameraRoot;
        public float WalkSpeed;
        public float SprintingSpeed;
        public float RotationSpeed;
        public float RotationDownClamp;
        public float RotationUpClamp;
        public float AccelerationRate;

        private IMovementInputs _input;
        private CharacterController _characterController;

        private float _pitchRotation;
        private float _currentSpeed;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            if (!TryGetComponent(out _input))
            {
                Debug.LogError($"No {nameof(IMovementInputs)} found on the gameObject, falling back to NullMovementInputs");
                _input = new NullMovementInputs();
            }
        }

        private void Update()
        {
            HandleMovement();
        }

        private void LateUpdate()
        {
            HandleRotation();
        }

        private void HandleMovement()
        {
            var targetSpeed = _input.IsSprinting ? SprintingSpeed : WalkSpeed;
            var direction = transform.right * _input.MovementAxis.x + transform.forward * _input.MovementAxis.y;

            // Handle acceleration
            if (direction != Vector3.zero)
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, AccelerationRate * Time.deltaTime);
                if (Mathf.Abs(_currentSpeed - targetSpeed) < SPEED_THRESHOLD)
                {
                    _currentSpeed = targetSpeed;
                }
            }
            // No deceleration
            else
            {
                _currentSpeed = 0;
            }

            _characterController.Move(direction.normalized * (_currentSpeed * Time.deltaTime));
        }

        private void HandleRotation()
        {
            // return if look axis is approximately equal to zero
            if (_input.LookAxis == Vector2.zero)
            {
                return;
            }

            _pitchRotation += _input.LookAxis.y * RotationSpeed;
            _pitchRotation = Mathf.Clamp(_pitchRotation, RotationDownClamp, RotationUpClamp);

            CameraRoot.transform.localRotation = Quaternion.Euler(_pitchRotation, 0, 0);
            transform.Rotate(Vector3.up * (_input.LookAxis.x * RotationSpeed));
        }
    }
}