using System;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class DebugDisable : MonoBehaviour
    {
        private void OnDisable()
        {
            UnityEngine.Debug.Log($"Something disabled: {gameObject.name}");
        }
    }
}
