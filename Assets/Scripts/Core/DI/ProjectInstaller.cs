using UnityEngine;
using Zenject;
using Core.Managers;

namespace Core
{
    /// <summary>
    /// Class responsible for instantiating and injecting the dependencies of the game's general managers.
    /// </summary>
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        [SerializeField] private LoadSceneManager _loadSceneManager;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private AudioManager _audioManager;

        public override void InstallBindings()
        {
            var loadSceneManagerInstance = Instantiate(_loadSceneManager);
            var inputManager = Instantiate(_inputManager);
            var audioManager = Instantiate(_audioManager);

            Container.Bind<ILoadSceneManager>().FromInstance(loadSceneManagerInstance).AsSingle().NonLazy();
            Container.Bind<IInputManager>().FromInstance(inputManager).AsSingle().NonLazy();
            Container.Bind<IAudioManager>().FromInstance(audioManager).AsSingle().NonLazy();
        }
    }
}