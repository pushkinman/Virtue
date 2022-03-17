using Interfaces;
using UnityEngine;

namespace Cameras
{
    public class Camera : MonoBehaviour, ICamera
    {
        private readonly Vector3 _cameraOffset = new Vector3(0,2,-2);

        public void SetCameraPosition(Vector3 position)
        {
            transform.position = position + _cameraOffset;
        }
    }
}
