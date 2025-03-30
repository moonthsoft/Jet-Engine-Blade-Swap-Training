using System.Collections;
using UnityEngine;
using Zenject;
using JEBST.Definitions.Dialogues;
using Core.Definitions.Scenes;
using Core.Managers;

namespace JEBST
{
    /// <summary>
    /// Scene execution logic, which ensures that actions occur step by step in the correct order, 
    /// calling DialoguesUI to display the dialogs, CameraManager to move the camera to the correct position, 
    /// and activating the corresponding Interactables and waiting for them to be activated.
    /// </summary>
    public class SceneLogic : MonoBehaviour
    {
        private CameraManager _cameraManager;
        private ILoadSceneManager _loadSceneManager;

        [SerializeField] private DialoguesUI _dialoguesUI;

        [SerializeField] private ControlUnit _controlUnit;
        [SerializeField] private InteractableAnimator _tankConnection;
        [SerializeField] private InteractableAnimator _bladeCover;
        [SerializeField] private InteractableAnimator _oldBlade;
        [SerializeField] private InteractableAnimator _newBlade;


        [Inject] private void InjectCameraManager(CameraManager cameraManager) { _cameraManager = cameraManager; }

        [Inject] private void InjectLoadSceneManager(ILoadSceneManager loadSceneManager) { _loadSceneManager = loadSceneManager; }

        

        void Start()
        {
            StartCoroutine(StepsCoroutine());
        }

        private IEnumerator StepsCoroutine()
        {
            //START
            yield return new WaitForSeconds(2f);

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Start));


            //STEP 1: Validate the engine is off by checking the control unit.
            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.ControlUnit));

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_1));

            yield return StartCoroutine(ActiveInteractableCoroutine(_controlUnit));


            //STEP 2: Disconnect the gas tank.
            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.GasTankConnection));

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_2));

            yield return StartCoroutine(ActiveInteractableCoroutine(_tankConnection));


            //STEP 3: Remove the blade cover.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.Lateral));

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_3));

            yield return StartCoroutine(ActiveInteractableCoroutine(_bladeCover));


            //STEP 4: Remove the old blade.

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_4));

            yield return StartCoroutine(ActiveInteractableCoroutine(_oldBlade));


            //STEP 5: Insert the new blade.

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_5));

            yield return StartCoroutine(ActiveInteractableCoroutine(_newBlade));


            //STEP 6: Mount the blade cover.

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_6));

            yield return StartCoroutine(ActiveInteractableCoroutine(_bladeCover));


            //STEP 7: Connect the gas tank.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.GasTankConnection));

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_7));

            yield return StartCoroutine(ActiveInteractableCoroutine(_tankConnection));


            //STEP 8: Start the engine and test that it is working.

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.ControlUnit));

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.Step_8));

            yield return StartCoroutine(ActiveInteractableCoroutine(_controlUnit));


            //END

            yield return StartCoroutine(_cameraManager.MoveCameraCoroutine(CameraManager.Positions.General));

            yield return new WaitForSeconds(2f);

            yield return StartCoroutine(_dialoguesUI.ActiveDialogueCoroutine(Dialogue.End));

            yield return new WaitForSeconds(1f);

            _loadSceneManager.LoadScene(Scenes.MainMenu);
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