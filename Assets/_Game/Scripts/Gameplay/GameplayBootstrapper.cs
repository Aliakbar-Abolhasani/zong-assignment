using UnityEngine;
using ZongDemo.Core;

namespace ZongDemo.Gameplay
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameplayStateController _stateController;
        [SerializeField] private GeneralAudioController _audioController;

        private void Awake()
        {
            ServiceLocator.Instance
                .Register<GameplayStateController>(_stateController)
                .Register<GeneralAudioController>(_audioController);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance
                .Unregister<GameplayStateController>()
                .Unregister<GeneralAudioController>();
        }
    }
}