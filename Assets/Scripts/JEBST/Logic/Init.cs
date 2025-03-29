using Core.Managers;
using UnityEngine;
using Zenject;
using Core.Definitions.Scenes;

namespace JEBST
{
    public class Init : MonoBehaviour
    {
        private ILoadSceneManager _loadSceneManager;


        [Inject] private void InjectLoadSceneManager(ILoadSceneManager loadSceneManager) { _loadSceneManager = loadSceneManager; }


        void Start()
        {
            Application.targetFrameRate = 60;

            _loadSceneManager.LoadScene(Scenes.MainMenu);
        }
    }
}