using System;
using UnityEngine;

namespace Interfaces
{
    public interface IInputProvider
    {
        public event Action<Vector3> PlayerMoved;
        public event Action PlayerJumped;
    }
}