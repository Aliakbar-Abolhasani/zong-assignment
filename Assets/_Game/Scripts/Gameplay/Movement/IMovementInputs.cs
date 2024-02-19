using UnityEngine;

namespace ZongDemo.Gameplay.Movement
{
    public interface IMovementInputs
    {
        Vector2 LookAxis { get; }
        Vector2 MovementAxis { get; }
        bool IsSprinting { get; }
    }
}