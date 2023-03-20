using System;
using AOsCore.SO_System.UIBinders;
using UnityEngine;
using UnityEngine.UI;

namespace AOsCore.SO_System.Binders.ImageBinders
{
    public abstract class ImageBinder<T> : DataBinder<T>
    {
        protected Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
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
}
