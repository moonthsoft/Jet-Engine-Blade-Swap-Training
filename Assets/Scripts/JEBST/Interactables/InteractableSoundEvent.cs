using Core.Definitions.Sounds;
using Core.Managers;
using UnityEngine;
using Zenject;

namespace JEBST
{
    /// <summary>
    /// Class that is responsible for activating sounds during InteractableAnimator animations, 
    /// so that said sounds are synchronized with the animation.
    /// </summary>
    public class InteractableSoundEvent : MonoBehaviour
    {
        protected IAudioManager _audioManager;

        [SerializeField] private InteractableAnimator _Interactable;
        [SerializeField] private Fx _audioActive;
        [SerializeField] private Fx _audioDeactive;


        [Inject] private void InjectAudioManager(IAudioManager audioManager) { _audioManager = audioManager; }


        public void EventSoundActive()
        {
            if (_Interactable.IsActived)
            {
                ActiveSound(_audioActive);
            }

        }

        public void EventSoundDeactive()
        {
            if (!_Interactable.IsActived)
            {
                ActiveSound(_audioDeactive);
            }
        }

        private void ActiveSound(Fx audio)
        {
            if (audio != Fx.None)
            {
                _audioManager.PlayFx(audio);
            }
        }
    }
}
