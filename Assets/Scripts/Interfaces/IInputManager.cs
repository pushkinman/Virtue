using System;
using Input;

namespace Interfaces
{
    public interface IInputManager
    {
        IInputProvider InputProvider { get; }
    }
}
