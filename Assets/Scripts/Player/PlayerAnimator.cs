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

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMoveAnimation(Vector3 direction)
        {
            // if (direction.magnitude != 0)
            // {
            //     _animator.SetBool(Forward, true);
            // }
            // else
            // {
            //     _animator.SetBool(Forward, false);
            // }
        }
    }
}
