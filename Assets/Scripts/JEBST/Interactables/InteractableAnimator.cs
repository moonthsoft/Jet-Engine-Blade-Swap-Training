using Core.Definitions.Sounds;
using UnityEngine;

namespace JEBST
{
    /// <summary>
    /// Interactable for the GasConnection, Cover and Blade, 
    /// it is responsible for activating the animations and sounds corresponding to these elements.
    /// </summary>
    public class InteractableAnimator : Interactable
    {
        private const float TIME_OFFSET = 0.2f;

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationAction;
        [SerializeField] private Fx _audioActive;
        [SerializeField] private Fx _audioDeactive;


        private void Start()
        {
            SetAnimationState();
        }

        public override float GetDuration()
        {
            return _animationAction.length + TIME_OFFSET;
        }

        protected override void Interaction()
        {
            ActiveSound();

            SetAnimationState();
        }

        private void SetAnimationState()
        {
            _animator.SetBool("isActived", _isActived);
        }

        private void ActiveSound()
        {
            var audioAux = _isActived ? _audioActive : _audioDeactive;

            if (audioAux != Fx.None)
            {
                _audioManager.PlayFx(audioAux);
            }
        }
    }
}