using System;
using UnityEngine.UI;

namespace AOsCore.SO_System.Binders.ImageBinders
{
    public class FloatImageFillBinder : ImageBinder<float>
    {
        protected override void Refresh()
        {
            _image.fillAmount = data.Value;
        }
    }
}
