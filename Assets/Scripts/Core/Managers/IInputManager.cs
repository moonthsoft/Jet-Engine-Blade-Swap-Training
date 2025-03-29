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
        public Vector2 MousePos { get; }

        public event Action ClickEvent;

        public event Action PauseEvent;
    }
}