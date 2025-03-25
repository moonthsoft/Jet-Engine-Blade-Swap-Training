using UnityEngine;
using Zenject;
using Core.Managers;

namespace JEBST
{
    public class InteractionManager : MonoBehaviour
    {
        private IInputManager _inputManager;

        [Inject] private void InjectInputManager(IInputManager inputManager) { _inputManager = inputManager; }

        private void OnEnable()
        {
            _inputManager.ClickEvent += OnPlayerClick;
        }

        private void OnDisable()
        {
            _inputManager.ClickEvent -= OnPlayerClick;
        }

        private void OnPlayerClick()
        {
            Debug.Log("Click");


            //TODO:
            //Hacer el camera manager
            Camera camera = Camera.main;


            Ray ray = camera.ScreenPointToRay(_inputManager.MousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Collider"))
                {
                    hit.collider.gameObject.GetComponent<InteractionCollider>().EjecutarLogica();
                }
            }
        }
    }
}