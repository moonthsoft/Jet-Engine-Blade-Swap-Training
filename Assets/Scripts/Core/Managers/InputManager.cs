using System;
using UnityEngine;

namespace Core.Managers
{
    /// <summary>
    /// InputManager is responsible for managing the player's input.
    /// It is also responsible for managing the current input device.
    /// 
    /// Since this is a small and simple project that serves as a portfolio sample, 
    /// this is an extremely simple InputManager that only checks the WASD and arrow keys for Pac-Man movement. 
    /// More complex projects should have a more elaborate InputManager.
    /// </summary>
    public class InputManager : MonoBehaviour, IInputManager
    {
        private Vector2 _mousePos = new();

        public event Action ClickEvent;

        public Vector2 MousePos { get { return _mousePos; } }


        private void Update()
        {
            UpdateMousePos();

            CheckMouseClick();
        }

        private void UpdateMousePos()
        {
            _mousePos = Input.mousePosition;
        }

        private void CheckMouseClick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ClickEvent?.Invoke();
            }
        }
    }
}