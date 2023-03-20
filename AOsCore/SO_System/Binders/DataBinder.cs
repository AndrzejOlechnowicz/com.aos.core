using System;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

namespace AOsCore.SO_System.UIBinders
{
    public abstract class DataBinder<T> : MonoBehaviour
    {
        [SerializeField] protected DataVariable<T> data;

        protected abstract void Refresh();

        protected virtual void OnEnable()
        {
            data.SubscribeToValueChanged(Refresh);
        }

        protected virtual void OnDisable()
        {
            data.UnsubscribeFromValueChanged(Refresh);
        }
    }
}
