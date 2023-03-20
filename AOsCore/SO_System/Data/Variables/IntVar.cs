using System;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

namespace AOsCore.SO_System.Data.Variables
{
    [CreateAssetMenu(menuName="SO_SYSTEM/Data/IntVariable")]
    public class IntVar : DataVariable<int>
    {
        public override void AddValue(int value)
        {
            SetValue(Value + value);
        }

        public void AddValue(IntVar value)
        {
            SetValue(Value + value);
        }

        public override void RemoveValue(int value)
        {
            SetValue(Value - value);
        }
        
        public override void Save()
        {
            PlayerPrefs.SetInt(name, Value);
            PlayerPrefs.Save();
            //SetValue(loadedValue);
        }

        public override void Load()
        {
            var loadedValue = PlayerPrefs.GetInt(name, 0);
            //UnityEngine.Debug.Log($"Loaded intVar {name} loadedValue: {loadedValue}");
            SetValue(loadedValue);
        }
    }
}
