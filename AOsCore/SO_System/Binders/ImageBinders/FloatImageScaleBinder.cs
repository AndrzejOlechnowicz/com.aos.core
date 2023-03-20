using System;
using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.Binders.ImageBinders;
using UnityEngine;

public class FloatImageScaleBinder : ImageBinder<float>
{
    [SerializeField] private bool shouldAnimate;
    [SerializeField] private float speed = 1f;
    
    private float previousValue;
    private bool firstSetup = true;

    private void Start()
    {
        previousValue = data.Value;
    }

    protected override void Refresh()
    {
        if (firstSetup)
        {
            SetImageScale(data.Value);
            firstSetup = false;
            return;
        }
        if (shouldAnimate)
        {
            StopAllCoroutines();
            StartCoroutine(AnimateValue(data.Value, previousValue));
        }
        else
        {
            SetImageScale(data.Value);
        }
    }
    

    private IEnumerator AnimateValue(float targetValue, float currentValue)
    {
        var modifier = targetValue - currentValue;
        var derivedModifier = speed / (modifier * 1000);
        //Debug.Log($"currentProgress: {currentValue}, targetProgress: {targetValue}, modifier: {modifier}, derived modifier: {derivedModifier}");
        if (currentValue > targetValue)
        {
            //Debug.Log("Current value is bigger than target value");
            while (currentValue > targetValue)
            {
                currentValue += derivedModifier;
                //Debug.Log($"current value changed to: {currentValue}");
                SetImageScale(currentValue);
                yield return null;
            }
        }
        else
        {
            //Debug.Log("Target value is bigger than current value");
            while (currentValue < targetValue)
            {
                currentValue += derivedModifier;
                //Debug.Log($"current value changed to: {currentValue}");
                SetImageScale(currentValue);
                yield return null;
            }
        }

        previousValue = data.Value;
    }

    private void SetImageScale(float xValue)
    {
        var currentScale = _image.rectTransform.localScale;
        _image.rectTransform.localScale = new Vector3(xValue, currentScale.y, currentScale.z);
    }
}
