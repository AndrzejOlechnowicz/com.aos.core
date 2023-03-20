using System;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class StringVariableOnStartReseter : MonoBehaviour
    {
        [SerializeField] private StringVar variableToReset;
        [SerializeField] private StringVar resetValue;

        private void Awake()
        {
            variableToReset.SetValue(resetValue);
        }
    }
}
