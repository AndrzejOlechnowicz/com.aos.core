using AOsCore.SO_System.Binders.ImageBinders;
using System.Collections;
using UnityEngine;

public class FloatImageScaleBinder : ImageBinder<float>
{
    [SerializeField] private FloatReference minValue;
    [SerializeField] private FloatReference maxValue;
    [SerializeField] private bool shouldAnimateIncrease;
    [SerializeField] private bool shouldAnimateDecrease;
    [SerializeField] private float animationTime = 1f;

    private float previousValue;
    private bool firstSetup = true;
    private Vector3 sliderScale;
    private float progressModifier;
    private float progress;
    private float animationTimeDerived;


    protected override void Awake()
    {
        base.Awake();
        previousValue = data.Value;
        animationTimeDerived = 1 / animationTime;
    }

    protected override void Refresh()
    {
        if (firstSetup)
        {
            // on the first setup there should be no animation
            SetImageScale(data.Value);
            firstSetup = false;
            Debug.Log("FloatImageScaleBinder - FIRST SETUP");
            return;
        }
        if (shouldAnimateIncrease || shouldAnimateDecrease)
        {
            if (data.Value > previousValue)
            {
                // new value is larger than current value of the slider
                if (shouldAnimateIncrease)
                {
                    // increased value is animated, set correct animation values
                    progress = previousValue;
                    progressModifier = (maxValue - progress) * animationTimeDerived;

                    StopAllCoroutines();
                    // is animating increase, the progress is smaller than data.Value
                    StartCoroutine(ProgressAnimationCoro(data.Value, progress, progressModifier));
                }
                else
                {
                    // increased value is not animated, set the direct value
                    SetImageScale(data.Value);
                }
            }
            else if (data.Value < previousValue)
            {
                // new value is smaller than current value of the slider
                if (shouldAnimateDecrease)
                {
                    // decreased value is animated, set correct animation values
                    progress = previousValue;
                    progressModifier = (progress - maxValue) * animationTimeDerived;

                    StopAllCoroutines();
                    // is animating decrease, the progress is larger than data.Value
                    StartCoroutine(ProgressAnimationCoro(data.Value, progress, progressModifier));
                }
                else
                {
                    // decreased value is not animated, set  the direct value
                    SetImageScale(data.Value);
                }
            }
        }
        else
        {
            // slider is not animated, set the direct value
            SetImageScale(data.Value);
        }

        previousValue = data.Value;
    }

    private IEnumerator ProgressAnimationCoro(float dataValue, float progress, float progressModifier)
    {
        Debug.Log($"<color=red>Starting progress animation coroutine..., dataValue: {dataValue}, progress: {progress},  progressModifier: {progressModifier}</color>");
        if (dataValue > progress)
        {
            while (dataValue > progress)
            {
                progress += progressModifier;
                SetImageScale(progress);
                Debug.Log($"progress: {progress},  progressModifier:{progressModifier}");
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
        else
        {
            while (dataValue < progress)
            {
                progress += progressModifier;
                SetImageScale(progress);
                Debug.Log($"progress: {progress},  progressModifier:{progressModifier}");
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
    }

    private void SetImageScale(float xValue)
    {
        if (sliderScale == Vector3.zero)
        {
            sliderScale = transform.localScale;
        }
        _image.rectTransform.localScale = new Vector3(xValue, sliderScale.y, sliderScale.z);
    }
}
