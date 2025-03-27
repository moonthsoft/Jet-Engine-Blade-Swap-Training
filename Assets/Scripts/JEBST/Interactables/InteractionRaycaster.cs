using UnityEngine;
using Zenject;
using Core.Managers;

namespace JEBST
{
    public class InteractionRaycaster : MonoBehaviour
    {
        private IInputManager _inputManager;
        private CameraManager _cameraManager;


        [Inject] private void InjectInputManager(IInputManager inputManager) { _inputManager = inputManager; }
        [Inject] private void InjectCameraManager(CameraManager cameraManager) { _cameraManager = cameraManager; }


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
            Ray ray = _cameraManager.Camera.ScreenPointToRay(_inputManager.MousePos);

            LayerMask layerMask = LayerMask.GetMask("Interactable");

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    hit.collider.gameObject.GetComponent<Interactable>().ActiveInteraction();
                }
            }
        }
    }
}