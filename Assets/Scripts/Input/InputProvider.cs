using System;
using Interfaces;
using UnityEngine;

namespace Input
{
    public class InputProvider : MonoBehaviour, IInputProvider
    {
        public event Action<Vector2> PlayerMoved;
        public event Action PlayerJumped;
    
        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            var xMov = UnityEngine.Input.GetAxis("Horizontal");
            var yMov = UnityEngine.Input.GetAxis("Vertical");
            var moveVector = new Vector3(xMov, yMov);

            if (moveVector.magnitude != 0)
            {
                PlayerMoved?.Invoke(moveVector);
            }

            var jumped = UnityEngine.Input.GetKeyDown(KeyCode.Space);
            if (jumped == true)
            {
                PlayerJumped?.Invoke();
            }
        }
    }
}
