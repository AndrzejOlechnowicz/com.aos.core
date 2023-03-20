using System;
using System.Globalization;
using UnityEngine;

namespace AOsCore.SO_System.Binders.TMProBinders
{
    public class RangedFloatTextBinder : FloatTextBinder
    {
        [SerializeField] private FloatReference minValue, maxValue;
        [SerializeField] private bool isCastToInt;

        private float _maxValueToMultiply;

        protected override void OnEnable()
        {
            _maxValueToMultiply = maxValue - minValue;
            base.OnEnable();
        }

        protected override void Refresh()
        {
            var rangedValue = _maxValueToMultiply * data.Value + minValue;
            if (isCastToInt)
            {
                var intRangedValue = (int) rangedValue;
                _text.SetText(intRangedValue.ToString());
            }
            else
            {
                _text.SetText(rangedValue.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
