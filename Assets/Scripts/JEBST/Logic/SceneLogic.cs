using System.Collections;
using UnityEngine;
using Zenject;

namespace JEBST
{
    public class SceneLogic : MonoBehaviour
    {
        private CameraManager _cameraManager;

        [SerializeField] private ControlUnit _controlUnit;
        [SerializeField] private InteractableAnimator _tankConnection;
        [SerializeField] private InteractableAnimator _bladeCover;
        [SerializeField] private InteractableAnimator _oldBlade;
        [SerializeField] private InteractableAnimator _newBlade;


        [Inject] private void InjectCameraManager(CameraManager cameraManager) { _cameraManager = cameraManager; }


        void Start()
        {
            StartCoroutine(StepsCoroutine());
        }

        private IEnumerator StepsCoroutine()
        {
            //TSTART

            //TODO: UI Welcome

            //TODO: UI Feedback start

            yield return new WaitForSeconds(1f);


            //STEP 1: Validate the engine is off by checking the control unit.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.ControlUnit));

            //TODO: UI Step 1

            yield return StartCoroutine(ActiveInteractableCoroutine(_controlUnit));


            //STEP 2: Disconnect the gas tank.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.GasTankConnection));

            //TODO: UI Step 2

            yield return StartCoroutine(ActiveInteractableCoroutine(_tankConnection));


            //STEP 3: Remove the blade cover.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.Lateral));

            //TODO: UI Step 3

            yield return StartCoroutine(ActiveInteractableCoroutine(_bladeCover));


            //STEP 4: Remove the old blade.

            //TODO: UI Step 4

            yield return StartCoroutine(ActiveInteractableCoroutine(_oldBlade));


            //STEP 5: Insert the new blade.

            //TODO: UI Step 5

            yield return StartCoroutine(ActiveInteractableCoroutine(_newBlade));


            //STEP 6: Mount the blade cover.

            //TODO: UI Step 6

            yield return StartCoroutine(ActiveInteractableCoroutine(_bladeCover));


            //STEP 7: Connect the gas tank.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.GasTankConnection));

            //TODO: UI Step 7

            yield return StartCoroutine(ActiveInteractableCoroutine(_tankConnection));


            //STEP 8: Start the engine and test that it is working.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.ControlUnit));

            //TODO: UI Step 8

            yield return StartCoroutine(ActiveInteractableCoroutine(_controlUnit));


            //END

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.General));

            //TODO: UI Feedback end

            //TODO: Return Main Menu
        }

        private IEnumerator ActiveInteractableCoroutine(Interactable interactable)
        {
            interactable.CanInteract = true;

            while (interactable.CanInteract)
            {
                yield return null;
            }

            //Tiempo en función del interactuable
            yield return new WaitForSeconds(interactable.GetDuration());
        }
    }
}