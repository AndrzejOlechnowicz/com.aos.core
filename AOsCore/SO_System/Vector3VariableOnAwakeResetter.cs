using AOsCore.SO_System.Data.References;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class Vector3VariableOnAwakeResetter : MonoBehaviour
    {
        [SerializeField] private Vector3Var variableToResetOnStart;
        [SerializeField] private Vector3Reference valueToResetTo;
        
        private void Awake()
        {
            UnityEngine.Debug.Log($"Vector3Variable : {variableToResetOnStart.name} reset to value: {valueToResetTo.Value()}");
            variableToResetOnStart.SetValue(valueToResetTo);
        }
    }
}
