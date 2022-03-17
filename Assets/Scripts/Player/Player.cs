using System;
using Extensions;
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
            Vector3 newDirection = Vector3.RotateTowards(transform.forward.XZPlane(), CameraTransform.forward.XZPlane(), Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            
            var xMov = CameraTransform.right * direction.x;
            var zMov = CameraTransform.forward * direction.y;
            var moveVector = (xMov + zMov).normalized.XZPlane();
            
            _characterController.Move(moveVector * Time.deltaTime * _speed);
            PositionChanged?.Invoke(transform.position);
        }
    }
}
