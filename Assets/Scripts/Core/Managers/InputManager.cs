﻿using System;
using UnityEngine;

namespace Core.Managers
{
    /// <summary>
    /// InputManager is responsible for managing the player's input.
    /// It is also responsible for managing the current input device.
    /// 
    /// In this case, it only takes care of updating the mouse position,
    /// checking when the player clicks the mouse,
    /// And if Esc or P was pressed for the pause.
    /// </summary>
    public class InputManager : MonoBehaviour, IInputManager
    {
        private Vector2 _mousePos = new();

        public event Action ClickEvent;
        public event Action PauseEvent;

        public Vector2 MousePos { get { return _mousePos; } }


        private void Update()
        {
            UpdateMousePos();

            CheckMouseClick();

            CheckPause();
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

        private void CheckPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape)
                || Input.GetKeyDown(KeyCode.P))
            {
                PauseEvent?.Invoke();
            }
        }
    }
}