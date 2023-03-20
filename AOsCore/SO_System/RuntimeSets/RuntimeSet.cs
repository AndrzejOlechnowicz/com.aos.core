using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AOsCore.SO_System.RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject, IEnumerable<T>
    {
        public List<T> Items = new List<T>();

        public virtual void Add(T t)
        {
            if (!Items.Contains(t))
            {
                Items.Add(t);
                UnityEngine.Debug.LogError($"Item: {t.ToString()} added to set: {name}");
            }
        }

        public void Remove(T t)
        {
            if (Items.Contains(t))
            {
                Items.Remove(t);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
