using System;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        public event Action<Vector3> PositionChanged;
        public Vector3 GetPlayerPosition => gameObject.transform.position;

        private IPlayerAnimator _playerAnimator;
        
        private float _speed = 1;
        
        private void Awake()
        {
            _playerAnimator = gameObject.AddComponent<PlayerAnimator>();
            PositionChanged += _playerAnimator.PlayMoveAnimation;
        }


        public void Move(Vector3 direction)
        {
            transform.Translate(direction * Time.deltaTime * _speed);
            PositionChanged?.Invoke(transform.position);
        }
    }
}
