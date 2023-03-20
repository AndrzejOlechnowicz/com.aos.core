using System;
using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.Data.Variables;
using UnityEngine;

public class BoolVarOnStartReseter : MonoBehaviour
{
    [SerializeField] private BoolVar valueToReset;
    [SerializeField] private bool valueToResetTo;

    private void Start()
    {
        valueToReset.SetValue(valueToResetTo);
    }
}
