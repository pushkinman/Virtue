using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interfaces
{
    public interface IPlayer
    {
        event Action<Vector3> PositionChanged;
 
        Transform Transform { get; }
        Transform CameraTransform { get; set; }
        
        void Move(Vector2 direction);
    }
}