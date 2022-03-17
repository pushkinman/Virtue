using System;
using Cinemachine;
using Interfaces;
using UnityEngine;

namespace Cameras
{
    public class Camera : MonoBehaviour, ICamera
    {
        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;

        public Transform Transform => cinemachineFreeLook.transform;

        public void SetFollowTarget(Transform target)
        {
            cinemachineFreeLook.Follow = target;
        }

        public void SetLookAtTarget(Transform target)
        {
            cinemachineFreeLook.LookAt = target;
        }

        private void Update()
        {
            Debug.Log(cinemachineFreeLook.transform.forward);
        }
    }
}
