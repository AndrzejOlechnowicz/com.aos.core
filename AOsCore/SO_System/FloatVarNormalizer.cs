using System;
using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.Data.Variables;
using UnityEngine;


public class FloatVarNormalizer : MonoBehaviour
{
    [SerializeField] private FloatVar value;
    [SerializeField] private FloatReference min;
    [SerializeField] private FloatReference max;
    [SerializeField] private FloatVar normalizedValue;

    private void Awake()
    {
        NormalizeValue();
    }

    private void OnEnable()
    {
        value.SubscribeToValueChanged(NormalizeValue);
    }
    
    private void OnDisable()
    {
        value.UnsubscribeFromValueChanged(NormalizeValue);
    }

    private void NormalizeValue()
    {
        var denominator = max - min;
        var nominator = value - min;
        normalizedValue.SetValue(nominator / denominator);
    }
}
