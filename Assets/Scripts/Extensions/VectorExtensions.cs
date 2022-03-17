using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 XZPlane(this Vector3 vec)
        {
            return new Vector3(vec.x,0,vec.z);
        }
    }
}