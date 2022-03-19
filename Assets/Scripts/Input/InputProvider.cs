using System;
using Interfaces;
using UnityEngine;

namespace Input
{
    public class InputProvider : MonoBehaviour, IInputProvider
    {
        public event Action<Vector2> PlayerMoved;
        public event Action PlayerJumped;
        public event Action<bool> FreeLookEnabled;

        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            var xMov = UnityEngine.Input.GetAxis("Horizontal");
            var yMov = UnityEngine.Input.GetAxis("Vertical");
            var moveVector = new Vector3(xMov, yMov);

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                moveVector *= 2;
            }
            
            PlayerMoved?.Invoke(moveVector);
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJumped?.Invoke();
                Debug.Log(PlayerJumped?.GetInvocationList().Length);
            }

            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                FreeLookEnabled?.Invoke(true);
            }
            if (UnityEngine.Input.GetMouseButtonUp(1))
            {
                FreeLookEnabled?.Invoke(false);
            }
            
            
        }
    }
}
