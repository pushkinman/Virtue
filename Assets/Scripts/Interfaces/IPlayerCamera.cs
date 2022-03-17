using UnityEngine;

namespace Interfaces
{
    public interface IPlayerCamera
    {
        Transform Transform { get; }
        
        void SetFollowTarget(Transform target);
        void SetLookAtTarget(Transform target);
    }
}