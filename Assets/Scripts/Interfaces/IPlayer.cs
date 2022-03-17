using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interfaces
{
    public interface IPlayer
    {
        event Action<Vector3> PositionChanged;
        Vector3 GetPlayerPosition { get; }
        void Move(Vector3 direction);
    }
}