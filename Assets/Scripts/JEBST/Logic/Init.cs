using Core.Managers;
using UnityEngine;
using Zenject;
using Core.Definitions.Scenes;

namespace JEBST
{
    /// <summary>
    /// Class that is activated in the first scene where all managers are initialized, 
    /// its function is simply to adjust the FPS to 60 to prevent the application from consuming too many resources, 
    /// and to load the MainMenu scene.
    /// </summary>
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