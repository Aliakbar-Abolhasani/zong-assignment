using UnityEngine;

namespace ZongDemo.Gameplay.Movement
{
    public class NullMovementInputs : IMovementInputs
    {
        public Vector2 LookAxis { get; } = Vector2.zero;
        public Vector2 MovementAxis { get; } = Vector2.zero;
        public bool IsSprinting { get; } = false;
    }
}