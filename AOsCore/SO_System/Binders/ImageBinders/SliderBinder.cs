using System;
using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.UIBinders;
using UnityEngine;
using UnityEngine.UI;

public class SliderBinder : DataBinder<float>
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void Refresh()
    {
        _slider.value = data.Value;
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        Refresh();
    }
}
