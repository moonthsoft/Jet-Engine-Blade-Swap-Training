
using UnityEngine;

namespace JEBST
{
    public class ControlUnit : Interactable
    {
        private const float DURATION_INTERACTION = 0.5f;

        [SerializeField] private MeshRenderer mesh;

        [SerializeField] private Material _matOn;
        [SerializeField] private Material _matOff;


        private void Start()
        {
            SetMaterial();
        }

        public override float GetDuration()
        {
            return DURATION_INTERACTION;
        }

        protected override void Interaction()
        {
            SetMaterial();
        }

        private void SetMaterial()
        {
            mesh.material = _isActived ? _matOn : _matOff;
        }
    }
}