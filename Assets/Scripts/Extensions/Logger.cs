using UnityEngine;

namespace Extensions
{
    public static class Logger
    {
        public static void LogMessage(this Object obj, string message)
        {
            Debug.Log($"Name: {obj.name}, message: {message}");
        }
    }
}