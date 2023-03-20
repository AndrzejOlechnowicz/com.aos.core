using System;
using UnityEngine;

namespace AOsCore.SO_System.DataVariables
{
    public abstract class DataVariable<T> : ScriptableObject, IEquatable<T>
    {
        [Multiline]
        public string Description;
        
        public T Value;

        protected event Action valueChangedAction;

        public void SetValue(T value)
        {
            //if (Value.Equals(value)) return;
#if SO_SYSTEM_LOG
            Debug.LogC($"DataVar: {name} SetValue to value: {value}", "cyan");
#endif
            Value = value;
            OnValueChangedAction();
        }

        public void SetValue(DataVariable<T> dataVariable)
        {
            Value = dataVariable.Value;
            OnValueChangedAction();
        }

        public virtual void AddValue(T value){}
        
        public virtual void RemoveValue(T value){}
        
        
        protected void OnValueChangedAction()
        {
            valueChangedAction?.Invoke();
        }

        /// <summary>
        /// Notifies Action when Value of the DataVariable is changed 
        /// </summary>
        /// <param name="action"></param>
        public void SubscribeToValueChanged(Action action)
        {
#if SO_SYSTEM_LOG
            Debug.Log($"Action: {action.Method.Name} Subscribed to value change of {name}");
#endif
            
            valueChangedAction += action;
        }

        public void UnsubscribeFromValueChanged(Action action)
        {
#if SO_SYSTEM_LOG
            Debug.Log($"Action: {action.Method.Name} Unsubscribed from value change of {name}");
#endif
            
            valueChangedAction -= action;
        }
        
        public void OnValidate()
        {
            OnValueChangedAction();
        }

        public bool Equals(T other)
        {
            return Value.Equals(other);
        }

        public override string ToString()
        {
            return $"{Value.ToString()}";
        }

        public virtual void Save()
        {
            PlayerPrefs.SetString(name, ToString());
            PlayerPrefs.Save();
        }

        public virtual void Load()
        {
            
        }

        public static implicit operator T(DataVariable<T> dataVariable)
        {
            return dataVariable.Value;
        }
        
        
    }
    
    
}
