using AOsCore.SO_System.DataVariables;
using UnityEngine;

namespace AOsCore.SO_System.Data.Variables
{
    [CreateAssetMenu(menuName="SO_SYSTEM/Data/BoolVariable")]
    public class BoolVar : DataVariable<bool>
    {
        public override void Save()
        {
            base.Save();
            
#if SO_SYSTEM_LOG
            Debug.Log($"DataVariable: {name} Saved value as {ToString()}");
#endif
        }

        public override void Load()
        {
            var loadedValue = PlayerPrefs.GetString(name, "False");
            //UnityEngine.Debug.Log($"Loading bool var: {name} value in prefs: {loadedValue}");
            if (bool.TryParse(loadedValue, out var variable))
            {
                //UnityEngine.Debug.Log($"Loading bool var from string: {name} value: {variable}");
                SetValue(variable);
            }
            else if(int.TryParse(loadedValue, out var result))
            {
                //UnityEngine.Debug.Log($"Loading bool var from int: {name} value: {result}");
                SetValue(result == 1);
            }
        }
    }
}
