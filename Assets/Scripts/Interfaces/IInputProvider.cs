using System;
using UnityEngine;

namespace Interfaces
{
    public interface IInputProvider
    {
        public event Action<Vector2> PlayerMoved;
        public event Action PlayerJumped;
        public event Action<bool> FreeLookEnabled;

    }
}