using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Definitions.Scenes;
using Core.UI;

namespace Core.Managers
{
    /// <summary>
    /// LoadSceneManager handles switching between scenes.
    /// </summary>
    public class LoadSceneManager : MonoBehaviour, ILoadSceneManager
    {
        private const float TIME_IN_LOADING_SCENE = 0.2f;

        private IEnumerator _loadCoroutine = null;
        private Scenes _currentScene;

        [SerializeField] private BlackFade _blackFade;

        public bool IsLoading { get { return _loadCoroutine != null; } }
        public Scenes GetCurrentScene { get { return _currentScene; } }


        private void Awake()
        {
            _currentScene = (Scenes)SceneManager.GetActiveScene().buildIndex;
        }

        public void LoadScene(Scenes scene)
        {
            if (_loadCoroutine != null)
            {
                Debug.LogError("You're already trying to change the scene.");
                return;
            }

            _currentScene = scene;

            StartCoroutine(_loadCoroutine = LoadLevelCoroutine(scene));
        }

        private IEnumerator LoadLevelCoroutine(Scenes _scene)
        {
            yield return StartCoroutine(_blackFade.ActiveCoroutine(true));

            //This is not necessary because Unity already resets the TimeScale to 1f when change the scene,
            //but I add it just in case they change it in the future (it wouldn't be the first time Unity does something like this)
            Time.timeScale = 1f;

            yield return LoadSceneAsync(Scenes.Loading);

            yield return new WaitForSecondsRealtime(TIME_IN_LOADING_SCENE); ;

            yield return LoadSceneAsync(_scene);

            yield return StartCoroutine(_blackFade.ActiveCoroutine(false));

            _loadCoroutine = null;
        }

        private IEnumerator LoadSceneAsync(Scenes _scene)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync((int)_scene);

            yield return async;
        }
    }
}