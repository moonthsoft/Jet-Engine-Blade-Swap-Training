using Core.Definitions.Sounds;
using UnityEngine;

namespace JEBST
{
    /// <summary>
    /// Interactable for the Control Unit, when activated, it should change its state from off to on, 
    /// changing the material to show the texture with the screen off/on, in addition to activating the corresponding sounds. 
    /// It also manages the engine's looped sound.
    /// </summary>
    public class ControlUnit : Interactable
    {
        private const float DURATION_INTERACTION = 0.5f;

        private AudioSource _engineLoopAS;

        [SerializeField] private MeshRenderer mesh;
        [SerializeField] private Material _matOn;
        [SerializeField] private Material _matOff;
        

        private void Start()
        {
            ActiveEngineSound();

            SetMaterial();
        }

        private void OnDisable()
        {
            _engineLoopAS.Stop();
        }

        public override float GetDuration()
        {
            return DURATION_INTERACTION;
        }

        protected override void Interaction()
        {
            _audioManager.PlayFx(_isActived ? Fx.TurnOn : Fx.TurnOff);

            ActiveEngineSound();

            SetMaterial();
        }

        private void SetMaterial()
        {
            mesh.material = _isActived ? _matOn : _matOff;
        }

        private void ActiveEngineSound()
        {
            if (_isActived)
            {
                _engineLoopAS = _audioManager.PlayFx(Fx.JetEngineLoop, true);
            }
            else 
            {
                _engineLoopAS.Stop();
            }
        }
    }
}