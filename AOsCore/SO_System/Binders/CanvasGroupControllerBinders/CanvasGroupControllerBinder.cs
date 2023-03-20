using System;
using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.UIBinders;
using UnityEngine;
[Serializable]
public class CanvasGroupControllerBinder<T> : DataBinder<T>
{
    protected CanvasGroupController _controller;
    
    private void Awake()
    {
        _controller = GetComponent<CanvasGroupController>();
    }
    
    protected override void Refresh()
    {
        throw new System.NotImplementedException();
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        Refresh();
    }
}
