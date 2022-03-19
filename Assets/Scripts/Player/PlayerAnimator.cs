using System;
using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        private Animator _animator;
        private static readonly int Forward = Animator.StringToHash("Forward");
        private static readonly int Right = Animator.StringToHash("Right");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMoveAnimation(Vector2 direction)
        {
            _animator.SetFloat(Forward, direction.y);
            _animator.SetFloat(Right, direction.x);
        }
    }
}
