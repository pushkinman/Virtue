using System;
using System.Collections;
using Extensions;
using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IPlayer
    {
        public PlayerAnimator PlayerAnimator { get; set; }
        public Transform CameraTransform { get; set; }

        private CharacterController _characterController;

        private float _moveSpeed = 1;
        private float _turnSpeed = 5;
        private float _gravity = 10.0f;
        private float _jumpSpeed = 200.0f;
        private Vector3 _jumpDirection = Vector3.zero;
        private bool _isJumping = false;
        private bool _freeLookEnabled = false;

        private void Awake()
        {
            PlayerAnimator = GetComponent<PlayerAnimator>();
            _characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }


        public Transform Transform => transform;

        public void Move(Vector2 direction)
        {
            if (!_freeLookEnabled)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward.XZPlane(),
                    CameraTransform.forward.XZPlane(), _turnSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            var xMov = CameraTransform.right * direction.x;
            var zMov = CameraTransform.forward * direction.y;
            var moveVector = (xMov + zMov).normalized.XZPlane();

            if (direction.magnitude > 1)
            {
                moveVector *= 2;
            }

            _characterController.Move(moveVector * Time.deltaTime * _moveSpeed);
        }

        public void TryJump()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), .1f) &&
                _isJumping == false)
            {
                _isJumping = true;
                _jumpDirection.y = _jumpSpeed;
                StartCoroutine(nameof(Jump));
            }
            else
            {
                _isJumping = false;
            }
        }

        private IEnumerator Jump()
        {
            _jumpDirection.y -= _gravity * Time.deltaTime;
            _characterController.Move(_jumpDirection * Time.deltaTime);
            if (!IsGrounded())
            {
                yield return null;
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), .1f);
        }

        public void SetFreeLookState(bool enabled)
        {
            _freeLookEnabled = enabled;
        }
    }
}