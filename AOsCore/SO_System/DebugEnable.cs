using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEnable : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log($"This: {gameObject} was enabled");
    }
}
