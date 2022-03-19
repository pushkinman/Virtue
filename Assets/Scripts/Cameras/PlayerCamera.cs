using System;
using Cinemachine;
using Interfaces;
using UnityEngine;

namespace Cameras
{
    public class PlayerCamera : MonoBehaviour, IPlayerCamera
    {
        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
        [SerializeField] private Camera camera;

        public Transform Transform => camera.transform;

        public void SetFollowTarget(Transform target)
        {
            cinemachineFreeLook.Follow = target;
        }

        public void SetLookAtTarget(Transform target)
        {
            cinemachineFreeLook.LookAt = target;
        }
    }
}
