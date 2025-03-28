using Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Core.Definitions.Scenes;

namespace JEBST
{
    public class MainMenuUI : MonoBehaviour
    {
        private ILoadSceneManager _loadSceneManager;

        [SerializeField] private Button _buttonExit;


        [Inject] private void InjectInputManager(ILoadSceneManager loadSceneManager) { _loadSceneManager = loadSceneManager; }


        private void Start()
        {
#if UNITY_WEBGL
            _buttonExit.gameObject.SetActive(false);
#endif
        }

        public void PlayGame()
        {
            _loadSceneManager.LoadScene(Scenes.BladeSwapScene);_loadSceneManager.LoadScene(Scenes.BladeSwapScene);
        }

        public void ExitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}