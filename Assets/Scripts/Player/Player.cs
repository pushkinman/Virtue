using System;
using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, IPlayer
    {
        public event Action<Vector3> PositionChanged;

        public Transform CameraTransform { get; set; }
        
        private IPlayerAnimator _playerAnimator;
        private CharacterController _characterController;
        
        private float _speed = 1;
        
        private void Awake()
        {
            _playerAnimator = gameObject.AddComponent<PlayerAnimator>();
            
            _characterController = GetComponent<CharacterController>();
            
            PositionChanged += _playerAnimator.PlayMoveAnimation;
        }


        public Transform Transform => transform;

        public void Move(Vector2 direction)
        {
            // Debug.Log(CameraTransform.forward);
            var xMov = CameraTransform.forward.x * direction.x;
            var zMov = CameraTransform.forward.z * direction.y;
            var moveVector = new Vector3(xMov, 0, zMov);
            
            _characterController.Move(moveVector * Time.deltaTime * _speed);
            PositionChanged?.Invoke(transform.position);
        }
    }
}
