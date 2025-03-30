using Core.Managers;
using System.Collections;
using UnityEngine;
using Zenject;
using Core.Definitions.Sounds;
using UnityEngine.UI;

namespace JEBST
{
    /// <summary>
    /// Parent class for MenuUI and PauseUI with common logic, such as managing button cooldowns, 
    /// controlling volume with the VolumeSlider, and play the button sounds.
    /// </summary>
    public abstract class MenuUI : MonoBehaviour
    {
        private const float TIME_COOLDOWN = 0.2f;

        private IAudioManager _audioManager;
        private bool _cooldownActive = false;

        [SerializeField] private Slider _sliderVolume;


        [Inject] private void InjectAudioManager(IAudioManager audioManager) { _audioManager = audioManager; }


        protected virtual void Start()
        {
            _sliderVolume.value = _audioManager.MasterVolume;
        }

        public void ChangeVolume()
        {
            _audioManager.SetVolumeMaster(_sliderVolume.value);
        }

        protected bool CheckCooldown()
        {
            if (!_cooldownActive)
            {
                _audioManager.PlayFx(Fx.ButtonUI);

                StartCoroutine(CooldwonCoroutine());

                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerator CooldwonCoroutine()
        {
            _cooldownActive = true;

            yield return new WaitForSeconds(TIME_COOLDOWN);

            _cooldownActive = false;
        }
    }
}