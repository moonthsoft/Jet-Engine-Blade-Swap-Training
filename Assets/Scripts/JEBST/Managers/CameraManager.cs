using System.Collections;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace JEBST
{
    public class CameraManager : MonoInstaller
    {
        private const float TIME_OFFSET = 0.2f;

        public enum Positions { General = 0, ControlUnit = 1, GasTankConnection = 2, Lateral = 3 }

        private Positions _currentPos = Positions.General;

        [SerializeField] private Camera _camera;
        [SerializeField] private Animator _animator;

        [Header("ControlUnit, GasTankConnection, Lateral")]
        [SerializeField] private AnimationClip[] _transitions;

        public Camera Camera { get { return _camera; } }


        public override void InstallBindings()
        {
            Container.Bind<CameraManager>().FromInstance(this).AsSingle();
        }


        public IEnumerator MoveCameraCoroutine(Positions pos)
        {
            float timeAux;

            if (_currentPos != Positions.General)
            {
                timeAux = SetCameraPos(Positions.General);

                yield return new WaitForSeconds(timeAux);
            }

            if (pos != Positions.General)
            {
                timeAux = SetCameraPos(pos);

                yield return new WaitForSeconds(timeAux);
            }

            yield return new WaitForSeconds(TIME_OFFSET);
        }

        private float SetCameraPos(Positions pos)
        {
            if (pos == _currentPos)
            {
                Debug.LogWarning("The camera is already in that position.");
                return 0f;
            }

            if (pos != Positions.General && _currentPos != Positions.General)
            {
                Debug.LogError("The camera has to pass through the General position before changing to another position.");
                return 0f;
            }

            _animator.SetInteger("position", (int)pos);

            float timeAux = GetLengthAnimation(pos);

            _currentPos = pos;

            return timeAux;
        }

        private float GetLengthAnimation(Positions pos)
        {
            int indx;

            if (pos != Positions.General)
            {
                indx = (int)pos - 1;
            }
            else //if(_currentPos != Positions.General)
            {
                indx = (int)_currentPos - 1;
            }

            if (indx >= _transitions.Length)
            {
                Debug.LogError("There is no Animation clip for that index.");
                return 0f;
            }

            return _transitions[indx].length;
        }
    }
}