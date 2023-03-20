
using System;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

[Serializable]
public abstract class DataReference<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public DataVariable<T> Variable;

    protected DataReference()
    {
    }

    public T Value()
    {
        return UseConstant ? ConstantValue : Variable.Value;
    }

    public void SetValue(T value)
    {
        if (UseConstant)
        {
            ConstantValue = value;
        }
        else
        {
            Variable.SetValue(value);
        }
    }

    public static implicit operator T(DataReference<T> dataReference)
    {
        return dataReference.Value();
    }
}
