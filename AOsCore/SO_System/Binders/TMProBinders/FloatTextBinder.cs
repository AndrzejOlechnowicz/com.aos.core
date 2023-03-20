using AOsCore.SO_System.UIBinders.TMProBinders;
using UnityEngine;

namespace AOsCore.SO_System.Binders.TMProBinders
{
    public class FloatTextBinder : TextBinder<float>
    {
        [SerializeField] private string onEndSign;
        [SerializeField] private string format;
        
        protected override void Refresh()
        {
            var floatValue = data.Value;
            if (format == string.Empty)
            {
                _text.SetText(floatValue.ToString("n2") + onEndSign);
            }
            else
            {
                _text.SetText(floatValue.ToString(format) + onEndSign);
            }
        }
    }
}
