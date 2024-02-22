using UnityEngine;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public class TeleportToLocation : ObjectiveAction
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _teleportLocation;

        public override ActionStatus Execute()
        {
            _characterController.enabled = false;
            _characterController.transform.SetPositionAndRotation(_teleportLocation.position, _teleportLocation.rotation);
            _characterController.enabled = true;
            return ActionStatus.Success;
        }
    }
}