using UnityEngine;

namespace Interfaces
{
    public interface ICamera
    {
        Transform Transform { get; }
        
        void SetFollowTarget(Transform target);
        void SetLookAtTarget(Transform target);
    }
}