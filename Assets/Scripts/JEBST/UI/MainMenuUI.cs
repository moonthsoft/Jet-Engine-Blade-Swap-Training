using Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Core.Definitions.Scenes;
using System.Collections;

namespace JEBST
{
    public class MainMenuUI : MenuUI
    {
        private ILoadSceneManager _loadSceneManager;

        [SerializeField] private Button _buttonExit;


        [Inject] private void InjectLoadSceneManager(ILoadSceneManager loadSceneManager) { _loadSceneManager = loadSceneManager; }


        private void Start()
        {
#if UNITY_WEBGL
            _buttonExit.gameObject.SetActive(false);
#endif
        }

        public void PlayGame()
        {
            if (CheckCooldown())
            {
                _loadSceneManager.LoadScene(Scenes.BladeSwapScene);
            }
        }

        public void ExitGame()
        {
            if (CheckCooldown())
            {
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}