using AOsCore.SO_System.Data.Variables;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class FloatVariableOnAwakeResetter : MonoBehaviour
    {
        [SerializeField] private FloatVar variableToResetOnStart;
        [SerializeField] private FloatReference valueToResetTo;

        private void Awake()
        {
            UnityEngine.Debug.Log($"FloatVariable : {variableToResetOnStart.name} reset to value: {valueToResetTo.Value()}");
            variableToResetOnStart.SetValue(valueToResetTo);
        }
    }
}
