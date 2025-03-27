using UnityEngine;

namespace JEBST
{
    public abstract class Interactable : MonoBehaviour
    {
        protected bool _isActived = true;

        public bool CanInteract { get; set; } = false;


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