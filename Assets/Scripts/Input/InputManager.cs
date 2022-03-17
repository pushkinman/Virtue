using System;
using Extensions;
using Interfaces;

namespace Input
{
    public class InputManager : IInputManager
    {
        public IInputProvider InputProvider { get; }

        public InputManager()
        {
            InputProvider = GameObjectExtensions.CreateGameObjectWithComponent<InputProvider>();
        }
    }
}
