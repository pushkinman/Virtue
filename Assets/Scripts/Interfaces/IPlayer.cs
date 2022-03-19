using System;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interfaces
{
    public interface IPlayer
    {
        public PlayerAnimator PlayerAnimator { get; set; }
        Transform Transform { get; }
        Transform CameraTransform { get; set; }
        
        void Move(Vector2 direction);
        public void TryJump();
        void SetFreeLookState(bool enabled);
    }
}