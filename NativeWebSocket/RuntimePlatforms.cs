using System;

namespace NativeWebSocket
{

    /// <summary>
    /// A class that contains the information about the runtime environment.
    /// </summary>
    public static class RuntimePlatforms
    {
        private const string WebGLPlayer = "WebGLPlayer";

        /// <summary>
        /// Return True if running on Unity, False otherwise
        /// </summary>
        /// <returns>Return True if running on Unity, False otherwise</returns>
        public static bool IsUnityPlayer()
        {
            try
            {
                if (Type.GetType("UnityEngine.GameObject, UnityEngine") != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Return True if running on Unity, False otherwise
        /// </summary>
        /// <returns>Return True if running on Unity, False otherwise</returns>
        public static bool IsWebGL()
        {
            if (!IsUnityPlayer())
            {
                return false;
            }

            string platform = GetRuntimePlatform();
            return platform == WebGLPlayer || string.IsNullOrEmpty(platform);
        }

        /// <summary>
        /// Return the runtime platform using reflection if running on Unity, otherwise return null
        /// </summary>
        /// <returns></returns>
        public static string GetRuntimePlatform()
        {
            return Type.GetType("UnityEngine.Device.Application, UnityEngine")?.GetMethod("get_platform")
                ?.Invoke(null, null)
                .ToString();
        }
    }
}