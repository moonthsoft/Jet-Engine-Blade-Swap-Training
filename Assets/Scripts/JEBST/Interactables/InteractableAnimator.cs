using UnityEngine;

namespace JEBST
{
    public class InteractableAnimator : Interactable
    {
        private const float TIME_OFFSET = 0.2f;

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationAction;


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
            SetAnimationState();
        }

        private void SetAnimationState()
        {
            _animator.SetBool("isActived", _isActived);
        }
    }
}