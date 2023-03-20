using UnityEngine;

namespace AOsCore.SO_System
{
    public class Debug : MonoBehaviour
    {
        public static void Log(string log)
        {
#if SO_SYSTEM_LOG
            UnityEngine.Debug.Log($"{GetTag()} {log}");
#endif
        }

        public static void LogC(string log, string color)
        {
            Log($"<color={color}> {log} </color>");
        }

        private static string GetTag()
        {
            return "[SO_System]";
        }
    }
}
