using UnityEngine;

namespace ZongDemo.Gameplay
{
    public class GeneralAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioSource _sfxAudioSource;

        public void PlaySfx(AudioClip clip)
        {
            _sfxAudioSource.PlayOneShot(clip);
        }
    }
}