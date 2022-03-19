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
        private float _jumpSpeed = 5.0f;
        private float _jumpRaycastCheckLength = 0.01f;
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
            if (!IsGrounded() || _isJumping == true) return;
            _isJumping = true;
            _jumpDirection.y = _jumpSpeed;
            StartCoroutine(nameof(Jump));
        }

        private IEnumerator Jump()
        {
            do
            {
                _jumpDirection.y -= _gravity * Time.deltaTime;
                _characterController.Move(_jumpDirection * Time.deltaTime);
                yield return null;
            } while (!IsGrounded());

            _isJumping = false;
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),
                _jumpRaycastCheckLength);
        }

        public void SetFreeLookState(bool enabled)
        {
            _freeLookEnabled = enabled;
        }
    }
}