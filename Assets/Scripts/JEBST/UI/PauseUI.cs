using Core.Definitions.Scenes;
using Core.Managers;
using JEBST;
using System.Collections;
using UnityEngine;
using Zenject;

namespace JEBST
{
    public class PauseUI : MenuUI
    {
        private ILoadSceneManager _loadSceneManager;
        private IInputManager _inputManager;
        private bool _pause = false;
        private bool _inTransition = false;

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _transition;

        public bool IsPaused { get { return _pause || _inTransition; } }

        [Inject] private void InjectLoadSceneManager(ILoadSceneManager loadSceneManager) { _loadSceneManager = loadSceneManager; }

        [Inject] private void InjectInputManager(IInputManager inputManager) { _inputManager = inputManager; }


        private void OnEnable()
        {
            _inputManager.PauseEvent += ChangePauseState;
        }

        private void OnDisable()
        {
            _inputManager.PauseEvent -= ChangePauseState;
        }


        public void BackMainMenu()
        {
            if (CheckCooldown())
            {
                _loadSceneManager.LoadScene(Scenes.MainMenu);
            }
        }

        public void BackGame()
        {
            if (CheckCooldown())
            {
                ActivePause(false);
            }
        }

        public void ActivePause(bool active)
        {
            if (_pause != active && !_inTransition)
            {
                StartCoroutine(ActivePauseCoroutine(active));
            }
        }

        private IEnumerator ActivePauseCoroutine(bool active)
        {
            _inTransition = true;

            _pause = active;

            Time.timeScale = active ? 0f : 1f;

            _animator.SetBool("active", active);

            yield return new WaitForSecondsRealtime(_transition.length);

            _inTransition = false;
        }

        private void ChangePauseState()
        {
            ActivePause(!_pause);
        }
    }
}