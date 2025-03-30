using System;
using UnityEngine;

namespace Core.Managers
{
    /// <summary>
    /// Interface for the InputManager.
    /// InputManager is responsible for managing the player's input.
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// Mouse position on the screen.
        /// </summary>
        public Vector2 MousePos { get; }


        /// <summary>
        /// Event that is invoked when the player clicks the mouse.
        /// </summary>
        public event Action ClickEvent;


        /// <summary>
        /// Event that is invoked when the player presses the Esc or P key.
        /// </summary>
        public event Action PauseEvent;
    }
}