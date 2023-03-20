using UnityEngine;
using UnityEngine.Assertions;

namespace AOsCore.SO_System.Binders.ImageBinders
{
    public class FloatImageColorBinder : ImageBinder<float>
    {
        [SerializeField] private ColorVar[] colors;

        private void Start()
        {
            // at least one color has to be set (dividing by array len!)
            Assert.IsNotNull(colors); 
            Assert.AreNotEqual(0, colors.Length);
        }

        protected override void Refresh()
        {
            _image.color = PickColorBasedOnFloatValue();
        }

        private Color PickColorBasedOnFloatValue()
        {
            var interval = 1 / (float)colors.Length;

            for (var i = 0; i < colors.Length; i++)
            {
                //Debug.Log($"FloatImageBinder, value: {data.Value}, (interval * (i + 1) : {interval * (i + 1)}");
                if (data.Value <= interval * (i + 1))
                {
                    return colors[i];
                }
            }
            //Debug.Log("FloatImageBinder, value not found, returning first color");
            return colors[0];
        }
    }
}
