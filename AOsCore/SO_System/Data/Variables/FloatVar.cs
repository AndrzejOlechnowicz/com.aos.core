using System;
using System.Collections;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

namespace AOsCore.SO_System.Data.Variables
{
    [CreateAssetMenu(menuName="SO_SYSTEM/Data/FloatVariable")]
    public class FloatVar : DataVariable<float>
    {
        public override void AddValue(float value)
        {
            SetValue(Value + value);
        }

        public override void RemoveValue(float value)
        {
            SetValue(Value - value);
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(name, Value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            var loadedValue = PlayerPrefs.GetFloat(name, 1);
            SetValue(loadedValue);
        }
    }
    
    
}
