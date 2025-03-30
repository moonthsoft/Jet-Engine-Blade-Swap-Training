using Core.Managers;
using UnityEngine;
using Zenject;

namespace JEBST
{
    /// <summary>
    /// Parent class for Interactables, which are elements that trigger logic when the player interacts with them.
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        protected IAudioManager _audioManager;
        protected bool _isActived = true;

        public bool IsActived { get { return _isActived; } }
        public bool CanInteract { get; set; } = false;


        [Inject] private void InjectAudioManager(IAudioManager audioManager) { _audioManager = audioManager; }


        public abstract float GetDuration();

        protected abstract void Interaction();


        public void ActiveInteraction()
        {
            if (CanInteract)
            {
                CanInteract = false;

                _isActived = !_isActived;

                Interaction();
            }
        }
    }
}